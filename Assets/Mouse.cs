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
        //��ЧԤ��
        // if (audioSource != null)
        //{
        //  audioSource.Play();
        //}
        Debug.Log("ִ�дݻ�");
        Destroy(Mare);
        // �����������������˱�����ʱ���߼���������Ч���������ӵ�  
    }
}
