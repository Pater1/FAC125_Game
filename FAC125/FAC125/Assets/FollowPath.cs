using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	
	public float moveSpeed = 1f, lerpRate = 5f, nextNodeRange = 5f;
	public List<Vector3> pathNodes = new List<Vector3>();
	
	private Vector3 decayRate = new Vector3(1,1,1);
	
	private int currentNode = 0;
	public Vector3 momentum;

	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.color = new Color(1,1,0,1);
		for(int i = 0; i < pathNodes.Count; i++){
			Gizmos.DrawSphere(pathNodes[i], nextNodeRange);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//momentum -= decayRate * Time.deltaTime;
		momentum += Vector3.Lerp(momentum, ((pathNodes[currentNode] - transform.position).normalized * moveSpeed), lerpRate * Time.deltaTime);
		
		if(momentum.magnitude > moveSpeed){
			momentum = momentum.normalized * moveSpeed;
		}
		
	//	if(Physics2D.Raycast((Vector2)(transform.position + momentum.normalized*5), momentum, momentum.magnitude)){
			//momentum = momentum * -0.2f;
	//	}
		
		transform.position += momentum;
		
		if(Vector3.Distance(transform.position, pathNodes[currentNode]) <= nextNodeRange){
			currentNode++;
			if(currentNode >= pathNodes.Count){
				currentNode = 0;
				momentum /= 2;
			}
		}
	}
}
