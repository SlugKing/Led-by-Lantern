using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Sounds : MonoBehaviour {

	public AudioClip[] sounds = new AudioClip[2];
	private AudioSource[] sources = new AudioSource[2];
	public GameObject lantern;
	// Use this for initialization
	void Start () {
		sources[0] = lantern.AddComponent<AudioSource>();
		sources[0].loop = true;
		sources[0].clip = sounds[0];
		sources[0].volume = 0.2f;
		sources[0].PlayScheduled(AudioSettings.dspTime);
		
		sources[1] = gameObject.AddComponent<AudioSource>();
		sources[1].loop = true;
		sources[1].clip = sounds[1];
		sources[1].volume = 0.2f;
		sources[1].PlayScheduled(AudioSettings.dspTime);	
	}
	
	// Update is called once per frame
	void Update () {
		sources[0].volume = 0.2f + (0.1f * Mathf.Sin(Time.fixedTime));
		
	}
}
