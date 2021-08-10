using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {
	private Transform target;//set target from inspector instead of looking in Update
	public float speed = 3f;
	public bool isExplosive = false; 

	public GameObject explosion;
	
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		
	}
	
	void Update(){

		if (target == null) {
			//CheckForPlayer();
			return; 
		}
		//rotate to look at the player
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
		
		
		//move towards the player
		if (Vector3.Distance (transform.position, target.position) > .1f) {//move if distance from target is greater than 1
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		} 
		if (Vector3.Distance (transform.position, target.position) < 1.7f && isExplosive) {
			Instantiate(explosion, transform.position, transform.rotation); 
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.name == "Ship") {
			Instantiate(explosion, transform.position, transform.rotation); 
			}
		else 
			Instantiate(explosion, transform.position, transform.rotation); 
		}
}