using UnityEngine;

public class SnailController : MonoBehaviour
{
	public float speedMax = 100f;
	public GameObject wheelContainer;
	public SpeedController speedController;

	WheelJoint2D[] _wheels;

	void Awake()
	{
		_wheels = wheelContainer.GetComponents<WheelJoint2D>();
	}

	void Update()
	{
        SetSpeed(-1f * speedController.currentSpeed * speedMax);
        //SetSpeed(-1f * speedMax);
	}

	void SetSpeed(float speed)
	{
		foreach (var wheel in _wheels)
		{
			var motor = wheel.motor;	
			motor.motorSpeed = speed;
			wheel.motor = motor;
			wheel.useMotor = Mathf.Abs(speed) > 0.1f;
		}
	}
}