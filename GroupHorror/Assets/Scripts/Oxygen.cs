﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    [SerializeField]
    private float underwaterDecreaseRate = 1.0f;
    [SerializeField]
    private float underwaterIncreaseRate = 10.0f;

    [SerializeField]
    private float maxOxygen = 100f;

    [SerializeField]
    public float oxygenCounter = 100f;
    private bool underwater = false;
    [SerializeField]
    private Slider slider;

    void Start()
    {
        oxygenCounter = Mathf.Clamp(oxygenCounter, 0, maxOxygen);
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Underwater") //Loops while player is in trigger tagged "Underwater"
        {
            underwater = true;
            if (oxygenCounter > 0) oxygenCounter -= Time.deltaTime * underwaterDecreaseRate; //decreases oxygen by underwaterDecreaseRate per second
            slider.value = oxygenCounter;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Underwater") underwater = false; 
    }
    void Update()
    {
        if (!underwater && oxygenCounter < 100)
        {
            oxygenCounter += Time.deltaTime * underwaterIncreaseRate;
            slider.value = oxygenCounter;
        }
    }

    
}
