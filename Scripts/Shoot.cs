using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Стрельба игрока по нажатию кнопки

    public PlayerStats player;
    private bool isReadyShoot = true;
    private float reloadTime = 1;
    private GameObject bulletPrefab;
    void Start()
    {
        player = PlayerStats.singleton;
        isReadyShoot = true;
        reloadTime = player.reloadTime;
        bulletPrefab = player.bulletPrefab;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isReadyShoot)
        {
            Shooting();
        }
    }
    

    public void Shooting()
    {
        if (isReadyShoot && player.bullets > 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            player.bullets -= 1;
            if(player.bullets <= 0)
            {
                isReadyShoot = false;
                //Показывать icon перезарядки
                StartCoroutine(StartReloading());
            }
        }
    }

    IEnumerator StartReloading()
    {
        yield return new WaitForSeconds(reloadTime);
        isReadyShoot = true;
        player.bullets = player.maxBullets;
    }
    
}