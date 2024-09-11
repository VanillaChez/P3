using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class FlashlightController : MonoBehaviour
{
    public Image Flashlight;

    private RectTransform canvasRect; // 声明一个RectTransform变量来存储Canvas的RectTransform  

    private void Start()
    {
        // 订阅事件  
        Battery.OnBatteryNumberChanged += OnBatteryNumberChanged;
        // 在Start方法中获取Canvas的RectTransform  
        // 假设Canvas是Flashlight的直接父对象，或者你可以通过其他方式获取Canvas的引用  
        canvasRect = Flashlight.transform.parent.GetComponent<RectTransform>();

        // 确保Flashlight的锚点设置为中心  
        Flashlight.rectTransform.anchorMin = Vector2.one * 0.5f;
        Flashlight.rectTransform.anchorMax = Vector2.one * 0.5f;
    }

    void Update()
    {
        // 获取鼠标的屏幕坐标  
        Vector3 mousePos = Input.mousePosition;

        // 将屏幕坐标转换为Canvas的坐标  
        Vector2 canvasPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePos, Camera.main, out canvasPos))
        {
            // 由于Flashlight的锚点设置为中心，我们不需要对canvasPos进行额外的偏移  
            // 但如果你想要Flashlight的某个特定点（不是中心）与鼠标对齐，你可能需要添加偏移  

            // 设置图标的位置  
            Flashlight.rectTransform.anchoredPosition = canvasPos;
           
        }

        UpdateFlashlightColor();
    }
    private void OnDestroy()
    {
        // 取消订阅，防止内存泄漏  
        Battery.OnBatteryNumberChanged -= OnBatteryNumberChanged;
    }


    private void OnBatteryNumberChanged()
    {
        // 当BatteryNumber变化时，这里会被调用  
       // Debug.Log("BatteryNumber changed!");
        // 在这里你可以添加更新Flashlight状态的代码  
    }

    private void UpdateFlashlightColor()
    {
        // 获取BatteryNumber的值  
        int batteryNumber = Battery.BatteryNumber;
        string spriteName = "Flash3"; // 默认Sprite名称  
        switch (batteryNumber)
        {
            case 1:
                spriteName = "Flash3";
                break;
            case 2:
                spriteName = "Flash2";
                break;
            case 3:
                spriteName = "Flash1";
                break;
            case 4:
                spriteName = "Flash1";
                break;
            case 5:
                spriteName = "Flash1";
                break;
            case 6:
                spriteName = "Flash1";
                break;
            case 7:
                spriteName = "Flash1";
                break;
                // 可以根据需要添加更多case  
        }
        // 根据BatteryNumber更新Flashlight的颜色  
        Sprite sprite = Resources.Load<Sprite>( spriteName);
        if (sprite != null)
        {
            Flashlight.sprite = sprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + spriteName);
        }
    }
}
