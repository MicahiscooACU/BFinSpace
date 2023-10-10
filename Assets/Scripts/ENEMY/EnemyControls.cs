using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
	public GameObject ExplosionGO;
	float speed;
   

    void Start()
    {
        speed = Random.Range(1f, 3f);
    }

   
    void Update()
    {
        
		Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if(transform.position.y < min.y)
		{
			Destroy(gameObject);
}


    }

	void OnTriggerEnter2D(Collider2D col)
{

	if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
		{
			PlayExplosion();
			Destroy(gameObject);
			ScoreCounter.instance.AddPoint();
		}
}

void PlayExplosion()
{
GameObject explosion = (GameObject)Instantiate(ExplosionGO);


explosion.transform.position = transform.position;
}

}
