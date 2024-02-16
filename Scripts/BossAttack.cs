using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public RotateGun rg;
    public LaserGun lg;
    void Start()
    {
        
    }

    void Update()
    {
        if(!rg.IsAttack() && !lg.IsAttack())
        {
            Attack();
        }
    }

    public void Attack()
    {
        int r = Random.Range(1, 101);
        if (r <= 50)
        {
            rg.StartAttack();
        }
        else
        {
            lg.StartAttack();
        }
    }
    // Update is called once per frame
    
}
