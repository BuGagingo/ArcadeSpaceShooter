using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject laserPerepare;
    public GameObject laser;
    
    private bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsAttack()
    {
        return isAttack;
    }
    public void StartAttack()
    {
        isAttack = true;
        StartCoroutine(AttackLaser());
    }
    IEnumerator AttackLaser()
    {
        laserPerepare.SetActive(true);
        yield return new WaitForSeconds(1);
        laserPerepare.SetActive(false);
        laser.SetActive(true);
        yield return new WaitForSeconds(2);
        laser.SetActive(false);
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
}
