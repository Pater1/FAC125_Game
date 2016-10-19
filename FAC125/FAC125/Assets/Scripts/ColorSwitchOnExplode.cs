using UnityEngine;
using System.Collections;

public class ColorSwitchOnExplode : MonoBehaviour {

	public Color onColor, offColor;
	
	void Start(){
		ExplosionServer.AddToExplodables(this.gameObject);
		Off();
	} 
	
	public void Update() {
		if(ExplosionServer.checkExplosions && ExplosionServer.CheckExplosion(gameObject, transform.position)){
			On();
		}
	}
	
	void On(){
		gameObject.GetComponent<SpriteRenderer>().color = onColor;
	}
	void Off(){
		gameObject.GetComponent<SpriteRenderer>().color = offColor;
	}
}
