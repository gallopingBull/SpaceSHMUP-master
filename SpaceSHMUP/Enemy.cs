using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int health = 0; 
	public GameObject deathParticle; 
	public int randNum = 0;
	public GameObject[] powerUps; 

	public void Killed () {
		//instantiate particle death effect 
		Instantiate(deathParticle, transform.position, transform.rotation); 

		//instantiate power up
		randNum = Random.Range (0, 3); 
		GameObject powerUp = powerUps[randNum];
		Instantiate(powerUp, transform.position, transform.rotation); 

		//Destory Enemy
		Destroy(this.gameObject);
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Projectile"){ 
			health--;
			if (health == 0){
				Killed(); 
			}
		} 
	}
}
