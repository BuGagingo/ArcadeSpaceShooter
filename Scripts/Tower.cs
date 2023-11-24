using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float reloadTime = 1; 
    public bool isReadyShoot = true; 
    public TriggerZone zone; 
    public GameObject target;
    void Update()
    {
        if (isReadyShoot && zone.isPlayerNear)
        {
            
            StartCoroutine(Shoot());
        }
        float angle = Mathf.Atan2(transform.position.y - target.transform.position.y, transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    IEnumerator Shoot()
    {
        isReadyShoot = false;
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position; 
        float angle = Mathf.Atan2(transform.position.y - target.transform.position.y, transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        yield return new WaitForSeconds(reloadTime);
        isReadyShoot = true;
    }
}
