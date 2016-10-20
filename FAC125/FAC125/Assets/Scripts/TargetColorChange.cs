using UnityEngine;
using System.Collections;

public class TargetColorChange : MonoBehaviour {

	public Color activatedColor, deactivatedColor;
	
	void Start () {
		if(!gameObject.GetComponent<Target>()){
			gameObject.AddComponent<Target>();
		}
	}
	
	void LateUpdate () {
		if(gameObject.GetComponent<Target>().activated){
			gameObject.GetComponent<SpriteRenderer>().color = activatedColor;
		}else{
			gameObject.GetComponent<SpriteRenderer>().color = deactivatedColor;
		}
	}
}
