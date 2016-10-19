using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public GameObject followThis;
	public Vector3 offset;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = followThis.transform.position + offset;
	}
}
