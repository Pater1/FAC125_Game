using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicalAI : MonoBehaviour {
	
	public float activeRange = 500;
	
	[Range(0,1)]
	public float lazerCutoff;
	[Range(1f, 4f)]
	public float missleCutoff;
	
	public Transform rightLazer, leftLazer, misslePlace;
	public GameObject missle, lazer;
	
	private AudioSource src;
	
	private bool right = false;
	private float[] samples;
	
	void Awake(){
		src = gameObject.GetComponent<AudioSource>();
		samples = new float[src.clip.samples];
		src.clip.GetData(samples, 0);
	}
	
	void Update () {
		if(Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > activeRange){
			return;
		}
		
		float smpl = samples[src.timeSamples];
		if(Mathf.Abs(smpl) > lazerCutoff){
			if(right){
				Fire(lazer, rightLazer.position);
			}else{
				Fire(lazer, leftLazer.position);
			}
			right = !right;
		}
		
		int sampleLength = 10;
		float[] smpls = new float[sampleLength];
		for(int i = 0; i < smpls.Length; i++){
			int samp = (src.timeSamples + (i-sampleLength/2));
			smpls[i] = samples[(samp < 0 ? (samp + src.clip.samples):samp) % src.clip.samples];
		}
		
		List<int> inflectionPointArray = new List<int>();
		inflectionPointArray.Add(0);
		for(int i = 1; i < smpls.Length-1; i++){
			float into = smpls[i-1] - smpls[i], outOf = smpls[i] - smpls[i+1];
			bool inSig = (into < 0), outSig = (outOf < 0);
			if(inSig != outSig){
				inflectionPointArray.Add(i);
			}
		}
		inflectionPointArray.Add(smpls.Length-1);
		
		float sudoFrequency = 0;
		for(int i = 1; i < inflectionPointArray.Count; i++){
			sudoFrequency += (inflectionPointArray[i] - inflectionPointArray[i-1]);
		}
		sudoFrequency /= inflectionPointArray.Count-2;
		
		if(sudoFrequency > missleCutoff){
			Fire(missle, misslePlace.position);
		}
	}
	
	private void Fire(GameObject amo, Vector3 place){
		GameObject go = GameObject.Instantiate(amo);
		go.transform.position = place;
		go.transform.rotation = transform.rotation;
		
		MissleBehavior mb = ((MissleBehavior)go.GetComponent("MissleBehavior"));
		mb.startingPosition = gameObject.transform.position;
	}
}
