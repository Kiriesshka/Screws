using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrew : MonoBehaviour
{
    public MenuScrewController screwController;
	public List<Vector3> targetPositions;
	public float timeToStartListenForceStop = 0.5f;
	public float timeToStartListenForceStopReference = 0.5f;
	public float targetOpenY = -5;
	
	private List<GameObject> holes;
	private Transform nearestHole;
	private void Start()
	 {
		targetPositions = new List<Vector3>() {transform.position};
		holes = new List<GameObject>(GameObject.FindGameObjectsWithTag("HOLE"));
	}
	private void OnMouseDown() 
	{
		if(screwController.selectedScrew == null)
		{
			screwController.selectedScrew = this;
			Open();
			timeToStartListenForceStop = timeToStartListenForceStopReference;
		}
		else if(screwController.selectedScrew == this)
		{
			float dist = 99999;
			foreach(GameObject hole in holes)
			{
				float disTMP = Vector3.Distance(hole.transform.position, transform.position);
				if(disTMP < dist)
				{
					nearestHole = hole.transform;
					dist = disTMP;
				}
			}
			if(nearestHole)
			{
				nearestHole.GetComponent<MenuHoleController>().OnMouseDown();
				nearestHole = null;
			}
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
		targetPositions.Add(new Vector3(targetPositionNew.x,-1,targetPositionNew.z));
		//screwController.selectedScrew = null;
	}
	public void ForceStop()
	{
		if(screwController.selectedScrew != this) return;
		if(timeToStartListenForceStop <=0)
		{
			
			targetPositions = new List<Vector3>() {transform.localPosition};
			screwController.selectedScrew = null;
			Debug.Log("FORCE STOPPED!");
		}
	}
	public void Open()
	{
		targetPositions.Add(new Vector3(transform.localPosition.x, targetOpenY,transform.localPosition.z ));
	}
}
