using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    private PlayerStats player;
    private Slider slider;
    void Start()
    {
        player = PlayerStats.singleton;
        slider = this.GetComponent<Slider>();
        slider.maxValue = player.MaxShield;
        slider.value = player.MaxShield;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.Shield;
    }
}
