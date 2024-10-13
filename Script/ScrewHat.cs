using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewHat : MonoBehaviour
{
	public Screw screw;
	private void Start() {
		screw = transform.parent.GetComponent<Screw>();
	}
	private void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "PLANK")
		{
			screw.ForceStop();
		}
	}
	private void OnTriggerEnter(Collider other) 
	{
		if(other.transform.tag == "PLANK")
		{
			screw.ForceStop();
		}
	}

}