using UnityEngine;
using UnityEngine.EventSystems; 

public class Node : MonoBehaviour {

	public Color hoverColour;
    public Color notEnoughMoneyColor;
	public Vector3 turretPositionOffset;
    [Header("Optional")]
	public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;
	private Color startColour;
	private Renderer rend;

    BuildManager buildManager;

	void Start () {
		rend = this.GetComponent<Renderer>();
		startColour = rend.material.color;

        buildManager = BuildManager.instance;
	}
	void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColour;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
	}
	void OnMouseExit() {
		rend.material.color = startColour;
	}
	void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

		if (turret != null) {
			buildManager.SelectNode(this);
			return;
		}

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
	}
    void BuildTurret(TurretBlueprint turretBlueprint)
    {
        if (PlayerStats.Money < turretBlueprint.cost)
        {
            Debug.Log("Not enough money to build the turret");
            return;
        }
        GameObject turret =  (GameObject)Instantiate(turretBlueprint.prefab, this.GetBuildPsotion(), Quaternion.identity);
        GameObject buildEffect = (GameObject)Instantiate(buildManager.buildEffect, this.GetBuildPsotion(), Quaternion.identity);
        Destroy(buildEffect, 3f);

        this.turret = turret;
        this.turretBlueprint = turretBlueprint;

        PlayerStats.Money -= turretBlueprint.cost;

        Debug.Log("Turret to build");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {   
            Debug.Log("Not enough money to upgrade the turret");
            return;
        }

        //GetBuildPsotion rid of the old turret
        Destroy(this.turret);

        //building a new one
        GameObject turret =  (GameObject)Instantiate(turretBlueprint.upgradePrefab, this.GetBuildPsotion(), Quaternion.identity);
        GameObject buildEffect = (GameObject)Instantiate(buildManager.buildEffect, this.GetBuildPsotion(), Quaternion.identity);
        Destroy(buildEffect, 3f);
        this.turret = turret;
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        isUpgraded = true;
        Debug.Log("Turret Upgraded");

    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject sellEffect = (GameObject)Instantiate(buildManager.sellEffect, this.GetBuildPsotion(), Quaternion.identity);
        Destroy(sellEffect, 3f);
        Destroy(turret);
        turretBlueprint = null;

    }
    public Vector3 GetBuildPsotion()
    {
        return transform.position + turretPositionOffset;
    }
}
