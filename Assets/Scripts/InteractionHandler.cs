using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionHandler : MonoBehaviour
{
    public static float Interaction_Time;
    public static Text UI_Text_Name;
    public static Text UI_Interaction_Time_Text;
    private Interactable CurrentInteracting;
    public static Action action;
    public float TimeNeeded = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Interaction_Time = 0;
        UI_Text_Name = GameObject.Find("Interactable Name").GetComponent<Text>();
        UI_Interaction_Time_Text = GameObject.Find("Timer").GetComponent<Text>();
        CurrentInteracting = GetComponent<Interactable>();
        action = Default;
    }

    // Update is called once per frame
    void Update()
    {
        //action();
    }

    void OnMouseOver()
    {
        UI_Text_Name.text = CurrentInteracting.Name;
    }
    private void OnTriggerStay(Collider other)
    {
        if(Interaction_Time < TimeNeeded-0.1)
        {
            UI_Interaction_Time_Text.text = ((int)Interaction_Time).ToString();
            Debug.Log(Interaction_Time);
        }        
        if (Interaction_Time >= TimeNeeded)
        {
            CurrentInteracting.IsActive = true;
        }
        else
            Interaction_Time += Time.deltaTime/2;
    }
    private void OnTriggerExit(Collider other)
    {
        DragStep.Interactable_Status[CurrentInteracting.ID + 1] = false;
        Interaction_Time = 0;
        Interactable.FunctionIndexer1 = Interactable.interactable.None;
        Interactable.FunctionIndexer2 = Interactable.interactable.None;
        CurrentInteracting.IsActive = false;

        //FunctionIndexer1 = interactable.None; FunctionIndexer2 = interactable.None;
    }
    public void Default()
    {
        Debug.Log("Default");
    }
}
