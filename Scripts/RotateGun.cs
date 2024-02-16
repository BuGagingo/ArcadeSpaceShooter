using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    [SerializeField][Range(10,30)]
    private float speed;

    [SerializeField] private bool isActiveRotate;
    
    // Start is called before the first frame update
    public GameObject bulletPrefab;

    public float reloadTime = 1;
    
    private bool isAttack = false;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActiveRotate)
            Spin();
    }

    void Spin()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        float angle = Vector2.SignedAngle(Vector2.down, transform.up);
        if (Math.Abs(angle)>=90)
        {
            speed *= -1;
        }
    }
    public bool IsAttack()
    {
        return isAttack;
    }
    public void StartAttack()
    {
        isAttack = true;
        StartCoroutine(AttackRotate());
    }
    IEnumerator AttackRotate()
    {
        isActiveRotate = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
        yield return new WaitForSeconds(2);
        isActiveRotate = false;
        isAttack = false;
        StopAllCoroutines();
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
