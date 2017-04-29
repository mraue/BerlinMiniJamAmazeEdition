using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartController : MonoBehaviour
{
	public CanvasGroup canvasGroup;

	bool _acceptingInput = true;

	public void OnStart()
	{
		if (_acceptingInput)
		{
			_acceptingInput = false;
			canvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear).OnComplete(() => { canvasGroup.gameObject.SetActive(false); });
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnStart();
		}
	}
}
