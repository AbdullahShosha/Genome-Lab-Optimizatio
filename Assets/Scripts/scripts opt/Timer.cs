using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer = 0;
    private Action actionOnTimer;
    
    public void SetTimer(float timer,Action function)
    {
        this.timer = timer;
        actionOnTimer = function;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer-= Time.deltaTime;
        }
        else
            actionOnTimer();
    }
}
