using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeInputController : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown("t"))
		{
			Debug.Log("Test");
		}
	}
}
