using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI lives;
    // Update is called once per frame
    void Update()
    {
        lives.text = PlayerStats.Lives+"Lives";
    }
}
