using UnityEngine;
using System.Collections;

public class ImpulseMotor : MonoBehaviour {
	
	public float impulseThrust, sustainedThrust, rotationSpeed, linearFriction, angularFriction;
	
	public Vector3 impulse, sustain;
	public Vector3 linearMomentum, angularMomentum;
	public bool thrusting;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 input = new Vector3(Input.GetAxis("HMove"),Input.GetAxis("VMove"),0);
		if(input.y > 0){
			if(thrusting){
				linearMomentum = Vector3.Lerp(linearMomentum, impulseThrust * transform.up,linearFriction * Time.deltaTime);
			}else{
				linearMomentum = Vector3.Lerp(linearMomentum, sustainedThrust * input.y * transform.up,linearFriction * Time.deltaTime);
			}
		}else if(input.y < 0){
			if(thrusting){
				linearMomentum = Vector3.Lerp(linearMomentum, impulseThrust * .5f * transform.up,linearFriction * Time.deltaTime);
			}else{
				linearMomentum = Vector3.Lerp(linearMomentum, sustainedThrust * input.y*.5f * transform.up,linearFriction * Time.deltaTime);
			}
		}
		
		RaycastHit2D hit = Physics2D.Raycast((Vector2)(transform.position + (linearMomentum/linearMomentum.magnitude)*8), (Vector2)(linearMomentum/linearMomentum.magnitude), 2.5f);
		if((bool)hit){
			linearMomentum = new Vector3();
		}
		transform.position += linearMomentum;
		
		if(input.x != 0){
			angularMomentum = Vector3.Lerp(angularMomentum, new Vector3(0,0,-input.x * rotationSpeed), angularFriction * Time.deltaTime);
			
			Quaternion rot = Quaternion.Euler(new Vector3(0,0,angularMomentum.z + transform.rotation.eulerAngles.z));
			
			transform.rotation = Quaternion.Slerp(transform.rotation,rot, angularFriction * Time.deltaTime);
		}
	}
}
