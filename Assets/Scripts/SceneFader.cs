using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {
	public float speed;
	public AnimationCurve curve;
	public Image img;

	void Start() {
		StartCoroutine(FadeIn());
	}
	public void FadeTo(string sceneName) {
		StartCoroutine(FadeOut(sceneName));
	}

	IEnumerator FadeIn() {
		float time = 1f;
		float alpha;
		while(time > 0f) {
			time -= Time.deltaTime;
			alpha = curve.Evaluate(time);
			img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
			yield return 0;
		}
	}
	IEnumerator FadeOut(string sceneName) {
		float time = 0f;
		float alpha;
		while(time < 1f) {
			time += Time.deltaTime;
			alpha = curve.Evaluate(time);
			img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
			yield return 0;
		}

		SceneManager.LoadScene(sceneName);
	}
}
