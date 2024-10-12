using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlankScaler : MonoBehaviour
{
	public Plank plank;
	
	#if UNITY_EDITOR
	private void Update()
	{
		if (transform.hasChanged)
		{
			plank.scale = transform.localScale.x;
			plank.Make();
			transform.hasChanged = false;
		}
	}
	#endif
}
