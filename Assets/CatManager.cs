using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MonoBehaviour
{
   

    // ����ί��  
   // public delegate void HealthChangedHandler(int newHealth);

    // �����¼�  
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
      

        Debug.Log("������ײ");
        if (collision.collider.CompareTag("Cat"))
        {
            Debug.Log("�������ײ��");
            // ִ���������ײʱ���ض�����
           
          
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
