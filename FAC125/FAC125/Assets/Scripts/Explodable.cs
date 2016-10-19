using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour {
	
	public float explosionRange;
	
	// Use this for initialization
	public void Explode () {
		ExplosionServer.RunExplosions(transform.position, explosionRange);
		GameObject.Destroy(gameObject);
	}
}
