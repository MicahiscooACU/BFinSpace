using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public static Health instance;

	public GameObject GameManagerGO;
	public GameObject scoreCounter;
	public GameObject PlayerBullet;
	public GameObject NotePosition01;
	public GameObject Explosion;
	public Animator animator;
	public GameObject SpawnPoint;
		public Text LivesUIText;
		const int MaxLives = 3;
		
		int lives;
		
	public float speed;
	
	public void Init()
{
	
	lives = MaxLives;
	LivesUIText.text = lives.ToString ();
		scoreCounter.GetComponent<ScoreCounter>().SetPoints();
		gameObject.SetActive (true);
}

  

    
    void Update()
    {

	
	if(Input.GetKeyDown("space"))
	{	
		
		GameObject note = (GameObject)Instantiate (PlayerBullet);
		note.transform.position = NotePosition01.transform.position;

		
	}
        float x = Input.GetAxisRaw ("Horizontal");
	float y = Input.GetAxisRaw ("Vertical");

	
	Vector2 direction = new Vector2 (x, y).normalized;

	Move (direction);
    }

	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.295f;
		min.x = min.x +0.295f;

		max.y = max.y - 0.29f;
		min.y = min.y + 0.29f;


		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

       void OnTriggerEnter2D(Collider2D col)
	{

		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{

			animator.SetTrigger("hit");

			lives--;
			LivesUIText.text = lives.ToString();
		}
		if(col.tag == "HealthOrbTag")
        {
			lives++;
			LivesUIText.text = lives.ToString();
        }
		
		if(lives == 0)
			{
				PlayExplosion();
				GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
				gameObject.transform.position = SpawnPoint.transform.position;
				gameObject.SetActive(false);
				
			}
		
	}
		



	void PlayExplosion()
{
		GameObject explosion = (GameObject)Instantiate(Explosion);

		explosion.transform.position = transform.position;
}
	

}
	


