using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequireName : MonoBehaviour {

	public UnityEngine.UI.Text name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (name.text == "")
		{
			GetComponent<UnityEngine.UI.Button>().interactable = false;
		}
		else
		{
			GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
	}
}
