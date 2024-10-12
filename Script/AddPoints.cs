using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
	public GameManager gameManager;
	private void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "PLANK")
		{
			gameManager.currentPoints += 1;
			Destroy(other.gameObject);
		}
	}
}
