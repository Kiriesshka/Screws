using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
	public bool isOpened;
	public ScrewController screwController;
	private void OnMouseDown() 
	{
		if(isOpened)
		{
			screwController.Close(new Vector3(transform.localPosition.x, transform.localPosition.y, -5));	
		}
	}
}
