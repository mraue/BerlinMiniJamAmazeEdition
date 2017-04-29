using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
	public GameObject content;

	public void OnWin()
	{
		StartCoroutine(Win());
	}

	IEnumerator Win()
	{
		content.SetActive(true);
		yield return new WaitForSeconds(3f);
		content.SetActive(false);
	}
}