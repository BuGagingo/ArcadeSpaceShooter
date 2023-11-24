using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{

    [SerializeField][Range(1, 300)]private float hp;
    [Tooltip("Partical object after destroy")]
    public GameObject parObj;
    public void Damage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        parObj.transform.parent = null;
        parObj.transform.rotation = new Quaternion(0, 0, 180, 1);
        parObj.SetActive(true);
    }
}