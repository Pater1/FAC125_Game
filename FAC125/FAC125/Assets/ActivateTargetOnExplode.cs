using UnityEngine;
using System.Collections;

public class ActivateTargetOnExplode : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if(!gameObject.GetComponent<Target>()){
			gameObject.AddComponent<Target>();
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(ExplosionServer.checkExplosions && ExplosionServer.CheckExplosion(gameObject, transform.position)){
			gameObject.GetComponent<Target>().activated = true;
		}
	}
}
