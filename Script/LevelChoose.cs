using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using KiriesshkaData;
public class LevelChoose : MonoBehaviour
{
	public int currentIndex = 1;
	public int maxIndex;
	public TMP_Text levelIndex;
	private void Start()
	{
		levelIndex.text = currentIndex.ToString();
		Application.targetFrameRate = 120;
		
	}
	public void MinusIndex()
	{
		currentIndex--;
		if(currentIndex <1) currentIndex = maxIndex;
		levelIndex.text = currentIndex.ToString();
	}
	public void PlusIndex()
	{
		currentIndex++;
		if(currentIndex > maxIndex) currentIndex = 1;
		levelIndex.text = currentIndex.ToString();
	}
   	public void Load()
   	{
		SceneManager.LoadScene(currentIndex);
   	}
}
