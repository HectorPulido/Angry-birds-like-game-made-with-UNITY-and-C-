using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour {

	public float resistance;
	public GameObject marioExplosion;

	void OnCollisionEnter2D(Collision2D col)
	{
		print (col.relativeVelocity.magnitude);

		if (col.relativeVelocity.magnitude > resistance) {
			var m = Instantiate (marioExplosion, 
				transform.position, 
				Quaternion.identity);
			Destroy (m, 5);

			Destroy (gameObject, 0.1f);	
		} else {
			resistance -= col.relativeVelocity.magnitude;
		}

	}
}
