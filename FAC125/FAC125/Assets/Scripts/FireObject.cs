using UnityEngine;
using System.Collections;

public class FireObject : MonoBehaviour {

	public GameObject misslePrefab, lazerPrefab;
	public float forwardOffset = 5f;
	private bool shot = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Shoot") != 0){
			if(!shot){
				GameObject go = gameObject;
				if(Input.GetAxis("Amo") > 0) go = GameObject.Instantiate(lazerPrefab);
				if(Input.GetAxis("Amo") == 0) go = GameObject.Instantiate(misslePrefab);
				
				go.transform.position = transform.position + (transform.up * forwardOffset);
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
