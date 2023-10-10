using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpSpawner : MonoBehaviour
{
    public GameObject Simp;

	float maxSpawnRateInSeconds = 5f;
    void Start()
    {
       
    }

  
    void Update()
    {
        
    }



    void SpawnEnemy()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy = (GameObject)Instantiate (Simp);
		anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y + 1);

		ScheduleNextEnemySpawn ();
	}

	void ScheduleNextEnemySpawn ()
	{
		float spawnInSeconds;

		if(maxSpawnRateInSeconds > 1f)
		{	
			spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		}
		else
		
			spawnInSeconds = 1f;

		Invoke ("SpawnEnemy", spawnInSeconds);
	
}

	void IncreaseSpawnRate()
	{
		if(maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if(maxSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
			Invoke("SpawnEnemy", 1f);
		
         }

		public void ScheduleEnemySpawner()
{
 	Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

	InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);

}



		public void UnscheduleEnemySpawner()
{
CancelInvoke ("SpawnEnemy");
CancelInvoke ("IncreaseSpawnRate");

}

		public void ResetEnemySpawner()
	{
maxSpawnRateInSeconds = 6f;
CancelInvoke ("IncreaseSpawnRate");
CancelInvoke ("SpawnEnemy");
		

	}

}
