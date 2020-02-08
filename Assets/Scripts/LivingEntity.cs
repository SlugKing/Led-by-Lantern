using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {
	
	public Hurtbox hurtbox;
	private Animator anim;
	public EnemySpawner es;
	public ParticleSystem particles;
	public GameObject pgrave;
	private bool isAlive;
	private IEnumerator killer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		isAlive = true;
		killer = killDelay();
	}
	
	// Update is called once per frame
	void Update () {
		if (hurtbox.hp <= 0 && isAlive)
		{
			isAlive = false;
			anim.SetTrigger("dead"); // run the death animation
			StartCoroutine(killer);
		}
	}
	
	public void kill() // completely destroys. called from death animations
	{
		if (!hurtbox.isPlayer)
		{
			PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
		}
		var originalScale = particles.transform.localScale;
		particles.transform.SetParent(pgrave.transform, true);
		particles.transform.localScale = originalScale;
		particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		es.enemyCount -= 1;
		Destroy(gameObject);
	}
	
	IEnumerator killDelay()
	{
		yield return new WaitForSeconds(3.0f);
		StartCoroutine(GameObject.Find("Main Camera").GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Leaderboard"));
	}
}
