using UnityEngine;
using System.Collections;

public class ReplaceOnDie : MonoBehaviour {
	
	public GameObject replaceWith;

	private Vector3 respawnPlace;
	
	void Start(){
		respawnPlace = transform.position;
	}
	
	void OnDestroy() {
		Replace();
	} 
	
	private void Replace(){
		GameObject go = GameObject.Instantiate(replaceWith, respawnPlace, Quaternion.identity) as GameObject;
		go.SetActive(true);
		MonoBehaviour[] comps = go.GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour c in comps){
			 c.enabled = true;
		}
		go.GetComponent<DropInAfterSeconds>().enabled = true;
	}
}
