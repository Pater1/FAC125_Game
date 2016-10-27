using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp = 3;
	public float explosionRange;
	public GameObject explosion;
	public Vector3 explosionScale = new Vector3(1,1,1);
	
	public Color colorStart, colorEnd;
	
	public int maxHp;
	
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(0,1,1,.25f);
		Gizmos.DrawSphere(transform.position, explosionRange);
	}
	
	void Awake(){
		maxHp = hp;
	}
	
	void LateUpdate(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(colorEnd, colorStart, (float)hp/(float)maxHp);
		if(hp <= 0){
			Explode();
		}
	}
	
	private void Explode () {
		ExplosionServer.RunExplosions(transform.position, explosionRange);
		GameObject go = GameObject.Instantiate(explosion);
		go.transform.position = transform.position;
		go.transform.rotation = transform.rotation;
		go.GetComponent<SmoothScaleSnap>().snapToScale = explosionScale;
		go.GetComponent<Explosion>().explosionRange = explosionRange;
		GameObject.Destroy(gameObject);
	}
}
