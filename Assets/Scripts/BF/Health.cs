using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HealthPrefab;
    public float randomTimer = 10f;
    // Start is called before the first frame update

    void SpawnRandomHealth()
    {
            GameObject health = (GameObject)Instantiate(HealthPrefab);
            health.transform.position = new Vector2(Random.Range(-6, 6), 0);
            
            randomTimer = Random.Range(10f, 30f);
    }
    
        // Update is called once per frame
        void Update()
    {
        randomTimer = randomTimer - Time.deltaTime;

        if (randomTimer < 0f)
        {
            SpawnRandomHealth();

        }
    }
}
