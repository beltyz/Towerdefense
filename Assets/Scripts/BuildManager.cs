using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
  

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogError("MoreThan one Buildmanager in scene");
            return;
        }
        instance = this;
    }


   
    private TurretBlueprint turretToBuild;
    private Node selectNode;
    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

   

    public void SelectNode(Node node)
    {
        if (selectNode==node)
        {
            DeselectNode();
            return;
        }

        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret; 
        DeselectNode();
    }

    public TurretBlueprint GetTurretTOBuild()
    {
        return turretToBuild;
    }
}
