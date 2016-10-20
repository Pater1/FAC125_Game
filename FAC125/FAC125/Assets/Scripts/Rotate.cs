using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotationRate, rotationSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, transform.rotation.eulerAngles + new Vector3(0,0,rotationRate), rotationSpeed * Time.deltaTime));
	}
}
