using UnityEngine;
using System.Collections;

public class Invert : MonoBehaviour {
	
	// Update is called once per frame
	void LateUpdate () {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
