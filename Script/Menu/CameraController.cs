using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMenu : MonoBehaviour
{
	public Vector2 borders;
	private Vector3 targetPosition;
	public Transform light; 
	public bool listenForTouches = true;
	private void Start() {
		Application.targetFrameRate = 120;
		targetPosition = transform.position;
		DynamicGI.UpdateEnvironment();
	}
	public void Update()
	{
		light.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(50, -30)), Quaternion.Euler(new Vector3(-10, -30)), transform.position.z/borders.y);
		if(listenForTouches &&  Input.touchCount > 0)
		{
			Touch t = Input.GetTouch(0);
			Vector3 b = new Vector3();
			if(targetPosition.z < borders.y)
			{
				if(t.deltaPosition.x < 0)
				{
					b.z = -t.deltaPosition.x/16;
				}
				if(t.deltaPosition.y < 0)
				{
					b.z = -t.deltaPosition.y/8;
				}
			}
			if(targetPosition.z > borders.x)
			{
				if(t.deltaPosition.x > 0)
				{
					b.z = -t.deltaPosition.x/16;
				}
				if(t.deltaPosition.y > 0)
				{
					b.z = -t.deltaPosition.y/8;
				}
			}
			
			targetPosition += b;
		}
		if(targetPosition.z < borders.x) targetPosition.z = borders.x;
		if(targetPosition.z > borders.y) targetPosition.z = borders.y;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*3);
	}
}
