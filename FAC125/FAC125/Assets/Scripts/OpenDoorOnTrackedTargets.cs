using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OpenDoorOnTrackedTargets : MonoBehaviour {
	[Range(0,1)]
	public float openness = 0;
	public float openSpeed;
	public Vector3 startingPosition, startingRotation, startingScale, endingPosition, endingRotation, endingScale;
	public GameObject doorBase;
	
	void Update () {
		if( !((!gameObject.GetComponent("TrackTargets") || gameObject.GetComponent<TrackTargets>().AllTargetsActive()) 
			&& (!gameObject.GetComponent("TrackBoss") || gameObject.GetComponent<TrackBoss>().TargetsDead()))
			){
			openness = Mathf.Lerp(openness, 0, openSpeed * Time.deltaTime);
		}else{
			if(openness < 0.1f){
				gameObject.GetComponent<AudioSource>().Play();
			}
			openness = Mathf.Lerp(openness, 1, openSpeed * Time.deltaTime);
		}
		
		doorBase.transform.position = Vector3.Lerp(startingPosition + transform.position, endingPosition  + transform.position, openness);
		doorBase.transform.rotation = Quaternion.Slerp(Quaternion.Euler(startingRotation), Quaternion.Euler(endingRotation), openness);
		doorBase.transform.localScale = Vector3.Lerp(startingScale, endingScale, openness);
	}
}
