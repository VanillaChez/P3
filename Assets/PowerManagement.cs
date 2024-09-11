using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PowerManagement : MonoBehaviour
{
    private Image imageComponent;
    public int BatteryCount = Battery.BatteryNumber;

    void Start()
    {
        // �����¼�  
        Battery.OnBatteryNumberChanged += OnBatteryNumberChanged;
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("No Image component attached to the game object with PowerManagement script.");
        }
        

    }

    void OnDestroy()
    {
        // ȡ�������¼�����ֹ�ڴ�й©  
        Battery.OnBatteryNumberChanged -= OnBatteryNumberChanged;
    }

    // �¼��������  
    private void OnBatteryNumberChanged()
    {
        int batteryNumber = Battery.BatteryNumber;
        Debug.Log("��������");
        // ���� Battery.BatteryNumber ��ֵ������ɫ
      if (batteryNumber > 0 && batteryNumber < 4) // ȷ�������ڷ�Χ��
        switch (batteryNumber)
        {
            case 1:
                imageComponent.color = Color.red;
                Debug.Log("��ر����");
                break;
            case 2:
                imageComponent.color = Color.yellow;
                Debug.Log("��ر����");
                break;
            case 3:
                imageComponent.color = Color.green;
                Debug.Log("��ر�����");
                break;
          
        }
        else if(batteryNumber >=4)
            imageComponent.color = Color.green;

    }

    
}