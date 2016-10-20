using UnityEngine;
using System.Collections;

public class FireObject : MonoBehaviour {

	public GameObject misslePrefab, lazerPrefab;
	private bool shot = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Shoot") != 0){
			if(!shot){
				GameObject go = gameObject;
				if(Input.GetAxis("Amo") > 0) go = GameObject.Instantiate(lazerPrefab);
				if(Input.GetAxis("Amo") == 0){
					go = GameObject.Instantiate(misslePrefab);
					gameObject.GetComponent<ImpulseMotor>().linearMomentum -= transform.up * .01f;
				} 
				
				go.transform.position = transform.position + (transform.up * gameObject.GetComponent<BoxCollider2D>().size.y * 1.5f);
				go.transform.rotation = transform.rotation;
				
				MissleBehavior mb = ((MissleBehavior)go.GetComponent("MissleBehavior"));
				mb.startingPosition = gameObject.transform.position;
			}
			shot = true;
		}else{
			shot = false;
		}
	}
}
