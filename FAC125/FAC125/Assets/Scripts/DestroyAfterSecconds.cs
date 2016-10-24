using UnityEngine;
using System.Collections;

public class DestroyAfterSecconds : MonoBehaviour {

	public float destroyAfterSeconds = 1;
	
	// Update is called once per frame
	void Update () {
		destroyAfterSeconds -= Time.deltaTime;
		
		if(destroyAfterSeconds <= 0){
			GameObject.Destroy(gameObject);
		}
	}
}
