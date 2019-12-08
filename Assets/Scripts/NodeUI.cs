using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour {
	public GameObject UI;
	public Text upgradeCost;
	public Text sellAmount;
	public Button upgradeButton;
	private Node target;
	public void SetTarget(Node target)
	{
		this.target = target;
		if(target.isUpgraded)
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		} else
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost ;
			upgradeButton.interactable = true;
		}
		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
		transform.position = target.GetBuildPsotion();
		UI.SetActive(true);
	}

	public void Hide()
	{
		UI.SetActive(false);
	}

	public void Upgrade() 
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}
	public void Sell()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
