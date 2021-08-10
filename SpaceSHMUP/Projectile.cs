using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float bulletSpeed = 0f; 
	public float lifeSpan = 0f; 
	Rigidbody rb; 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		Destroy (this.gameObject, lifeSpan);  
	
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3(0, bulletSpeed, 0);
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy"){ 
			Destroy(this.gameObject); 
		} 
	}
}
