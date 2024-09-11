using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MonoBehaviour
{
   

    // 定义委托  
   // public delegate void HealthChangedHandler(int newHealth);

    // 定义事件  
   // public event HealthChangedHandler OnHealthChanged;



    public GameObject Cat;
    public int Health = 8;
    public bool gameover = false;

    




    private void Update()
    {
        if (Health <= 0)
            GameOver();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Health--;
      

        Debug.Log("发生碰撞");
        if (collision.collider.CompareTag("Cat"))
        {
            Debug.Log("与玩家碰撞！");
            // 执行与玩家碰撞时的特定操作
           
          
        }
    }

    public void Die()
    {
        if (Health <= 0)
            gameover = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
