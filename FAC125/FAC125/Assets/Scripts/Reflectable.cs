using UnityEngine;
using System.Collections;

public class Reflectable : MonoBehaviour {
	void FixedUpdate(){
		Vector3 forward = transform.position + (transform.up * (GetComponent<BoxCollider2D>().size.y * 1.25f));
		RaycastHit2D hit = Physics2D.Raycast(forward, -transform.up, 5f);
		if((bool)hit){
			GameObject go = hit.collider.gameObject;
			if(go.GetComponent("CauseReflection")){
				((CauseReflection)go.GetComponent("CauseReflection")).ReflectThis(gameObject);
			}else{
				GameObject.Destroy(gameObject);
			}
		}
	}
}
