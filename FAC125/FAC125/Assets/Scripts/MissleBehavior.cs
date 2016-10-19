using UnityEngine;
using System.Collections;

public class MissleBehavior : MonoBehaviour {

	public float velocity,acceleration,range;
	public Vector3 startingPosition;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * velocity * Time.deltaTime;
		velocity += acceleration * Time.deltaTime;
		if(Vector3.Distance(gameObject.transform.position, startingPosition) > range){
			GameObject.Destroy(gameObject);
		}
	}
}
