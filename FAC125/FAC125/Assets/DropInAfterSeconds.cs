using UnityEngine;
using System.Collections;

public class DropInAfterSeconds : MonoBehaviour {
	
	public GameObject replaceWith;
	public float delay = 2f;
	public bool didDrop = false;
	public Vector3 respawnPlace;
	
	private GameObject go;
	
	void Start () {
		go = GameObject.Instantiate(replaceWith, respawnPlace, Quaternion.identity) as GameObject;
		StartCoroutine(Drop());
	}
	
	private IEnumerator Drop () {
		yield return new WaitForSeconds(delay);
		if(!didDrop){
			go.SetActive(true);
			MonoBehaviour[] comps = go.GetComponents<MonoBehaviour>();
			foreach(MonoBehaviour c in comps){
				 c.enabled = true;
			}
			go.GetComponent<CircleCollider2D>().enabled = true;
			didDrop = true;
		}
		
		yield return new WaitForSeconds(delay/2);
		GameObject.Destroy(this.gameObject);
		
		yield break;
	}
}
