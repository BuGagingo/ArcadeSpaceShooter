using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    private PlayerStats player;
    private Slider slider;
    void Start()
    {
        player = PlayerStats.singleton;
        slider = this.GetComponent<Slider>();
        slider.maxValue = player.MaxHP;
        slider.value = player.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.HP;
    }
}
