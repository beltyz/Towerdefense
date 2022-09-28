using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //public TurretBlueprint standartTurret;
    public TurretBlueprint anotherTurret;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    //public  void SelectStandartTurret()
    //{
    //    Debug.Log("Standart Turret Purchased");
    //    buildManager.SelectTurretToBuild(standartTurret);
    //}
    public  void SelectAnotherTurret()
    {
        Debug.Log("Another Turret Purchased");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("laser Beamer Purchased");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
