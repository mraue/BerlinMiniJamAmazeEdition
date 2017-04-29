using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TypeInputController : MonoBehaviour
{
	public const string BOOK_PATH = "Texts/sisyphus";
	public const string HIGHLIGHTED_CHARACTER = "<color=magenta>{0}</color>";
	int AMOUNT_RANDOM_CHARACTERS_PER_LINE = 1;

	public Text label;
	public UnityEvent onCharacterTyped;

	StringReader _reader;

	int _currentIndex;
	string _line;
	string _currentCharacter;
	string _displayLine;

	TextAsset _asset;

	int _amountLines;

	void Awake()
	{
		_asset = Resources.Load(BOOK_PATH) as TextAsset;
		_reader = new StringReader(_asset.text);
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
			_line = _reader.ReadLine();

			if (_line == null)
			{
				_reader = new StringReader(_asset.text);
			}
			else
			{
				_line.Trim();
				RandomizeLine(_amountLines);
				_amountLines += 1;
			}
		}

		_currentIndex = 0;
		label.text = GetFormattedLine(_line, _currentIndex);
	}


	void RandomizeLine(int amount)
	{
		var stringBuilder = new StringBuilder(_line);

		for (int i = 0; i < amount * AMOUNT_RANDOM_CHARACTERS_PER_LINE; i++)
		{
			var first = UnityEngine.Random.Range(0, stringBuilder.Length);
			var second = UnityEngine.Random.Range(0, stringBuilder.Length);
			var tmp = stringBuilder[first];
			stringBuilder[first] = stringBuilder[second];
			stringBuilder[second] = tmp;
		}

		_line = stringBuilder.ToString();
	}

	string GetFormattedLine(string line, int index)
	{
		var character = _line[index];
		character = character == ' ' ? '_' : character;
		return string.Format(HIGHLIGHTED_CHARACTER, _line.Substring(0, index))
			         + character
					+ _line.Substring(index + 1, _line.Length - index - 1);
	}
}