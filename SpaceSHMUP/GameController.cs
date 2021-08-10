using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public float resetDelay = .1f;
	public int maxClones = 6; 
	
	
	private GameObject ship;  
	public GameObject[]  cloneList;
	public GameObject[] enemyPrefabList;  

	
	void Awake (){
		ship = GameObject.FindWithTag ("Player");

	}

	void OnGUI(){
		if (ship != null) {
			GUI.Label (new Rect (100, 30, 100, 30), "Total Shields = " + ship.GetComponent<ShipController> ().shieldCount);
		}
		GUI.Label(new Rect(100, 60, 100, 300), "Press 'c' to use Shield"); 
		return;
	}
	
	void Update(){
	
		if (ship == null) {
			Reset (); 
		} else {
			cloneList = GameObject.FindGameObjectsWithTag ("Enemy"); 
			if (cloneList.Length == 0) {
				for (int index = 0; index < maxClones; index++) {
					Instantiate (enemyPrefabList [Random.Range (0, enemyPrefabList.Length)], new Vector3 (Random.Range (-6, 6), Random.Range (5, 8), 0), transform.rotation);  
					cloneList = GameObject.FindGameObjectsWithTag ("Enemy"); 
					
					//print("List Empty"); 
				}
			} else if (cloneList.Length < 3) {
				for (int index = cloneList.Length; index < maxClones; index++) {
					Instantiate (enemyPrefabList [Random.Range (0, enemyPrefabList.Length)], new Vector3 (Random.Range (-6, 6), Random.Range (5, 8), 0), transform.rotation);  
					cloneList = GameObject.FindGameObjectsWithTag ("Enemy"); 
					
				}
			}
		}
	}


	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel ("test");
	}
}
