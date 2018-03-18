using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour 
{
	public Transform anchor;
	public float springRange;
	public float maxVel;

	bool canDrag = true;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();	

		transform.position = anchor.position;
	}


	Vector3 Dir;
	void OnMouseDrag()
	{
		if (!canDrag)
			return;
		var Pos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //Posicion del mouse
		Dir = Pos - anchor.position; // hacia donde mira pajarito

		Dir.z = 0;

		if (Dir.magnitude > springRange) 
		{
			Dir = Dir.normalized * springRange;		
		}

		transform.position = anchor.position + Dir;

	}
	void OnMouseUp() 
	{
		if (!canDrag)
			return;
		canDrag = false;

		rb.bodyType = RigidbodyType2D.Dynamic;

		rb.velocity = - Dir.normalized * maxVel * Dir.magnitude / springRange;
	}
		
}
