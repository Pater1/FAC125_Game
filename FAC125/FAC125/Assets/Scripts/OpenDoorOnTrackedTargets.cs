using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OpenDoorOnTrackedTargets : MonoBehaviour {

	private TrackTargets tt;
	
	[Range(0,1)]
	public float openness = 0;
	public float openSpeed;
	public Vector3 startingPosition, startingRotation, startingScale, endingPosition, endingRotation, endingScale;
	public GameObject doorBase;
	
	// Update is called once per frame
	void Update () {
		if(tt == null){
			tt = (TrackTargets)gameObject.GetComponent("TrackTargets");
		}
		
		if(!tt.AllTargetsActive()){
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
