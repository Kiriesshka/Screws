using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank_Middle : MonoBehaviour
{
	public float scaleRight = 1;
	public float scaleLeft = 1;
	public float mod;
	public float mod1;
	public Transform right;
	public Transform left;
	public Transform middleLeft;
	public Transform middleRight;
	public Transform middle;

	public void Make()
	{
		middleRight.localScale = new Vector3(scaleRight, 4,2);
		middleRight.localPosition = middle.localPosition + new Vector3(scaleRight/2-mod1,0,0);
		right.localPosition = middleRight.localPosition + new Vector3(scaleRight/2-mod,0,0);
		
		middleLeft.localScale = new Vector3(scaleLeft, 4,2);
		middleLeft.localPosition = middle.localPosition + new Vector3(-scaleLeft/2+mod1,0,0);
		left.localPosition = middleLeft.localPosition + new Vector3(-scaleLeft/2+mod,0,0);
		
	}
	
}
