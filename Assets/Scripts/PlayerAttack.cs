using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, HitboxResponder {

	public float damage;
	public float kb;
	public Hitbox hitbox;
	public ParticleSystem particles = null;
	public GameObject pgrave;
	public AudioClip[] clips = new AudioClip[4];
	private int clipNum;
	private AudioSource source;
	private GameObject audioGrave;
	
	public void Start()
	{
		clipNum = clips.Length;
		hitbox.useResponder(this);
		audioGrave = new GameObject("Audio Grave");
		audioGrave.AddComponent<AudioAutoDelete>();
		audioGrave.transform.SetParent(null, false);
		source = audioGrave.AddComponent<AudioSource>();
		source.volume = (Random.value*0.25f)+0.5f;
		AudioClip sound = clips[(int)(Random.value*clipNum)];
		source.clip = sound;
		source.PlayScheduled(AudioSettings.dspTime);
	}
	
	public void collisionedWith(Collider collider)
	{
		Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
		if (hurtbox != null)
		{
			if (hurtbox.isPlayer != hitbox.isPlayer)
			{
				//Vector3 kb_vec = new Vector3(0, 0, 0);
				Vector3 kb_vec = transform.parent.forward * kb;
				hurtbox.damaged(damage, kb_vec, transform.parent);
				if (hitbox.isPlayer && hurtbox.hp >= 0)
				{
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+((int)damage*10));
				}
				else if (!hitbox.isPlayer && hurtbox.hp+damage > 0)
				{
					if (PlayerPrefs.GetInt("Score")-((int)damage*10) <= 0)
					{
						PlayerPrefs.SetInt("Score", 0);
					}
					else
					{
						PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")-((int)damage*10));
					}
				}
			}
		}
	}
	
	public void detachParticles()
	{
		particles.transform.SetParent(pgrave.transform, true);
		particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
	}
}
