using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndListener : MonoBehaviour
{
	public GameObject winWidnow;
	public GameObject loseWindow;
	public Transform allPlanks;
	private void Update() {
		if(allPlanks.childCount == 0)
		{
			winWidnow.SetActive(true);
			Destroy(this);
		}
	}
}
