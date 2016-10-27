using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackTargets : MonoBehaviour {

	public bool mustBeHitInOrder = false;
	public List<Target> trackThese = new List<Target>();
	
	public bool AllTargetsActive() {
		bool toReturn = true, hitFalse = false;
		for(int i = 0; i < trackThese.Count; i++){
			if(!hitFalse){
				if(!trackThese[i].activated){
					toReturn = false;
					hitFalse = true;
					
					if(!mustBeHitInOrder){
						break;
					}
				}
			}else{
				if(trackThese[i].activated){
					for(int j = 0; j < trackThese.Count; j++){
						trackThese[j].activated = false;
					}
					break;
				}
			}
		}
		return toReturn;
	}
	
	public void Reset(){
		for(int i = 0; i < trackThese.Count; i++){
			trackThese[i].activated = false;
		}
	}
}
