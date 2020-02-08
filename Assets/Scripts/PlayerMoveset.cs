using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveset : MonoBehaviour {

	private Animator anim;
	public GameObject light_punch;
	public GameObject combo_swing;
	private GameObject current_attack;
	private GameObject current_combo;
	private bool canAttack;
	private bool canCombo;
	public GameObject pgrave;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		canAttack = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canAttack && !canCombo)
		{
			if (Input.GetKeyDown("p"))
			{
				anim.SetTrigger("basic_punch");
			}
			else if (Input.GetKeyDown("o"))
			{
				anim.SetTrigger("combo_swing");
			}
		}
		if (canCombo)
		{
			if (Input.GetKeyDown("o"))
			{
				anim.SetTrigger("combo_swing");
			}
		}
	}
	
	public void SpawnLightPunch()
	{
		current_attack = Instantiate(light_punch, transform.position + (1.0f*transform.up) + (1.0f*transform.forward), transform.rotation);
		current_attack.transform.parent = transform;
		current_attack.GetComponent<PlayerAttack>().pgrave = pgrave;
	}
	
	public void SpawnLightCombo()
	{
		current_combo = Instantiate(combo_swing, transform.position + (1.0f*transform.up) + (1.0f*transform.forward), transform.rotation);
		current_combo.transform.parent = transform;
		current_combo.GetComponent<PlayerAttack>().pgrave = pgrave;
	}
	
	public void EndAttack()
	{
		if (current_attack != null)
		{
			current_attack.GetComponent<PlayerAttack>().detachParticles();
			Destroy(current_attack);
		}
		if (current_combo != null)
		{
			current_combo.GetComponent<PlayerAttack>().detachParticles();
			Destroy(current_combo);
		}
	}
	
	public void AllowCombo()
	{
		canCombo = true;
	}
	
	public void PreventCombo()
	{
		canCombo = false;
	}
	
	public void PreventAttack()
	{
		canAttack = false;
	}
	
	public void AllowAttack()
	{
		canAttack = true;
	}
}
