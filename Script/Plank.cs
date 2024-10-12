using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
	public Transform middle;
	public Transform right;
	public Transform left;
	
	public float scale;
	public float mod = 1;
	public void Make()
	{
		middle.transform.localScale = new Vector3(scale, 4,2);
		right.transform.localPosition = middle.transform.localPosition +new Vector3(scale/2-mod,0,0);
		left.transform.localPosition = middle.transform.localPosition +new Vector3(-scale/2+mod,0,0);
	}
	
}
