using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class ExplosionServer : MonoBehaviour {
	
	public static ExplosionServer instance;
	public static bool checkExplosions = false;
	
	public static List<GameObject> explodables = new List<GameObject>();
	private static List<GameObject> checkedExplodables = new List<GameObject>();
	
	private static Vector3 explosionCenter;
	private static float explosionRange;

	public static void AddToExplodables (GameObject comp) {
		explodables.Add(comp);
	}
	
	public static void RunExplosions (Vector3 boom, float far) {
		checkExplosions = true;
		checkedExplodables = new List<GameObject>();
		explosionCenter = boom;
		explosionRange = far;
	}
	public static bool CheckExplosion (GameObject onExplodeObj, Vector3 onExplodeLocation) {
		checkedExplodables.Add(onExplodeObj);
		
		
		if(ContainsAll(checkedExplodables,explodables)){
			checkExplosions = false;
		}
		
		
		if(Vector3.Distance(explosionCenter, onExplodeLocation) <= explosionRange){
			return true;
		}else{
			return false;
		}
	}
	
	private static bool ContainsAll(List<GameObject> thisContains, List<GameObject> allThis){
		for(int i = 0; i < allThis.Count; i++){
			if(!thisContains.Contains(allThis[i])) return false;
		}
		return true;
	}
}
