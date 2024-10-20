using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PaperController : MonoBehaviour
{
	public float returnSoft = 5;
	public bool isControlled;
	public CameraControllerMenu cameraController;
	private Vector2 delta;
	private Quaternion targetRotation;
	
	public TMP_Text levelName;
	public TMP_Text levelTime;
	public TMP_Text levelStars;
	
	public List<Transform> levels;
	public Transform nearestButton;
	private GlobalSettings gS;
	
	public void SetLevel(string name, string time, string stars)
	{
		
		levelName.text = name + $"({nearestButton.name})";
		if(gS.language == "ENG")
		{
			if(time.Length == 5) levelTime.text = "Time   " + time;
			if(time.Length == 4) levelTime.text = "Time    " + time; 
			levelStars.text = "Stars     "+ stars+"/3";
		}
		else if(gS.language == "RUS")
		{
			if(time.Length == 5) levelTime.text = "Время  " + time;
			if(time.Length == 4) levelTime.text = "Время   " + time; 
			levelStars.text = "Звезды    "+ stars+"/3";
		}
		
	}
	private void Start()
	{
		gS = GameObject.Find("GLOBALSETTINGS").GetComponent<GlobalSettings>();
		nearestButton = levels[0];
		nearestButton.GetComponent<_3DButton>().state = "WAIT";
		targetRotation = transform.rotation;
	}
	private void Update() 
	{
		if(levels.Count > 0)
		{
			float minDist = Vector3.Distance(transform.position+new Vector3(0,14,-10f), levels[0].position);
			
			Transform newNearest = null;
			foreach(Transform t in levels)
			{
				float dst = Vector3.Distance(transform.position+new Vector3(0,14,-10f), t.position);
				if(dst <= minDist)
				{
					minDist = dst;
					newNearest = t;
					//nearestButton = t.GetComponent<_3DButton>();
				}
			}
			if(newNearest != null)
			{
				if(newNearest != nearestButton)
				{
					nearestButton.GetComponent<_3DButton>().state = "NOTHING";
					nearestButton = newNearest;
					nearestButton.GetComponent<_3DButton>().state = "WAIT";
					SetLevel(nearestButton.GetComponent<_3DButton>().levelName, nearestButton.GetComponent<_3DButton>().levelTime, nearestButton.GetComponent<_3DButton>().levelStars);
				}
			}
		}
		
		if(isControlled)
		{
			if(Input.touchCount == 0) 
			{
				isControlled = false;
				cameraController.listenForTouches = true;
			}
			else
			{
				Touch t = Input.GetTouch(0);
				delta+=t.deltaPosition;
				targetRotation = Quaternion.Euler(new Vector3(30+delta.y/10, -6.5f-delta.x/10));
			}
		}	
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, returnSoft*Time.deltaTime);
	}
	private void OnMouseDown() 
	{
		isControlled = true;
		cameraController.listenForTouches = false;
	}
}
