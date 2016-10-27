using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropMineOnTargets : MonoBehaviour {
	
	public int dropCount = 1;
	public bool decending = false;
	
	public List<Vector3> dropPlaces;
	public List<GameObject> randDrops;
	
	private TrackTargets tt;
	
	void OnDrawGizmosSelected () {
		Gizmos.color = new Color(1,0,1,1);
		for(int i = 0; i < dropPlaces.Count; i++){
			Gizmos.DrawSphere(dropPlaces[i], 10);
		}
	}

	void Update () {
		if(tt == null){
			tt = (TrackTargets)gameObject.GetComponent("TrackTargets");
		}
		
		if(tt.AllTargetsActive()){
			for(int q = 0; q < dropCount; q++){
				GameObject go = GameObject.Instantiate(randDrops[(int)Random.Range(0,randDrops.Count)]);
				Vector3 here = GameObject.FindGameObjectWithTag("Player").transform.position;
				for(int i = 0; i < dropPlaces.Count; i++){
					if(Vector3.Distance(dropPlaces[i],GameObject.FindGameObjectWithTag("Player").transform.position) > Vector3.Distance(here, GameObject.FindGameObjectWithTag("Player").transform.position)){		
						here = dropPlaces[(int)Mathf.Abs(i + Random.Range(-5,5)) % dropPlaces.Count];
					}
				}
				go.transform.position = here;
			}
			dropCount += decending ? -1:1;
			if(dropCount <= 0){
				dropCount = 1;
			}
			tt.Reset();
		}
	}
}
