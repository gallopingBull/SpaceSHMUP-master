using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Enemy") {
			col.GetComponent<Enemy>().Killed();
		}

	}
}
