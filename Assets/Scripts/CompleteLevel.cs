using UnityEngine;

public class CompleteLevel : MonoBehaviour {
	public string menuSceneName = "MainMenu";
	public string nextLevel = "Level001";
	public int levelToUnlock = 2;
	public SceneFader sceneFader;
	
	public void Menu () {
		sceneFader.FadeTo(menuSceneName);
	}
	
	
	public void Continue () {
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(nextLevel);
	}
}
