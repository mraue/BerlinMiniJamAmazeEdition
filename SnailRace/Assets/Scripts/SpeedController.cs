using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
	public float speedIncrease = 0.03f;
	public float friction = 0.05f;

	public Image image;

	public float currentSpeed;

	public void OnSpeedIncrease()
	{
		currentSpeed += speedIncrease;
		currentSpeed = Mathf.Min(1f, currentSpeed);
	}

	void Update()
	{
		currentSpeed -= friction * Time.deltaTime;
		currentSpeed = Mathf.Max(0f, currentSpeed);
		image.fillAmount = currentSpeed;
	}
}