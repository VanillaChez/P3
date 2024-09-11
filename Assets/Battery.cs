using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battery : MonoBehaviour
{
    SpriteRenderer sprite;
    // ����һ���¼�  
    public static event Action OnBatteryNumberChanged;
    // ��̬��ͨ�õ��  
    public static int BatteryNumber = 1;

    // ����������ٵ�ʱ�������룩  
    public float decreaseInterval = 15f;

    // Start is called before the first frame update  
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("DecreaseBattery", 8f, 8f);
    }

   

    private void OnMouseEnter()
    {
        sprite.color = new Color(1f, 1f, 0f, 1); // ע����ɫֵӦ����0��1֮��  
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(0f, 1f, 0f, 1);
    }

    public void OnMouseDown()
    {
        BatteryNumber++;
        OnBatteryNumberChanged?.Invoke();
        Destroy(gameObject);
        // �����Ϸ�������٣�InvokeRepeatingҲ���Զ�ֹͣ  
    }
    void DecreaseBattery()
    {
        if (BatteryNumber > 0)
        {
            BatteryNumber--;
            OnBatteryNumberChanged?.Invoke();
            Debug.Log($"�����еĵ���������ٵ�: {BatteryNumber}");
        }
    }
}