using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text healthDisplay;

    // ���ս����仯�ķ���  
    public void UpdateHealthDisplay(int newHealth)
    {
        if (healthDisplay = null)
        {
            healthDisplay.text = "Health: " + newHealth.ToString();
        }
    }

   
}
