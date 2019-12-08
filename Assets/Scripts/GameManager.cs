using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool IsGamOver;
	public string nextLevelName = "Level002";
	public int levelToUnlock = 2;
	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	void Start() {
		IsGamOver = false;
	}
	void Update() {
		if(IsGamOver)
			return;
		if(PlayerStats.Lives <= 0) {
			GameOver();
		}
	}

	private void GameOver() {
		IsGamOver = true;
		gameOverUI.SetActive(true);
	}

	public void LevelComplete() {
		IsGamOver = true;	
		completeLevelUI.SetActive(true);
	}
}
