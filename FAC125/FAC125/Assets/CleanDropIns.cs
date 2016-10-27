using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class CleanDropIns : MonoBehaviour {
	public bool clean = false;
	
	void Awake () {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("DropIn");
		foreach(GameObject go in gos){
			GameObject.Destroy(go);
		}
	}
	
	#if UNITY_EDITOR
	void Update(){
		if(!Application.isPlaying || clean == true){
			GameObject[] gos = GameObject.FindGameObjectsWithTag("DropIn");
			foreach(GameObject go in gos){
				GameObject.DestroyImmediate(go);
			}
			clean = false;
		}
	}
	#endif
}
