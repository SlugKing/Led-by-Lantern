using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPlayerAnim : MonoBehaviour {

	private Animator anim;
	public GameObject goalbox;
	public EnemySpawner spawner;
	private int winAnimStage = 0;
	private Vector3 originalForward;
	private bool notWon = true;
	public GameObject player;
	// Use this for initialization
	void Start () {
		originalForward = transform.forward;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		notWon = player.GetComponent<PlayerMove>().notWon;
		if (!notWon)
		{
			if (winAnimStage == 0)
			{
				Vector3 rot = Vector3.RotateTowards(transform.forward, originalForward, 5.0f*Time.deltaTime, 0);
				transform.rotation = Quaternion.LookRotation(rot);
				if (transform.forward == originalForward)
				{
					winAnimStage += 1;
				}
			}
			else
			{
				anim.SetTrigger("win");
				winAnimStage += 1;
			}
		}
	}

}
