using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject Cat;

    



    // 敌人移动速度  
    public float speed = 0.25f;
    
 
    void Update()
    {
            transform.position= Vector2.MoveTowards(transform.position, Cat.transform.position, speed * Time.deltaTime);
    }
   
    //碰撞销毁幽灵
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<CatManager>().Health -= 1;
        Destroy(gameObject);
        Debug.Log("摧毁");
       
    }

    public void OnMouseDown() 
    {
        Destroy(gameObject);

    }

}
