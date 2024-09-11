using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text healthDisplay;

    // 接收健康变化的方法  
    public void UpdateHealthDisplay(int newHealth)
    {
        if (healthDisplay = null)
        {
            healthDisplay.text = "Health: " + newHealth.ToString();
        }
    }

   
}
