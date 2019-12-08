using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public SceneFader sceneFader;
	public string mainMenuName;
	public void Retry() {
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu() {
		sceneFader.FadeTo(mainMenuName);
	}
}
