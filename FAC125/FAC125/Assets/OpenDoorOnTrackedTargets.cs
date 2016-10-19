using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OpenDoorOnTrackedTargets : MonoBehaviour {

	private TrackTargets tt;
	
	public float openSpeed;
	public Vector3 startingPosition, startingRotation, endingPosition, endingRotation;
	
	// Use this for initialization
	void Start () {
		tt = (TrackTargets)gameObject.GetComponent("TrackTargets");
	}
	
	// Update is called once per frame
	void Update () {
		if(!tt.AllTargetsActive()){
			transform.position = Vector3.Lerp(transform.position, startingPosition, openSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(startingRotation), openSpeed * Time.deltaTime);
		}else{
			transform.position = Vector3.Lerp(transform.position, endingPosition, openSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(endingRotation), openSpeed * Time.deltaTime);
		}
	}
}
