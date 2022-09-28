using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public TextMeshProUGUI upgrade;
    public GameObject ui;
    public Button UpgradeButton;
    public TextMeshProUGUI Sell_Amount;

    public void SetTarget(Node _target)
    {
        target=_target;

        transform.position=target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgrade.text = "$" + target.turretBlueprint.upgradeCost;
            UpgradeButton.interactable = true;
        }
        else
        {
            upgrade.text = "Done";
            UpgradeButton.interactable = false;
        }
        Sell_Amount.text="$"+target.turretBlueprint.GetSellAmount();
       
       
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }


    public void Uprgade()
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
