using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float timing = 0.1f;
    bool moving = false;
    public float speed = 5f;

    void Update()
    {
        // Проверяем, что цель установлена
        if (target != null)
        {
            if(!moving)
            {
                moving = true;
                Invoke("MoveToTarget",timing);
            }
        }
    }
    void MoveToTarget()
    {
        transform.position = target.position;
        moving = false;
    }
}
