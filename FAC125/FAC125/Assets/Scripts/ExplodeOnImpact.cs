using UnityEngine;
using System.Collections;

public class ExplodeOnImpact : MonoBehaviour {

	private Explodable exp;
	
	// Use this for initialization
	void Start () {
		exp = (Explodable)gameObject.GetComponent("Explodable");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 forward = transform.position + (transform.up * (GetComponent<BoxCollider2D>().size.y * transform.localScale.y * 1.25f));
		RaycastHit2D hit = Physics2D.Raycast(forward, transform.up, .1f);
		if((bool)hit){
			if(!hit.collider.gameObject.GetComponent<Rigidbody>()){
				exp.Explode();
				GameObject.Destroy(gameObject);
			}
		}
	}
}
