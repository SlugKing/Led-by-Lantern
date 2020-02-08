using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToTitle : MonoBehaviour {

	public GameObject camera;
	public GameObject title;
	//private Vector3 titledir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camera != null)
		{
			camera.transform.Rotate(0, (0-camera.transform.eulerAngles.y)*5.0f*Time.deltaTime, 0, Space.World);
			//Debug.Log(camera.transform.eulerAngles.y);
			if (camera.transform.eulerAngles.y >= 360.0)
			{
				camera = null;
			}
			//camera.transform.rotation = Quaternion.LookRotation(rot);
		}
	}
	
	public void Switch()
	{
		camera = GameObject.Find("Main Camera");
		camera.GetComponent<SwitchToTitle>().camera = camera;
		camera = null;
		//titledir = camera.transform.forward*-1.0f;
		title.SetActive(true);
		GameObject.Find("Leaderboard").SetActive(false);
	}
}
