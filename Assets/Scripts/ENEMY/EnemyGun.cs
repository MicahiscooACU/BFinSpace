using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

	public GameObject EnemyBulletGO;
    
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    
    void Update()
    {
        
    }

	void FireEnemyBullet()
{
	GameObject playerShip = GameObject.Find ("bfPixel_4");

	if(playerShip != null)
{

	GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

	bullet.transform.position = transform.position;

	Vector2 direction = playerShip.transform.position - bullet.transform.position;

	bullet.GetComponent<EnemyBullet>().SetDirection(direction);
}

}



}
