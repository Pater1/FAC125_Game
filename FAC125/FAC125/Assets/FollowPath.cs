using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {
	
	public float moveSpeed = 1f, lerpRate = 5f, nextNodeRange = 5f;
	public List<Vector3> pathNodes = new List<Vector3>();
	private List<Vector3> pathedNodes = new List<Vector3>();
	
	private Vector3 decayRate = new Vector3(1,1,1);
	
	public Transform makeRelativeTo;
	
	private int currentNode = 0;
	public Vector3 momentum;

	// Use this for initialization
	void OnDrawGizmosSelected () {
		Gizmos.color = new Color(1,1,0,1);
		for(int i = 0; i < pathNodes.Count; i++){
			if(makeRelativeTo != null){
				Gizmos.DrawSphere(pathNodes[i] + makeRelativeTo.position, nextNodeRange);
			}else{
				Gizmos.DrawSphere(pathNodes[i], nextNodeRange);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(makeRelativeTo != null){
			pathedNodes = new List<Vector3>();
			for(int i = 0; i < pathNodes.Count; i++){
				pathedNodes.Add(pathNodes[i] + makeRelativeTo.position);
			}
		}else{
			pathedNodes = pathNodes;
		}
		
		momentum += Vector3.Lerp(momentum, ((pathedNodes[currentNode] - transform.position).normalized * moveSpeed), lerpRate * Time.deltaTime);
		
		if(momentum.magnitude > moveSpeed){
			momentum = momentum.normalized * moveSpeed;
		}
		
	//	if(Physics2D.Raycast((Vector2)(transform.position + momentum.normalized*5), momentum, momentum.magnitude)){
			//momentum = momentum * -0.2f;
	//	}
		
		transform.position += momentum;
		
		if(Vector3.Distance(transform.position, pathedNodes[currentNode]) <= nextNodeRange){
			currentNode++;
			if(currentNode >= pathedNodes.Count){
				currentNode = 0;
				momentum /= 2;
			}
		}
	}
}
