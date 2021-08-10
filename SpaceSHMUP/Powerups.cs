using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {
	public float lifeSpan = 0;
	public bool isShield;
	public bool isSingleShot; 
	public bool isSpreadShot; 

	int shieldMAX; 
	GameObject ship; 

	// Use this for initialization
	void Awake () {
		ship = GameObject.FindGameObjectWithTag("Player"); 
		shieldMAX = ship.GetComponent<ShipController>().shieldCountMAX;
	
	}

	void Start () {
		StartCoroutine(DestoryTimer());
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.name == "Ship") {
			if(isSingleShot){
				print ("Picked up single shot");
				ship.GetComponent<ShipController>().haveSingleShot = true;
				ship.GetComponent<ShipController>().haveSpreadShot = false;
				Destroy(this.gameObject); 
			}
			else if(isSpreadShot){
				print ("Picked up spread shot"); 
				ship.GetComponent<ShipController>().haveSingleShot = false;
				ship.GetComponent<ShipController>().haveSpreadShot = true;
				Destroy(this.gameObject); 

			}
			else {
				if(isShield){
					int currentShields = ship.GetComponent<ShipController>().shieldCount;
					print ("Just picked up a shield, bitch");

					if (currentShields < shieldMAX){
						ship.GetComponent<ShipController>().shieldCount++;
					}
					Destroy(this.gameObject); 
				}

			}
		} 
	}	

	//Destroy this power up after not being touched after WaitForSeconds() is finished. 
	IEnumerator DestoryTimer() {
		yield return new WaitForSeconds(lifeSpan);
		Destroy(this.gameObject); 
	}
}
