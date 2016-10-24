using UnityEngine;
using System.Collections;

public class SmoothScaleSnap : MonoBehaviour {

	public Vector3 snapToScale;
	public float snapSpeed;
	
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale = Vector3.Lerp(transform.localScale, snapToScale, snapSpeed * Time.deltaTime);
	}
}
