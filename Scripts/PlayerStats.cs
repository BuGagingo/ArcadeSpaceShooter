using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats singleton;
    #region Health
    [Header("Health")]
    public float HP = 100;
    public float MaxHP = 100;
    public float RegenHP = 1;
    public bool isRegenerationHP = true;
    #endregion

    #region Energy
    [Space(3)]
    [Header("Energy")]
    public float Energy = 100;
    public float MaxEnergy = 100;
    public float RegenEnergy = 1;
    public bool isRegenerationEnergy = true;
    #endregion

    #region Shield
    [Space(3)]
    [Header("Shield")]
    public float Shield = 100;
    public float MaxShield = 100;
    public float RegenShield = 1;
    public bool isRegenerationShield = true;
    #endregion

    #region Ammo
    [Space(3)]
    [Header("Ammo")]
    public GameObject bulletPrefab;
    public int maxBullets = 1;
    public int bullets = 1;
    public float reloadTime = 1;

    #endregion
    
    #region Speed
    public float speed = 7;
    #endregion
    private void Awake()
    {
        singleton = this;
        if(maxBullets == 0)
            maxBullets = 1;
        bullets = maxBullets;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (isRegenerationHP)
        {
            HP+=RegenHP;
            if (HP >= MaxHP)
            {
                HP = MaxHP;
                isRegenerationHP = false;
            }
        }
        if (isRegenerationShield)
        {
            Shield+=RegenShield;
            if (Shield >= MaxShield)
            {
                Shield = MaxShield;
                isRegenerationShield = false;
            }
        }
        if (isRegenerationEnergy)
        {
            Energy+=RegenEnergy;
            if (Energy >= MaxEnergy)
            {
                Energy = MaxEnergy;
                isRegenerationEnergy = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Shield -= damage;
        if (Shield <= 0)
        {
            HP += Shield;
            if (HP <= 0)
            {
                Death();
            }
            Shield = 0;
        }
        else
        {
            //anim shield
        }
    }

    public void Death()
    {
        Destroy(gameObject, 1);
    }
}
