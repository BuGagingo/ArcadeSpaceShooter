using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isMoving = true;
    private bool startLevel = false;

    public float speed = 1;
    public Collider2D col;
    public GameObject bossObject;
    public GameObject spawners;
    public GameObject winMenu;
    public GameObject defeatMenu;
    public List<Objects> objects;
    

    void Start()
    {
        foreach (var obj in objects)
        {
            obj._object.SetActive(!obj.IsActiveAfterStart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
        }
        if(startLevel)
        {
            speed+=2*Time.deltaTime;
        }
        if(spawners.GetComponent<EnemySpawner>().enemies.Count == 0)
        {
            Victory();
        }
        if(PlayerStats.singleton.HP <= 0)
        {
            Defeat();
        }
    }
    void SpeedUp()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!startLevel)
            {
                isMoving = false;
                bossObject.SetActive(true);
            }
            else{
                speed = 1;
                spawners.SetActive(true);
                startLevel = false;
                Destroy(col);
            }
        }
    }
    public void StartGame()
    {
        isMoving = true;
        startLevel = true;
        foreach (var obj in objects)
        {
            obj._object.SetActive(obj.IsActiveAfterStart);
        }
    }
    public void Victory()
    {
        winMenu.SetActive(true);
        isMoving = false;
    }
    public void Defeat()
    {
        defeatMenu.SetActive(true);
        isMoving = false;
    }
}

[System.Serializable]
public struct Objects
{
    public GameObject _object;
    public bool IsActiveAfterStart;
}
