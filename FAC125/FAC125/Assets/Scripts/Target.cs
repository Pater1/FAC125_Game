using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	public bool activated = false;
	
	public void Activate(){
		activated = true;
		gameObject.GetComponent<AudioSource>().Play();
	}
}
