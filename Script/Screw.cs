using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
	public ScrewController screwController;
	public List<Vector3> targetPositions;
	private void Start()
	 {
		targetPositions = new List<Vector3>() {transform.position};
	}
	private void OnMouseDown() 
	{
		//if(screwController.selectedScrew == this)
		//{
		//	Close(transform.position);
		//	screwController.selectedScrew = null;
		//}
		if(screwController.selectedScrew == null)
		{
			screwController.selectedScrew = this;
			Open();
		}
		
	}
	private void Update() 
	{
		
		if(targetPositions.Count >0)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, targetPositions[0], Time.deltaTime*8);
			if(targetPositions[0].x > transform.position.x-0.2f && targetPositions[0].x < transform.position.x+0.2f && targetPositions[0].y > transform.position.y-0.2f && targetPositions[0].y < transform.position.y+0.2f && targetPositions[0].z > transform.position.z-0.2f && targetPositions[0].z < transform.position.z+0.2f)
			{
				targetPositions.RemoveAt(0);
			}
		}
	}
	public void Close(Vector3 targetPositionNew)
	{
		targetPositions.Add(targetPositionNew);
		targetPositions.Add(new Vector3(targetPositionNew.x,targetPositionNew.y, -15));
		screwController.selectedScrew = null;
	}
	public void ForceStop()
	{
		targetPositions = new List<Vector3>() {transform.localPosition};
		screwController.selectedScrew = null;
		Debug.Log("Force stopped");
	}
	public void Open()
	{
		targetPositions.Add(new Vector3(transform.localPosition.x, transform.localPosition.y, -5));
	}
}
