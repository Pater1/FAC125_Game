using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ImpulseMotor : MonoBehaviour {
	
	public float impulseThrust, sustainedThrust, rotationSpeed, linearFriction, angularFriction;
	
	public Vector3 impulse, sustain;
	public Vector3 linearMomentum, angularMomentum;
	public bool thrusting;
	
	public GameObject forward, reverse, clockWise, cClockWise;
	
	// Update is called once per frame
	void FixedUpdate () {
		#if UNITY_EDITOR
			if(Application.isPlaying){
				Motor();
			}
		#endif
		#if UNITY_STANDALONE
			Motor();
		#endif
	}
	
	private void Motor(){
		gameObject.SetActive(true);
		Vector3 input = new Vector3(Input.GetAxis("HMove"),Input.GetAxis("VMove"),0);
		if(input.y > 0){
			if(thrusting){
				linearMomentum = Vector3.Lerp(linearMomentum, impulseThrust * transform.up,linearFriction * Time.deltaTime);
			}else{
				linearMomentum = Vector3.Lerp(linearMomentum, sustainedThrust * input.y * transform.up,linearFriction * Time.deltaTime);
			}
			forward.SetActive(true);
			reverse.SetActive(false);
		}else if(input.y < 0){
			if(thrusting){
				linearMomentum = Vector3.Lerp(linearMomentum, impulseThrust * .5f * transform.up,linearFriction * Time.deltaTime);
			}else{
				linearMomentum = Vector3.Lerp(linearMomentum, sustainedThrust * input.y*.5f * transform.up,linearFriction * Time.deltaTime);
			}
			forward.SetActive(false);
			reverse.SetActive(true);
		}else{
			forward.SetActive(false);
			reverse.SetActive(false);
		}
		
		RaycastHit2D hit = Physics2D.Raycast((Vector2)(transform.position + (linearMomentum/linearMomentum.magnitude)*8), (Vector2)(linearMomentum/linearMomentum.magnitude), 2.5f);
		if((bool)hit){
			linearMomentum = new Vector3();
		}
		transform.position += linearMomentum;
		
		if(input.x != 0){
			angularMomentum = Vector3.Lerp(angularMomentum, new Vector3(0,0,-input.x * rotationSpeed), angularFriction * Time.deltaTime);
			
			if(input.x > 0){
				cClockWise.SetActive(false);
				clockWise.SetActive(true);
			}else{
				cClockWise.SetActive(true);
				clockWise.SetActive(false);
			}
			
			Quaternion rot = Quaternion.Euler(new Vector3(0,0,angularMomentum.z + transform.rotation.eulerAngles.z));
			
			transform.rotation = Quaternion.Slerp(transform.rotation,rot, angularFriction * Time.deltaTime);
		}else{
			cClockWise.SetActive(false);
			clockWise.SetActive(false);
		}
	}
}
