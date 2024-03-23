using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	public void LoadMNScene()
	{
		SceneManager.LoadScene(7);
	}
}
