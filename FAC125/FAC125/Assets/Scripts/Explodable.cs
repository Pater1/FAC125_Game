using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour {
	
	public float explosionRange;
	public GameObject explosion;
	public Vector3 explosionScale = new Vector3(1,1,1);
	
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(0,1,1,.25f);
		Gizmos.DrawSphere(transform.position, explosionRange);
	}
	
	public void Explode () {
		ExplosionServer.RunExplosions(transform.position, explosionRange);
		GameObject go = GameObject.Instantiate(explosion);
		go.transform.position = transform.position;
		go.transform.rotation = transform.rotation;
		go.GetComponent<SmoothScaleSnap>().snapToScale = explosionScale;
		go.GetComponent<Explosion>().explosionRange = explosionRange;
		GameObject.Destroy(gameObject);
	}
}
