using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battery : MonoBehaviour
{
    SpriteRenderer sprite;
    // 定义一个事件  
    public static event Action OnBatteryNumberChanged;
    // 静态的通用电池  
    public static int BatteryNumber = 1;

    // 电池数量减少的时间间隔（秒）  
    public float decreaseInterval = 15f;

    // Start is called before the first frame update  
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("DecreaseBattery", 8f, 8f);
    }

   

    private void OnMouseEnter()
    {
        sprite.color = new Color(1f, 1f, 0f, 1); // 注意颜色值应该在0到1之间  
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
        // 如果游戏对象被销毁，InvokeRepeating也会自动停止  
    }
    void DecreaseBattery()
    {
        if (BatteryNumber > 0)
        {
            BatteryNumber--;
            OnBatteryNumberChanged?.Invoke();
            Debug.Log($"背包中的电池数量减少到: {BatteryNumber}");
        }
    }
}