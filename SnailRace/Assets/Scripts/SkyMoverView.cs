using UnityEngine;

public class SkyMoverView : MonoBehaviour
{
	public float xOffset;
	public float yOffset;
	public float xSpeedMin;
	public float xSpeedMax;
	public float ySpeedMin;
	public float ySpeedMax;

	float _speedX;
	float _speedY;

	void Awake()
	{
		var pos = transform.localPosition;
		pos.x += UnityEngine.Random.Range(-xOffset, xOffset);
		pos.y += UnityEngine.Random.Range(-yOffset, yOffset);
		transform.localPosition = pos;

		_speedX = UnityEngine.Random.Range(xSpeedMin, xSpeedMax);
		_speedY = UnityEngine.Random.Range(ySpeedMin, ySpeedMax);
	}

	void Update()
	{
		var pos = transform.localPosition;
		pos.x += _speedX * Time.deltaTime;
		pos.y += _speedY * Time.deltaTime;
		transform.localPosition = pos;
	}
}