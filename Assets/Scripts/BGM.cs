using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

	public AudioClip[] music = new AudioClip[5];
	private AudioSource[] sources = new AudioSource[3];
	private float nextEvt;
	private bool inloop;
	private float songchoice;
	// Use this for initialization
	void Start () {
		songchoice = Random.value;
		inloop = false;
		for (int i = 0; i < sources.Length; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
			sources[i].volume = 0.2f;
        }
		if (songchoice < 0.5)
		{
			sources[0].clip = music[0];
			nextEvt = (float)AudioSettings.dspTime + music[0].length;
			sources[0].PlayScheduled(AudioSettings.dspTime);
			
		}
		else
		{
			sources[0].clip = music[3];
			nextEvt = (float)AudioSettings.dspTime + music[3].length;
			sources[0].PlayScheduled(AudioSettings.dspTime);
		}
		sources[2].volume = 0.05f;
		sources[2].clip = music[2];
		sources[2].loop = true;
		sources[2].PlayScheduled(AudioSettings.dspTime);
	}
	
	// Update is called once per frame
	void Update () {
		float time = (float)AudioSettings.dspTime;
		if (time+1.0f > nextEvt && !inloop)
		{
			if (songchoice < 0.5)
			{
				inloop = true;
				sources[1].clip = music[1];
				sources[1].loop = true;
				sources[1].PlayScheduled(nextEvt);
			}
			else
			{
				inloop = true;
				sources[1].clip = music[4];
				sources[1].loop = true;
				sources[1].PlayScheduled(nextEvt);
			}
		}
	}
}
