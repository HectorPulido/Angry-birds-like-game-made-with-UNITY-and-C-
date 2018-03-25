using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour 
{
	public float resistance;
	public GameObject explosionPrefab;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.magnitude > resistance) {
		
			if (explosionPrefab != null) {
				var go = Instantiate (explosionPrefab, 
					transform.position, 
					Quaternion.identity);
				
			
				Destroy (go, 3);
			}

			Destroy (gameObject, 0.1f);

		} else {
			resistance -= col.relativeVelocity.magnitude;
		
		}

	}
}
