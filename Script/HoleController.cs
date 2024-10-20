using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
	public bool isOpened;
	public ScrewController screwController;
	public void OnMouseDown() 
	{
		if(isOpened)
		{
			screwController.Close(new Vector3(transform.localPosition.x, transform.localPosition.y, screwController.selectedScrew.GetComponent<Screw>().targetOpenZ));	
		}
	}
}
