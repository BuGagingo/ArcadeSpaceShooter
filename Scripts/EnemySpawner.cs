using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Скрипт для спавна врагов
    public List<EnemyCounter> enemies; //Сохраняем префаб врага

    public float reloadTime = 1; //Здесь храним время между появлениями врагов

    public float spawnDistance = 9;
    void Start()
    {
        StartCoroutine(Spawn()); //Запускаем корутину в первый раз
    }

    IEnumerator Spawn()
    {
        if(enemies.Count != 0)
        {
            EnemyCounter newEnemy = ChoiseEnemy();
            Instantiate(newEnemy.enemyPrefab); //Создаём нового врага
            newEnemy.enemyPrefab.transform.position = new Vector3(
                Random.Range(transform.position.x - spawnDistance, transform.position.x + spawnDistance), //коорд Х
                transform.position.y, // коорд Y
                0 //коорд Z
            );  //конец команды
            yield return new WaitForSeconds(Random.Range(reloadTime-1, reloadTime+2)); //Ждём
            StartCoroutine(Spawn()); //Заного запускаем корутину
        }
    }
    
    EnemyCounter ChoiseEnemy()
    {
        int randIndex = Random.Range(0, enemies.Count-1);
        EnemyCounter enemy = enemies[randIndex];
        if (enemies[randIndex].count <= 1)
        {
            enemies.Remove(enemy);
            return enemy;
        }
        else
        {
            enemies[randIndex].count = enemies[randIndex].count - 1;
            return enemy;
        }
        
    }
}

[System.Serializable]
public class EnemyCounter
{
    public GameObject enemyPrefab;
    public int count;
}
