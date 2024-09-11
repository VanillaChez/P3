using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class FlashlightController : MonoBehaviour
{
    public Image Flashlight;

    private RectTransform canvasRect; // ����һ��RectTransform�������洢Canvas��RectTransform  

    private void Start()
    {
        // �����¼�  
        Battery.OnBatteryNumberChanged += OnBatteryNumberChanged;
        // ��Start�����л�ȡCanvas��RectTransform  
        // ����Canvas��Flashlight��ֱ�Ӹ����󣬻��������ͨ��������ʽ��ȡCanvas������  
        canvasRect = Flashlight.transform.parent.GetComponent<RectTransform>();

        // ȷ��Flashlight��ê������Ϊ����  
        Flashlight.rectTransform.anchorMin = Vector2.one * 0.5f;
        Flashlight.rectTransform.anchorMax = Vector2.one * 0.5f;
    }

    void Update()
    {
        // ��ȡ������Ļ����  
        Vector3 mousePos = Input.mousePosition;

        // ����Ļ����ת��ΪCanvas������  
        Vector2 canvasPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePos, Camera.main, out canvasPos))
        {
            // ����Flashlight��ê������Ϊ���ģ����ǲ���Ҫ��canvasPos���ж����ƫ��  
            // ���������ҪFlashlight��ĳ���ض��㣨�������ģ��������룬�������Ҫ���ƫ��  

            // ����ͼ���λ��  
            Flashlight.rectTransform.anchoredPosition = canvasPos;
           
        }

        UpdateFlashlightColor();
    }
    private void OnDestroy()
    {
        // ȡ�����ģ���ֹ�ڴ�й©  
        Battery.OnBatteryNumberChanged -= OnBatteryNumberChanged;
    }


    private void OnBatteryNumberChanged()
    {
        // ��BatteryNumber�仯ʱ������ᱻ����  
       // Debug.Log("BatteryNumber changed!");
        // �������������Ӹ���Flashlight״̬�Ĵ���  
    }

    private void UpdateFlashlightColor()
    {
        // ��ȡBatteryNumber��ֵ  
        int batteryNumber = Battery.BatteryNumber;
        string spriteName = "Flash3"; // Ĭ��Sprite����  
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
                // ���Ը�����Ҫ��Ӹ���case  
        }
        // ����BatteryNumber����Flashlight����ɫ  
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
