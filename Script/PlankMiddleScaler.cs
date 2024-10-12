using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlankMiddleScaler : MonoBehaviour
{
	public Plank_Middle plank;
	public string pos;
	#if UNITY_EDITOR
	private void Update()
	{
		if (transform.hasChanged)
		{
			if(pos == "MR") plank.scaleRight = transform.localScale.x;
			else plank.scaleLeft = transform.localScale.x;
			plank.Make();
			transform.hasChanged = false;
		}
	}
	#endif
}
