using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropExhaust : MonoBehaviour {
	
	public GameObject exhaust;
	public Vector3 velocity, scale;
	public float dropDelay = .5f;
	
	private Coroutine dropping;
	
	private List<GameObject> exhausts = new List<GameObject>();
	private bool allowDrops = false;
	
	public bool _AllowDrops{
		get{
			return allowDrops;
		}
		set{
			allowDrops = value;
		}
	}
	
	void Start(){
		dropping = this.StartCoroutine(this.DropingExhaust());
		allowDrops = true;
	}
	
	private IEnumerator DropingExhaust(){
		do{
			if(allowDrops){
				exhausts.Add(GameObject.Instantiate(exhaust, transform.position, Quaternion.identity)as GameObject);
				for(int i = exhausts.Count-1; i >= 0; i--){
					if(exhausts[i] == null){
						exhausts.Remove(exhausts[i]);
					}
				}
				yield return new WaitForSeconds(dropDelay);
			}
		}
		while(true);
	}
}
