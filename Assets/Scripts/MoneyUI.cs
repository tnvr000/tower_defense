using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {
	public Text MoneyText;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		MoneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
