using UnityEngine;
using System.Collections;

public class FaceBackward : MonoBehaviour {
	
	public float rotSpeed = 5f;
	
	public Vector3 nowPlace, thenPlace;
	
	void LateUpdate () {
		nowPlace = transform.position;
		
		Vector3 trigAngle = thenPlace - nowPlace;
		float angle = Mathf.Atan2(trigAngle.y, trigAngle.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
		
		thenPlace = transform.position;
	}
}
