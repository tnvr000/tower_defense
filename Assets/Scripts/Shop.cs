using UnityEngine;

public class Shop : MonoBehaviour {
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissleLauncher;
    public TurretBlueprint LaserBeamer;
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("standard turret selected.");
        buildManager.SelectTurretToBuild(StandardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missle launcher selected.");
        buildManager.SelectTurretToBuild(MissleLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected.");
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
