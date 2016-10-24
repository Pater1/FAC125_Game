using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FollowWithScaledOffset : MonoBehaviour {

	public GameObject followThis;
	public Vector3 scaledOffset;
	public Vector3 localOffset;
	
	
	// Update is called once per frame
	void Update () {
		localOffset =  new Vector3( scaledOffset.x * followThis.transform.localScale.x, 
									scaledOffset.y * followThis.transform.localScale.y,
									scaledOffset.z * followThis.transform.localScale.z);
		transform.position = followThis.transform.position + localOffset;
	}
}
