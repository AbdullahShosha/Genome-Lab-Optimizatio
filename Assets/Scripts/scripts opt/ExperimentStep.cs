using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExperimentStep : ScriptableObject
{
    public string StepInstructions;
    public bool IsDone = false;

    public abstract void CheckStepCompletion();
    
}
