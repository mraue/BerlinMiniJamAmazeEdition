using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
	public float idleDurationThreshold = 4f;
	float _idleDuration;

	public GameObject hintContainer;

	public void OnUserActivity()
	{
		_idleDuration = 0f;
	}

	void Update()
	{
		_idleDuration += Time.deltaTime;
		hintContainer.SetActive(_idleDuration > idleDurationThreshold);
	}
}
