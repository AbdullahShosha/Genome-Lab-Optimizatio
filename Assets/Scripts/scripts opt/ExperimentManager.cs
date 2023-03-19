using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ExperimentManager : MonoBehaviour
{
    public Text InstructionTextUI;
    public Text stepTextUI;
    public ExperimentStep[] step;
    private int CurrentStep = 0;
    public Canvas []UI_Panels;

    void Start()
        {
            // Initialize the experiment
            CurrentStep = 0;
            UpdateStepText();
        }
    // Update is called once per frame
    void Update()
    {
        if(step[CurrentStep].IsDone)
        {
            NextStep();
        }
    }
    public void NextStep()
    {
        CurrentStep++;
        if (CurrentStep >= step.Length)
        {
            // Experiment is complete
            Debug.Log("Experiment complete!");
            return;
        }
        UpdateStepText();
    }

    private void UpdateStepText()
    {
        stepTextUI.text = CurrentStep.ToString();
        InstructionTextUI.text = step[CurrentStep].StepInstructions;
    }
}
