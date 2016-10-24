using UnityEngine;
using System.Collections;

public class ActivateTargetOnExplode : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if(!gameObject.GetComponent<Target>()){
			gameObject.AddComponent<Target>();
		}
	}
}
