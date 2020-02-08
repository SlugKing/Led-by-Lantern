using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {

	public Vector3 halfbounds;
	public Vector3 relative_center;
	public float hp;
	public bool isPlayer;
	private Animator anim;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		anim = transform.parent.gameObject.GetComponent<Animator>();
		rb = transform.parent.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta - new Color(0, 0, 0, 0.5f);
		Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
		Gizmos.DrawCube(relative_center, new Vector3(halfbounds.x*2, halfbounds.y*2, halfbounds.z*2));
	}
	
	public void damaged(float dmg, Vector3 kb, Transform attacker)
	{
		hp -= dmg;
		anim.SetTrigger("damaged");
		transform.parent.gameObject.transform.LookAt(attacker);
		rb.AddForce(kb, ForceMode.Impulse);
		
	}
}
