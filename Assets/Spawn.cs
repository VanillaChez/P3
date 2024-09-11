using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //因为预制体无法挂载实例化对象
    public GameObject player;
    //预制体敌人
    public GameObject Mare;
    //克隆敌人
    public GameObject newEnemy;
    //预制体敌人
    public GameObject Battery;
    //电池
    public GameObject newBattery;
    //用于限制电池数量
    public int bNumber=0;

    //生成间隔
    public float spawnInterval = 1f;
    private float lastSpawnTime;

    //伪随机生成
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

    //电池生成位置池
    Vector2[] batteryPositions = new Vector2[]
    {
        //沙发
        new Vector2(-4.79f, -4.49f),
        
        //玩具堡1
        new Vector2(3.66f, 0.4f),
        //玩具堡2
        new Vector2(2.17f,-0.18f),
        //书架1
        new Vector2(5.44f,3.67f),
        //书架2
        new Vector2(7.18f, -0.68f),
        //书架3
        new Vector2(8.5f, 2.6f),
    };



    void Start()
    {
         
        lastSpawnTime = Time.time;
        StartCoroutine(SpawnCoroutine()); // 开始协程  
    }


    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval - (Time.time - lastSpawnTime)); // 等待直到下一个生成时间  

            // 检查是否真的到了时间，以防时间被调整或游戏暂停  
            if (Time.time - lastSpawnTime >= spawnInterval)
            {
                int randomIndex = Random.Range(0, marePositions.Length);
                Vector2 spawnPosition = marePositions[randomIndex];
                // 生成逻辑  
                newEnemy = Instantiate(Mare, spawnPosition, Quaternion.identity);
                //传值
                newEnemy.GetComponent<Enemy>().Cat = player;

                lastSpawnTime = Time.time; // 更新最后生成时间  
            }
        }
    }                                                                               

        // Update is called once per frame
        void Update()
    {
        if (bNumber<=4)
        {
            // 遍历所有电池位置，并在每个位置实例化一个Battery Prefab  
            foreach (Vector2 position in batteryPositions)
            {
                // 实例化Prefab，并设置其位置  
                GameObject newBattery = Instantiate(Battery, position, Quaternion.identity);
                bNumber++;
                 
            }
        }
    }
}
