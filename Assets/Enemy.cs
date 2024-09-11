using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject Cat;

    



    // �����ƶ��ٶ�  
    public float speed = 0.25f;
    
 
    void Update()
    {
            transform.position= Vector2.MoveTowards(transform.position, Cat.transform.position, speed * Time.deltaTime);
    }
   
    //��ײ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<CatManager>().Health -= 1;
        Destroy(gameObject);
        Debug.Log("�ݻ�");
       
    }

    public void OnMouseDown() 
    {
        Destroy(gameObject);

    }

}
