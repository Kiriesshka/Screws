using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3DButton : MonoBehaviour
{
	public string state;
	public int levelId;
	
	private Vector3 startPosition;
	private Vector3 parentStartPosition;
	private Vector2 startMousePosition;
	public List<Color> colorStages;
	public string levelName;
	public string levelTime;
	public string levelStars;
	private void Start()
	{
		startPosition = transform.localPosition;
		parentStartPosition = transform.parent.localPosition;
	}
	// private void OnMouseEnter() {
	// 	state = "WAIT";
	// }
	// private void OnMouseExit() 
	// {
	// 	state = "NOTHING";
		
	// }
	// private void OnMouseDown() 
	// {
	// 	state = "PUSHED";
	// }
	
	private void Update()
	{
		
		if(Input.GetMouseButtonUp(0))
		{
			// if(state == "PUSHED")
			// {
			// 	GetComponent<LoadScene>().Load(levelId);
			// }
			if(state == "PUSHED" || state == "WAIT")
			{
				Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
				if(Input.mousePosition.x > sp.x - 50 && Input.mousePosition.x < sp.x +50 && Input.mousePosition.y > sp.y - 50 && Input.mousePosition.y <sp.y+50)
				{
					GetComponent<LoadScene>().Load(levelId);
				}
			}
			
			//state = "NOTHING";
		}
		else if(state == "PUSHED")
		{
			if(transform.localPosition != startPosition-new Vector3(0, transform.localScale.y/1.2f))
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition-new Vector3(0, transform.localScale.y/1.7f), Time.deltaTime*2);
				transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, parentStartPosition-new Vector3(0, transform.parent.localScale.y/1.2f), Time.deltaTime*2);
				transform.parent.GetComponent<Renderer>().material.color = Color.Lerp(transform.parent.GetComponent<Renderer>().material.color, colorStages[2], Time.deltaTime*2);
			}
		}
		else if(state == "WAIT")
		{
			if(transform.localPosition != startPosition-new Vector3(0, transform.localScale.y/1.2f))
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition-new Vector3(0, transform.localScale.y/3f), Time.deltaTime*2);
				transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, parentStartPosition-new Vector3(0, transform.parent.localScale.y/4f), Time.deltaTime*2);
				transform.parent.GetComponent<Renderer>().material.color = Color.Lerp(transform.parent.GetComponent<Renderer>().material.color, colorStages[1], Time.deltaTime*2);
			}
		}
		else if (state == "NOTHING")
		{
			if(transform.localPosition != startPosition)
			{
				transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime*2);
				transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, parentStartPosition, Time.deltaTime*2);
				transform.parent.GetComponent<Renderer>().material.color = Color.Lerp(transform.parent.GetComponent<Renderer>().material.color, colorStages[0], Time.deltaTime*2);
			}
		}
	}
}
