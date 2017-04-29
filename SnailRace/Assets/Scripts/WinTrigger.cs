using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinTrigger : MonoBehaviour
{
	public UnityEvent onWin;

	bool _won;

	public void Reset()
	{
		_won = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.gameObject.GetComponent<SnailTrigger>() && !_won)
		{
			onWin.Invoke();
			_won = true;
		}
	}
}