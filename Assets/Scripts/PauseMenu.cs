using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public SceneFader sceneFader;
	public string mainMenuName;
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		if (pauseMenu.activeSelf)
		{
			Time.timeScale = 0f;
		} else
		{
			Time.timeScale = 1f;
		}
	}
	public void Retry()
	{
		TogglePause();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}
	public void Menu()
	{
		TogglePause();
		sceneFader.FadeTo(mainMenuName);
	}
}
