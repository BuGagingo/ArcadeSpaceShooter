using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Скрипт для пуль игрока
    //Они будут наносить урон по боссу, если у босса будет тег "Boss" и скрипт "HP"
    //Также скрипт мгновенно уничтожает врагов с тегом "Enemy"
    [SerializeField][Range(1, 30)]private float speed = 3;
    [SerializeField][Range(1, 30)]private float dmg = 1;
    [SerializeField][Range(1, 30)]private int countDmg = 1;

    void Start()
    {
        Destroy(gameObject, 10);
    }
    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime)); //Постоянно перемещаем пулю вверх
    }
    private void OnTriggerEnter2D(Collider2D collision) //При касании триггера
    {
        if (collision.gameObject.CompareTag("Enemy")) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            HP enemyHP = collision.gameObject.GetComponent<HP>();
            enemyHP.Damage(dmg); //Уничтожаем того, кого коснулись
        }
        else if (collision.gameObject.CompareTag("Boss")) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            HP bossHP = collision.gameObject.GetComponent<HP>();
            bossHP.Damage(dmg);
            Destroy(gameObject); //Уничтожаем пулю (чтобы не летела дальше)
        }
        if(!collision.gameObject.CompareTag("Player"))
        {
            if (countDmg == 1)
            {
                Destroy(gameObject);
            }
            else
            {
                countDmg -= 1;
            }
        }
        
    }
}

