using System;
using UnityEngine;

public class SnailAnimator : MonoBehaviour
{
	public float minSpeed = 0.1f;
	public SpeedController speedController;
	public Animator animator;

	bool _isAnimating;

	void Update()
	{
		if (speedController.currentSpeed <= minSpeed && _isAnimating)
		{
			StopAnimation();
		}
		else if (!_isAnimating)
		{
			StartAnimation();
		}
	}

	void StopAnimation()
	{				
		animator.enabled = false;
		_isAnimating = false;
	}

	void StartAnimation()
	{		
		animator.enabled = true;
		_isAnimating = true;
	}
}