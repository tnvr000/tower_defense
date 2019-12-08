﻿using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour {
	public SceneFader fader;
	public Button[] levelButtons;

	void Start() {
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);
		for (int i = levelReached; i < levelButtons.Length; i++)
		{
			levelButtons[i].interactable = false;
		}
	}
	public void Select (string levelName) {
		fader.FadeTo(levelName);
	}
}
