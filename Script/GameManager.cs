using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
	public int currentPoints;
	public TMP_Text currentPointsText;
	private void Update() {
		currentPointsText.text = currentPoints.ToString();
	}
	private void Start() {
		Application.targetFrameRate = 120;
	}
}
