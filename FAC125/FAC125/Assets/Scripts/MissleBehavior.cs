using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissleBehavior : MonoBehaviour {

	public float velocity,acceleration,range;
	public Vector3 startingPosition;
	
	public List<Sprite> missileImages;
	
	void Awake(){
		gameObject.GetComponent<SpriteRenderer>().sprite = missileImages[Random.Range(0,missileImages.Count)];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * velocity * Time.deltaTime;
		velocity += acceleration * Time.deltaTime;
		if(Vector3.Distance(gameObject.transform.position, startingPosition) > range && range > 0){
			GameObject.Destroy(gameObject);
		}
	}
}
