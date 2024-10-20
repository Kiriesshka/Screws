using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrewController : MonoBehaviour
{
    public MenuScrew selectedScrew;
	
	public void Close(Vector3 targetPosition)
	{
		if(selectedScrew==null)return;
		selectedScrew.Close(targetPosition);
	}
}
