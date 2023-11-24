using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Скрипт для пуль

    public string targetTag; //Здесь будем сохранять тег того, кого должна уничтожать пуля

    public float speed = 3; //Здесь сохраняем скорость пули (чтобы скорость полёта пули у разных врагов могла быть разная)
    public float dmg = 1;
    public int countDmg = 1;
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime)); //Постоянно перемещаем пулю вверх
    }

    private void OnTriggerEnter2D(Collider2D collision) //При касании триггера
    {
        if (collision.gameObject.CompareTag(targetTag)) //Если тот, кто конснулся пули имеет нужный нам тег
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(dmg); //Уничтожаем того, кого коснулись
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