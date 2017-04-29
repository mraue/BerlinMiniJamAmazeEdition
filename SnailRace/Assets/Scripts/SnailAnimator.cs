using System;
using UnityEngine;

public class SnailAnimator : MonoBehaviour
{
	public float minSpeed;
	public SpeedController speedController;
	bool _isAnimating;

	void Updated()
	{
		if (speedController.currentSpeed < minSpeed && _isAnimating)
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
		
	}

	void StartAnimation()
	{
		
	}
}