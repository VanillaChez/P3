using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Vector2 mousePose;
    
    void Update()
    {
        mousePose = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
    }

    void DestroyEnemy(GameObject Mare)
    {
        //音效预留
        // if (audioSource != null)
        //{
        //  audioSource.Play();
        //}
        Debug.Log("执行摧毁");
        Destroy(Mare);
        // 这里可以添加其他敌人被消灭时的逻辑，比如音效、分数增加等  
    }
}
