using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartController : MonoBehaviour
{
	public CanvasGroup canvasGroup;

	public void OnStart()
	{
		canvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear).OnComplete(() => { canvasGroup.gameObject.SetActive(false); });
	}
}
