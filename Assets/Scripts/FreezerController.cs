using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FreezerController : Interactable
{

    public static int Temp;
    public Text Field, ErrorPanelText;
    public GameObject Panel,DonePanel;
    public Sprite Done,Wrong;
    public Image helper;

    private void Start()
    {
        Interaction_Time = 0;
    }
    public void Set()
    {
        Temp = int.Parse(Field.text);
        if (Temp == 20)
        {
            Field.text = "";
            button.ChoosenExperment = 0;
            Steps.NextStep();
        }
/*        else if(Temp == -8)
        {
            Field.text = "";
            Panel.SetActive(false);
            Steps.NextStep();
        }*/
        else
        {
            Steps.WrongStepPanel.SetActive(true); 
        }
        Panel.SetActive(false);
    }
    public void ONPanel()
    {
        if (Steps.Step == 14)
            Panel.SetActive(true);
        else
        {
            ErrorPanelText.text = "Wrong Step";
            Steps.WrongStepPanel.SetActive(true); 
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        DragStep.Interactable_Status[ID] = true;
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        DragStep.Interactable_Status[ID] = false;
        Interaction_Time = 0;
    }
    public override void Interact()
    {
        Debug.Log(Name);
    }
}
