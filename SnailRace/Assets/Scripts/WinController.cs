using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinController : MonoBehaviour
{
	const float CAMERA_ANIMATION_DURATION = 5f;

	public GameObject content;
	public Camera mainCamera;

	public void OnWin()
	{
		StartCoroutine(Win());
	}

	IEnumerator Win()
	{
		content.SetActive(true);
		mainCamera.DOOrthoSize(18f, CAMERA_ANIMATION_DURATION).SetEase(Ease.Linear);
		mainCamera.transform.DOMoveX(26f, CAMERA_ANIMATION_DURATION).SetEase(Ease.Linear); ;
		mainCamera.transform.DOMoveY(0f, CAMERA_ANIMATION_DURATION).SetEase(Ease.Linear); ;
		yield return new WaitForSeconds(3f);
		content.SetActive(false);
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");
		UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Main");
	}
}