using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Скрипт дял перемещения простых врагов
    public float speed = 3;
    public bool isNavigate = false;
    public GameObject target;
    // Update is called once per frame
    private void Start()
    {
        //target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
        if (isNavigate && target != null)
        {
            if(transform.position.y > -1)
            {
                float angle = Mathf.Atan2(transform.position.y - target.transform.position.y,
                    transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
            }
            else
            {
                //transform.rotation = new Quaternion(0, 0, 180, 1);
            }
        }
    }
}