using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHoleController : MonoBehaviour
{
   public bool isOpened;
	public MenuScrewController screwController;
	public void OnMouseDown() 
	{
		if(isOpened)
		{
			screwController.Close(new Vector3(transform.localPosition.x, screwController.selectedScrew.GetComponent<MenuScrew>().targetOpenY, transform.position.z));	
		}
	}
}
