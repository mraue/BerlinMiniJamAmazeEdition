using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TypeInputController : MonoBehaviour
{
	public const string BOOK_PATH = "Texts/jule_verne_around_the_moon";
	public const string HIGHLIGHTED_CHARACTER = "<b><color=magenta>{0}</color></b>";

	public Text label;
	public UnityEvent onCharacterTyped;

	StringReader _reader;

	int _currentIndex;
	string _line;
	string _currentCharacter;
	string _displayLine;

	void Awake()
	{
		var asset = Resources.Load(BOOK_PATH) as TextAsset;
		_reader = new StringReader(asset.text);
	}

	void Update()
	{
		if (_line == null)
		{
			NextLine();
		}

		if (Input.inputString.ToLower() == _line[_currentIndex].ToString().ToLower())
		{
			onCharacterTyped.Invoke();

			_currentIndex += 1;

			if (_currentIndex < _line.Length - 1)
			{
				label.text = GetFormattedLine(_line, _currentIndex);
			}
			else
			{				
				NextLine();
			}
		}
	}

	void NextLine()
	{
		_line = null;

		while (string.IsNullOrEmpty(_line))
		{			
			_line = _reader.ReadLine().Trim();

			if (_line == null)
			{
				break;
			}
		}

		_currentIndex = 0;
		label.text = GetFormattedLine(_line, _currentIndex);
	}

	string GetFormattedLine(string line, int index)
	{
		var character = _line[index];
		character = character == ' ' ? '_' : character;
		return _line.Substring(0, index)
			        + string.Format(HIGHLIGHTED_CHARACTER, character)
					+ _line.Substring(index + 1, _line.Length - index - 1);
	}
}