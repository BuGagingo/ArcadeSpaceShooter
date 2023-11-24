using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Скрипт для стрельбы врагов

    public GameObject bulletPrefab;

    public float reloadTime = 1;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(reloadTime);
        StartCoroutine(Shoot());
    }
}