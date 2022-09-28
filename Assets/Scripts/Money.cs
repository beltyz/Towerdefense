using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Update is called once per frame
    void Update()
    {
        moneyText.text ="$" +PlayerStats.Money.ToString();
    }
}
