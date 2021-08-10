using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public bool canShoot = true; 
	public bool haveSingleShot = false;
	public bool haveSpreadShot = false;
	private bool canShield = true; 


	public int shieldCountMAX = 0; 
	public int shieldCount = 0; 
	public float shieldLifeSpan = 0; 
	public float shootingInterval = 0; 

	private GameObject shield; 
	public GameObject spawnLocation; 
	public GameObject singleShotPrefab;
	public GameObject spreadShotPrefab; 
	public GameObject shieldPrefab; 
	
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		if (haveSingleShot) {
			if (Input.GetKeyDown ("space") && canShoot){
				canShoot = false; 
				Instantiate(singleShotPrefab, spawnLocation.transform.position, transform.rotation); 
				StartCoroutine(Delay()); 
			}	
		}
		if (haveSpreadShot) {
			if (Input.GetKeyDown("space") && canShoot){
				canShoot = false; 
				Vector3 bLPos = new Vector3 (spawnLocation.transform.position.x -.3f, spawnLocation.transform.position.y); 
				Vector3 bRPos = new Vector3 (spawnLocation.transform.position.x + .3f, spawnLocation.transform.position.y);
				Instantiate(spreadShotPrefab, bLPos, transform.rotation); 
				Instantiate(spreadShotPrefab, bRPos, transform.rotation);
				StartCoroutine(Delay());
			}
		}
		if (Input.GetKeyDown("c") && shieldCount > 0 && canShield) {
			shieldCount--;
			canShield = false; 
			StartCoroutine(Delay());
			shield = (GameObject)Instantiate(shieldPrefab, transform.position, transform.rotation);
			print ("Shield should be activated"); 
			shield.transform.parent = this.gameObject.transform; 
			Destroy(shield, shieldLifeSpan);
		}
	}

	public void Killed(){
		Destroy (this.gameObject);
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Enemy") {
			print ("touched enemy"); 
			Killed (); 
		} else {
			//print ("no tag");
		}
	}

	IEnumerator Delay() {
		if (haveSingleShot) {
			yield return new WaitForSeconds(shootingInterval);
			canShoot = true; 
		}
		if (haveSpreadShot) {
			yield return new WaitForSeconds(shootingInterval);
			canShoot = true;
		}
		if (!canShield) {
			yield return new WaitForSeconds(shieldLifeSpan);
			canShield = true;
		}
	}
}
