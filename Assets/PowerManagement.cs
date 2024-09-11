using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PowerManagement : MonoBehaviour
{
    private Image imageComponent;
    public int BatteryCount = Battery.BatteryNumber;

    void Start()
    {
        // 订阅事件  
        Battery.OnBatteryNumberChanged += OnBatteryNumberChanged;
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("No Image component attached to the game object with PowerManagement script.");
        }
        

    }

    void OnDestroy()
    {
        // 取消订阅事件，防止内存泄漏  
        Battery.OnBatteryNumberChanged -= OnBatteryNumberChanged;
    }

    // 事件处理程序  
    private void OnBatteryNumberChanged()
    {
        int batteryNumber = Battery.BatteryNumber;
        Debug.Log("电量变了");
        // 根据 Battery.BatteryNumber 的值更改颜色
      if (batteryNumber > 0 && batteryNumber < 4) // 确保索引在范围内
        switch (batteryNumber)
        {
            case 1:
                imageComponent.color = Color.red;
                Debug.Log("电池变红了");
                break;
            case 2:
                imageComponent.color = Color.yellow;
                Debug.Log("电池变黄了");
                break;
            case 3:
                imageComponent.color = Color.green;
                Debug.Log("电池变绿了");
                break;
          
        }
        else if(batteryNumber >=4)
            imageComponent.color = Color.green;

    }

    
}