using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {

	public float explosionRange = 5;
	
	private List<Target> targs = new List<Target>();
	private List<Explodable> explodes = new List<Explodable>();
	private float spacing = 1f;
	private static int resolution = 10;
	
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(1,0,0,1);
		for(int i = 0; i < 360; i += resolution){
			
			Vector2 dir = (Vector2)(Quaternion.Euler(0,0,i) * Vector2.right);
			Ray2D ray = new Ray2D(transform.position + (Quaternion.Euler(0,0,i) * Vector2.right * spacing), dir);
			Gizmos.DrawRay(ray.origin, ray.direction * (explosionRange-spacing));
		}
	}
	
	void Start () {
		explosionRange = explosionRange;
		for(int i = 0; i < 360; i += resolution){
			Vector2 dir = (Vector2)(Quaternion.Euler(0,0,i) * Vector2.right);
			Ray2D ray = new Ray2D(transform.position + (Quaternion.Euler(0,0,i) * Vector2.right * spacing), dir);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, explosionRange-spacing);
			if((bool)hit){
				if(hit.collider.gameObject.GetComponent<Target>() && !targs.Contains(hit.collider.gameObject.GetComponent<Target>())){
					targs.Add(hit.collider.gameObject.GetComponent<Target>());
				}
				if(hit.collider.gameObject.GetComponent<Explodable>() && !explodes.Contains(hit.collider.gameObject.GetComponent<Explodable>())){
					explodes.Add(hit.collider.gameObject.GetComponent<Explodable>());
				}
			}
		}
	}
	
	void OnDestroy(){
		foreach(Target tar in targs){
			if(tar != null) tar.Activate();
		}
		foreach(Explodable exp in explodes){
			if(exp != null) exp.Explode();
		}
	}
}
