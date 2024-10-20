using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrewHat : MonoBehaviour
{
    public MenuScrew screw;
	private void Start() {
		screw = transform.parent.GetComponent<MenuScrew>();
	}
	private void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "PLANK" || other.transform.tag == "HOLE")
		{
			screw.ForceStop();
		}
	}
	private void OnTriggerEnter(Collider other) 
	{
		if(other.transform.tag == "PLANK" || other.transform.tag == "HOLE")
		{
			screw.ForceStop();
		}
	}

}
