using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartController : MonoBehaviour
{
	public CanvasGroup canvasGroup;
	public Animator poopAnimation;

	bool _acceptingInput = true;

	public void OnStart()
	{
		if (_acceptingInput)
		{
			_acceptingInput = false;
			canvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear).SetDelay(1f).OnComplete(() => { canvasGroup.gameObject.SetActive(false); });
			poopAnimation.enabled = true;
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
