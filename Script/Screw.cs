using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
	public ScrewController screwController;
	public List<Vector3> targetPositions;
	public float timeToStartListenForceStop = 0.5f;
	public float timeToStartListenForceStopReference = 0.5f;
	public float targetOpenZ = -5;
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
			timeToStartListenForceStop = timeToStartListenForceStopReference;
		}
		
	}
	private void Update() 
	{
		if(timeToStartListenForceStop > 0)
		{
			timeToStartListenForceStop -=Time.deltaTime;
		}
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
		if(timeToStartListenForceStop <=0)
		{
			targetPositions = new List<Vector3>() {transform.localPosition};
			screwController.selectedScrew = null;
			Debug.Log("Force stopped");
		}
	}
	public void Open()
	{
		targetPositions.Add(new Vector3(transform.localPosition.x, transform.localPosition.y, targetOpenZ));
	}
}
