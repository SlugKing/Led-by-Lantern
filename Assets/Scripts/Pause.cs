using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	private bool paused = false;
	public GameObject pausescreen;
	public GameObject controls;
	public GameObject fader_parent;
	public GameObject fader;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused && Input.GetKeyDown(KeyCode.Escape))
		{
			pausescreen.transform.SetAsLastSibling();
			pausescreen.SetActive(true);
			AudioListener.volume = 0.3f;
			controls.GetComponent<UnityEngine.UI.Text>().color = new Color(255, 255, 255, 0);
			Time.timeScale = 0;
			paused = true;
		}
		else if (paused && Input.GetKeyDown(KeyCode.Escape))
		{
			pausescreen.SetActive(false);
			AudioListener.volume = 1.0f;
			Time.timeScale = 1;
			paused = false;
		}
		else if (paused && Input.GetKeyDown("q"))
		{
			Time.timeScale = 1;
			fader.transform.SetAsLastSibling();
			StartCoroutine(fader_parent.GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Title"));
		}
	}
}
