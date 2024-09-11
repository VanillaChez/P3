using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //��ΪԤ�����޷�����ʵ��������
    public GameObject player;
    //Ԥ�������
    public GameObject Mare;
    //��¡����
    public GameObject newEnemy;
    //Ԥ�������
    public GameObject Battery;
    //���
    public GameObject newBattery;
    //�������Ƶ������
    public int bNumber=0;

    //���ɼ��
    public float spawnInterval = 1f;
    private float lastSpawnTime;

    //α�������
    Vector2[] marePositions = new Vector2[]
    {
        new Vector2(8, 3),
        new Vector2(-8, 7),
        new Vector2(12, 5),
        new Vector2(-12, 5),
        new Vector2(10, 7),
        new Vector2(-10, 7),
        new Vector2(5, 15),
        new Vector2(8, 20),
        new Vector2(-7, 14),
        new Vector2(-6, 12),
        new Vector2(3, 12),
        new Vector2(-3, 14),
        };

    //�������λ�ó�
    Vector2[] batteryPositions = new Vector2[]
    {
        //ɳ��
        new Vector2(-4.79f, -4.49f),
        
        //��߱�1
        new Vector2(3.66f, 0.4f),
        //��߱�2
        new Vector2(2.17f,-0.18f),
        //���1
        new Vector2(5.44f,3.67f),
        //���2
        new Vector2(7.18f, -0.68f),
        //���3
        new Vector2(8.5f, 2.6f),
    };



    void Start()
    {
         
        lastSpawnTime = Time.time;
        StartCoroutine(SpawnCoroutine()); // ��ʼЭ��  
    }


    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval - (Time.time - lastSpawnTime)); // �ȴ�ֱ����һ������ʱ��  

            // ����Ƿ���ĵ���ʱ�䣬�Է�ʱ�䱻��������Ϸ��ͣ  
            if (Time.time - lastSpawnTime >= spawnInterval)
            {
                int randomIndex = Random.Range(0, marePositions.Length);
                Vector2 spawnPosition = marePositions[randomIndex];
                // �����߼�  
                newEnemy = Instantiate(Mare, spawnPosition, Quaternion.identity);
                //��ֵ
                newEnemy.GetComponent<Enemy>().Cat = player;

                lastSpawnTime = Time.time; // �����������ʱ��  
            }
        }
    }                                                                               

        // Update is called once per frame
        void Update()
    {
        if (bNumber<=4)
        {
            // �������е��λ�ã�����ÿ��λ��ʵ����һ��Battery Prefab  
            foreach (Vector2 position in batteryPositions)
            {
                // ʵ����Prefab����������λ��  
                GameObject newBattery = Instantiate(Battery, position, Quaternion.identity);
                bNumber++;
                 
            }
        }
    }
}
