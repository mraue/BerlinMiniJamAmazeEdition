using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
	public float speedIncrease = 0.03f;
	public float friction = 0.05f;

	public Image image;

	public float currentSpeed;
	float _currentFriction;
	float _idleTime;

	public void OnSpeedIncrease()
	{
		currentSpeed += speedIncrease;
		currentSpeed = Mathf.Min(1f, currentSpeed);
		_currentFriction = 0.3f * friction + 0.7f * currentSpeed * friction;
		_idleTime = 0f;
	}

	void Update()
	{
		currentSpeed -= _currentFriction * Time.deltaTime;
		currentSpeed = Mathf.Max(0f, currentSpeed);
		image.fillAmount = currentSpeed;
		if (_idleTime > 1f)
		{
			_currentFriction = friction * 3f;
		}
	}
}