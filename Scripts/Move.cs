using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Перемещение игрока
    PlayerStats player;
    float speed = 3f;
    [SerializeField] private Joystick joystick;

    private void Start()
    {
        player = PlayerStats.singleton;
        speed = player.speed;
    }

    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        float inputJH = joystick.Horizontal;
        float inputJV = joystick.Vertical;
        if (inputH != 0 || inputV != 0)
        {
            Vector3 direction = new Vector3(inputH, inputV, 0);
            transform.Translate(direction * (speed * Time.deltaTime));
        }
        if (inputJH != 0 || inputJV != 0)
        {
            Vector3 direction = new Vector3(inputJH, inputJV, 0);
            transform.Translate(direction * (speed * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            player.TakeDamage(1);
        }
    }
}