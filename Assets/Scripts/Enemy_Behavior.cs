using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour {

	public GameObject player;
	public float MoveSpeed;
	private enum EnemyState
	{
		idle,
		moving,
		attacking
	}
	private EnemyState state;
	private IEnumerator stateUpdater;
	private bool canMove;
	private Animator anim;
	public GameObject enemy_1_attack;
	private GameObject current_attack;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		state = EnemyState.idle;
		stateUpdater = ChangeState();
		StartCoroutine(stateUpdater);
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove)
		{
			if (state == EnemyState.attacking && (transform.position - player.transform.position).magnitude <= 5.0f)
			{
				anim.SetTrigger("attack");
				state = EnemyState.idle;
			}
			transform.LookAt(player.transform);
			transform.Rotate(new Vector3(0, transform.eulerAngles.y, 0) - transform.eulerAngles); // this prevents rigidbody tipping
			if (state == EnemyState.moving)
			{
				transform.position += new Vector3(MoveSpeed*Time.deltaTime*transform.forward.x, 0, MoveSpeed*Time.deltaTime*transform.forward.z);
				anim.SetFloat("move_speed", MoveSpeed);
			}
			else
			{
				anim.SetFloat("move_speed", 0);
			}
		}
	}
	
	IEnumerator ChangeState()
	{
		for(;;)
		{
			var values = System.Enum.GetValues(typeof(EnemyState));
			state = (EnemyState)values.GetValue((int)(Random.value*values.Length));
			int secWait = (int)(Random.value*5);
			yield return new WaitForSeconds(0.75f*secWait);
		}
	}

	public void killMovement()
	{
		canMove = false;
	}
	
	public void SpawnAttack()
	{
		current_attack = Instantiate(enemy_1_attack, transform.position + (1.0f*transform.up) + (1.0f*transform.forward), transform.rotation);
		current_attack.transform.parent = transform;
	}
	
	public void EndAttack()
	{
		Destroy(current_attack);
	}
}
