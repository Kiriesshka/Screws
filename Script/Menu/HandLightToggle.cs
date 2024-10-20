using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandLightToggle : MonoBehaviour
{
	public GameObject lamp;
	private void OnMouseDown() {
		lamp.SetActive(!lamp.activeSelf);
	}
}
