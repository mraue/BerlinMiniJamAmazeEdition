using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlinkTween : MonoBehaviour
{
	public float alphaMin = 0.1f;
	public float alphaMax = 1f;
	public float duration = 1f;

	void Awake()
	{
		var canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = alphaMin;
		canvasGroup.DOFade(alphaMax, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
	}
}
