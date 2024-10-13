using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Vector2 maxChanges;
	
	public Vector3 mouseStartPosition;
	public float scale = 0.2f;
	public List<GameObject> holes;
	public float distToRotate = 40;
	private void Start()
	{
		holes = new List<GameObject>(GameObject.FindGameObjectsWithTag("SCREW"));
	}
	private void Update() 
	{
		Transform nearestHole = null;
		float minDist = float.MaxValue;
		foreach(GameObject h in holes)
		{
			float dist = Vector3.Distance(transform.position, h.transform.position);
			if(dist < minDist)
			{
				minDist = dist;
				nearestHole = h.transform;
			} 
		}
		if(Camera.main.orthographicSize <distToRotate)
		{
			GetComponent<OrbitCamera>().enabled = true;
			GetComponent<OrbitCamera>().target = nearestHole;
		}
		else
		{
			if(transform.rotation != Quaternion.Euler(new Vector3(0,180,0)))
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,180,0)), Time.deltaTime);
				GetComponent<OrbitCamera>().currentRotation = new Vector3(0,180,0);
			}
			GetComponent<OrbitCamera>().enabled = false;
			if(Input.touchCount>0)
			{
				Touch t = Input.GetTouch(0);
				transform.position+=new Vector3(t.deltaPosition.x, -t.deltaPosition.y)*scale;
			}
			if(transform.position.x >maxChanges.x) transform.position = new Vector3(maxChanges.x,transform.position.y,transform.position.z);
			if(transform.position.x <-maxChanges.x) transform.position = new Vector3(-maxChanges.x,transform.position.y,transform.position.z);
			if(transform.position.y >maxChanges.y) transform.position = new Vector3(transform.position.x,maxChanges.y,transform.position.z);
			if(transform.position.y <-maxChanges.y) transform.position = new Vector3(transform.position.x,-maxChanges.y,transform.position.z);
		}
	}
	
}
