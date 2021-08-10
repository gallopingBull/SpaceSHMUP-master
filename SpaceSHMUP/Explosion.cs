using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	//GameObject ship; 

	// Use this for initialization
	void Awake () {
		//ship = GameObject.FindGameObjectWithTag("Player"); 
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Enemy") {
			col.GetComponent<Enemy> ().Killed ();
		} else if (col.gameObject.tag == "Player") {
			col.GetComponent<ShipController> ().Killed ();
			//ship.GetComponent<ShipController> ().Killed ();
			print ("Call kill on player:: Explosion.cs"); 
		}
		Destroy (this.gameObject, .7f);
	}
}
