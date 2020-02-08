using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface HitboxResponder {
	void collisionedWith(Collider c);
}
public class Hitbox : MonoBehaviour {

	public Vector3 halfbounds; // 
	public enum State
	{
		open,
		collision,
		end
	}
	private State state;
	private HitboxResponder responder = null;
	public bool isPlayer;
	private List<Collider> processed = new List<Collider>();
	
	// Use this for initialization
	void Start () {
		state = State.open;
	}
	
	void Start (Vector3 halfbounds) {
		this.halfbounds = halfbounds;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.end) { return; }
		Collider[] colliders = Physics.OverlapBox(transform.position, halfbounds, transform.rotation, 1 << 11);
		for (int i = 0; i < colliders.Length; i++)
		{
			Collider collide = colliders[i];
			if (responder != null && !processed.Contains(collide))
			{
				responder.collisionedWith(collide);
				processed.Add(collide);
			}
		}
		state = colliders.Length > 0 ? State.collision : State.open;
	}
	
	private void OnDrawGizmos()
	{
		vizColor();
		Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
		Gizmos.DrawCube(Vector3.zero, new Vector3(halfbounds.x*2, halfbounds.y*2, halfbounds.z*2));
	}
	
	public void startCheck()
	{
		state = State.open;
	}
	
	public void stopCheck()
	{
		state = State.end;
	}
	
	private void vizColor()
	{
		switch(state)
		{
			case State.open:
				Gizmos.color = Color.green;
				break;
			case State.collision:
				Gizmos.color = Color.red;
				break;
			case State.end:
				Gizmos.color = Color.yellow;
				break;
		}
		Gizmos.color -= new Color(0, 0, 0, 0.5f);
	}
	
	public void useResponder(HitboxResponder hr)
	{
		responder = hr;
	}
}
