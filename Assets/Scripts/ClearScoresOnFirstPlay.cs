using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScoresOnFirstPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++)
		{
			PlayerPrefs.SetInt("HS"+i.ToString(), -1);
			PlayerPrefs.SetString("HSs"+i.ToString(), "");
			PlayerPrefs.SetInt("HSc"+i.ToString(), 0);
		}
	}
}
