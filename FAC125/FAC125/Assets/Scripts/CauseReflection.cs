using UnityEngine;
using System.Collections;

public class CauseReflection : MonoBehaviour {
	public void ReflectThis(GameObject go){
		
		#region rotation
		Vector3 toRot = new Vector3 (0,0, 
			go.transform.rotation.eulerAngles.z + 2*((transform.rotation.eulerAngles.z +90) - go.transform.rotation.eulerAngles.z));
		go.transform.rotation = Quaternion.Euler(toRot);
		#endregion
	}
}
