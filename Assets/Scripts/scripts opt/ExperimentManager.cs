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


    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        // Initialize the experiment
        CurrentStep = 0;
        UpdateStepText();
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
        stepTextUI.text = step[CurrentStep].StepInstructions;
    }
}
