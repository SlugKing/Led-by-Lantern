using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutText : MonoBehaviour {

	private IEnumerator fader;
	// Use this for initialization
	void Start () {
		fader = fadeDelay();
		StartCoroutine(fader);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator fadeDelay()
	{
		yield return new WaitForSeconds(5.0f);
		while(gameObject.GetComponent<UnityEngine.UI.Text>().color.a > 0)
		{
			gameObject.GetComponent<UnityEngine.UI.Text>().color = new Color(255, 255, 255, gameObject.GetComponent<UnityEngine.UI.Text>().color.a - (0.50f*Time.deltaTime));
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
