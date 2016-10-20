using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorFlicker : MonoBehaviour {

	public Vector4 perChannelFlickerRates = new Vector4(1,1,1,1);
	public List<Color> flickerThroughColors;
	
	private int[] returnFlickers = new int[4];
	private Color currentColor;
	
	// Update is called once per frame
	void FixedUpdate () {
		currentColor.r = Mathf.Lerp(currentColor.r, flickerThroughColors[returnFlickers[0]].r, perChannelFlickerRates.x * Time.deltaTime);
		if(Mathf.Abs(flickerThroughColors[returnFlickers[0]].r - currentColor.r) < .1f) returnFlickers[0] = (returnFlickers[0] + 1) % flickerThroughColors.Count;
		
		currentColor.g = Mathf.Lerp(currentColor.g, flickerThroughColors[returnFlickers[1]].g, perChannelFlickerRates.y * Time.deltaTime);
		if(Mathf.Abs(flickerThroughColors[returnFlickers[1]].g - currentColor.g) < .1f) returnFlickers[1] = (returnFlickers[1] + 1) % flickerThroughColors.Count;
		
		currentColor.b = Mathf.Lerp(currentColor.b, flickerThroughColors[returnFlickers[2]].b, perChannelFlickerRates.z * Time.deltaTime);
		if(Mathf.Abs(flickerThroughColors[returnFlickers[2]].b - currentColor.b) < .1f) returnFlickers[2] = (returnFlickers[2] + 1) % flickerThroughColors.Count;
		
		currentColor.a = Mathf.Lerp(currentColor.a, flickerThroughColors[returnFlickers[3]].a, perChannelFlickerRates.w * Time.deltaTime);
		if(Mathf.Abs(flickerThroughColors[returnFlickers[3]].a - currentColor.a) < .1f) returnFlickers[3] = (returnFlickers[3] + 1) % flickerThroughColors.Count;
		
		gameObject.GetComponent<SpriteRenderer>().color = currentColor;
	}
}
