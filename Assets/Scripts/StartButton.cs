using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	public GameObject fader_parent;
	public GameObject image;
	void Start () {
		fader_parent.GetComponent<SceneFader>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Switch()
	{
		image.SetActive(true);
		StartCoroutine(fader_parent.GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Game"));
	}
	
	public void UpdateName(string name)
	{
		PlayerPrefs.SetString("CurrPlayer", name);
	}
}
