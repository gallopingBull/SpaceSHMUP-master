using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float velocity = 0f; 
	float boundries = .5f; 
	Vector3 newPos; 

	private float minY = 0;
	private float maxY = 0;
	private float minX = 0;
	private float maxX = 0; 

	// Use this for initialization
	void Awake () {
		minX = -3.4f;
		maxX = 3.4f; 
		maxY = Camera.main.orthographicSize - boundries;
		minY = -Camera.main.orthographicSize + boundries;
	
	}
	
	// Update is called once per frame
	void Update () {
		//movement implementation 
		newPos.x += Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
		newPos.y += Input.GetAxis("Vertical") * velocity * Time.deltaTime;

		//clamp boundaries
		newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
		newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

		//declare new pos
		gameObject.transform.localPosition = newPos;
	
	}
}
