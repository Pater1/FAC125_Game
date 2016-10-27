using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackBoss : MonoBehaviour {
	
	public List<GameObject> trackTillDead;
	
	// Update is called once per frame
	public bool TargetsDead () {
		if(trackTillDead.Count > 0){
			for(int i = trackTillDead.Count - 1; i >= 0; i--){
				if(trackTillDead[i] == null){
					trackTillDead.Remove(trackTillDead[i]);
				}
			}
			return false;
		}else{
			return true;
		}
	}
}
