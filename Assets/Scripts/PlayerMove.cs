using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private Animator anim;
	public float MoveSpeed = 1.0f;
	public GameObject goalbox;
	public EnemySpawner spawner;
	private bool canMove;
	private int winAnimStage = 0;
	private Vector3 originalForward;
	public bool notWon = true;
	public AudioClip[] sounds = new AudioClip[5];
	private AudioSource source;
	private int clipNum;
	private GameObject audioGrave;
	private IEnumerator footstepper;
	private bool stepping;
	private IEnumerator winner;
	// Use this for initialization
	void Start () {
		originalForward = transform.forward;
		anim = GetComponent<Animator>();
		canMove = true;
		footstepper = Footsteps();
		winner = winDelay();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove)
		{
			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				anim.SetFloat("move_speed", 1.0f);
				if (!stepping)
				{
					StartCoroutine(footstepper);
					stepping = true;
				}
			}
			else
			{
				anim.SetFloat("move_speed", 0);
				StopCoroutine(footstepper);
				stepping = false;
			}
			transform.position += new Vector3(MoveSpeed*Time.deltaTime*Input.GetAxis("Horizontal"), 0, MoveSpeed*Time.deltaTime*Input.GetAxis("Vertical"));
			Vector3 rot = Vector3.RotateTowards(transform.forward, new Vector3(Mathf.Abs(Input.GetAxis("Horizontal"))*Input.GetAxis("Horizontal"), 0, Mathf.Abs(Input.GetAxis("Vertical"))*Input.GetAxis("Vertical")), 15.0f*Time.deltaTime, 0);
			transform.rotation = Quaternion.LookRotation(rot);
		}
		else
		{
			anim.SetFloat("move_speed", 0);
			StopCoroutine(footstepper);
			stepping = false;
		}
		transform.Rotate(new Vector3(0, transform.eulerAngles.y, 0) - transform.eulerAngles); // this prevents rigidbody tipping
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
	
	void OnTriggerStay(Collider box)
	{
		if (box.name == "GoalBox" && spawner.CanWin() && notWon)
		{
			// win!
			PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+1000);
			StartCoroutine(winner);
			notWon = false;
			canMove = false;
			GetComponent<PlayerMoveset>().PreventAttack();
		}
	}
	
	IEnumerator Footsteps()
	{
		for(;;)
		{
			clipNum = sounds.Length;
			audioGrave = new GameObject("Audio Grave");
			audioGrave.AddComponent<AudioAutoDelete>();
			audioGrave.transform.SetParent(null, false);
			source = audioGrave.AddComponent<AudioSource>();
			AudioClip sound = sounds[(int)(Random.value*clipNum)];
			source.volume = (Random.value*0.1f)+0.25f;
			source.clip = sound;
			source.PlayScheduled(AudioSettings.dspTime);
			yield return new WaitForSeconds(0.25f);
		}
	}
	
	public void StopMovement()
	{
		canMove = false;
	}
	
	public void AllowMovement()
	{
		canMove = true;
	}
	
	IEnumerator winDelay()
	{
		yield return new WaitForSeconds(2.0f);
		StartCoroutine(GameObject.Find("Main Camera").GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Leaderboard"));
	}
}
