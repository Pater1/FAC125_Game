using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicLocationServer : MonoBehaviour {
	
	public AudioMixer distanceMix;
	public List<GameObject> mirrors, targets, mines, bosses;
	private GameObject player;
	
	public Vector2 mapDistance = new Vector2(10,50), toVolume = new Vector2(5,-80);

	// Use this for initialization
	void Start () {
		GameObject[] mirrorsArray = GameObject.FindGameObjectsWithTag("Mirror");
		GameObject[] targetsArray = GameObject.FindGameObjectsWithTag("Target");
		GameObject[] minesArray = GameObject.FindGameObjectsWithTag("Mine");
		GameObject[] bossArray = GameObject.FindGameObjectsWithTag("Boss");
		
		foreach(GameObject go1 in mirrorsArray) mirrors.Add(go1);
		foreach(GameObject go2 in targetsArray) targets.Add(go2);
		foreach(GameObject go3 in minesArray) mines.Add(go3);
		foreach(GameObject go4 in bossArray) bosses.Add(go4);
		
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	//  Math.random() * (inputs.get(i-1)-inputs.get(i)) + inputs.get(i) 
	void LateUpdate () {
		if(player == null){
			player = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		distanceMix.SetFloat("MirrorVolume" ,MapValueBetweeRanges(toVolume, mapDistance, MinimumDistanceFromPlayer(mirrors,player)));
		distanceMix.SetFloat("MineVolume" ,MapValueBetweeRanges(toVolume, mapDistance, MinimumDistanceFromPlayer(mines,player)));
		distanceMix.SetFloat("TargetVolume" ,MapValueBetweeRanges(toVolume, mapDistance, MinimumDistanceFromPlayer(targets,player)));
		distanceMix.SetFloat("BossVolume" ,MapValueBetweeRanges(toVolume, mapDistance, MinimumDistanceFromPlayer(bosses,player)));
	}
	
	private float MapValueBetweeRanges(Vector2 toRange, Vector2 fromRange, float map){
		return toRange.x + ((toRange.y - toRange.x) / (fromRange.y - fromRange.x)) * (map - fromRange.x);
	}
	
	private float MinimumDistanceFromPlayer(List<GameObject> from, GameObject player){
		float closest = 5000f;
		if(from.Count > 0){
			for(int i = (from.Count-1); i >= 0; i--){
				if(from[i] == null){
					from.Remove(from[i]);
				}else{
					GameObject go = from[i];
					if(Vector3.Distance(go.transform.position, player.transform.position) < closest){
						closest = Vector3.Distance(go.transform.position, player.transform.position);
					}
				}
			}
		}
		return closest;
	}
}
