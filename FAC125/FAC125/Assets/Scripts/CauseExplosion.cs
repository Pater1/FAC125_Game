using UnityEngine;
using System.Collections;

public class CauseExplosion : MonoBehaviour {

	void FixedUpdate(){
		Vector3 forward = transform.position + (transform.up * (GetComponent<BoxCollider2D>().size.y * 1.25f));
		RaycastHit2D hit = Physics2D.Raycast(forward, -transform.up, 5f);
		if((bool)hit){
			GameObject go = hit.collider.gameObject;
			if(go.GetComponent("Explodable")){
				((Explodable)go.GetComponent("Explodable")).Explode();
				GameObject.Destroy(gameObject);
			}
		}
	}
}
