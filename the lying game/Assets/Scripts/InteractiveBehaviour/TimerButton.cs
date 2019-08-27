using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButton : InteractiveObj
{
    [SerializeField] private float timer;

    private bool timerStarted;
    private float timerCounter;

    public TimerButton()
    {
        isGrabbable = false;
        timerStarted = false;
        timerCounter = 0f;
    }

    void Update()
    {
        if (timerStarted) timerCounter += Time.deltaTime;

        if(timerCounter >= timer)
        {
            timerStarted = false;
            timerCounter = 0f;

            Debug.Log("Hey!!!");
        }
    }

    public override void Interac()
    {
        timerStarted = true;
    }
}
