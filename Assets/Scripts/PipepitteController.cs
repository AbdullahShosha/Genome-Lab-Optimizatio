using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PipepitteController : Interactable
{
    public int Size = 0 ;
    public string InsidePip;
    public Sprite NextStepHelper, WrongStephelper,putSample;
    public Image helper;
    public GameObject Panel;
    public InputField Field;
    public Text Ttext;
    public Vector3 Reset;
    private bufferControl Currentbuffer;

    private void Start()
    {
        Reset = gameObject.transform.position;
        InsidePip  = "empty";
        Interaction_Time = 0;
    }

    public void ONPanel()
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", true);
        Size = 0;
        Panel.SetActive(true);
    }
    public void Set()
    {
        Size = int.Parse(Field.text);
        Field.Select();
        Field.text = "";
        Panel.SetActive(false);
        transform.position = Reset;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Soaking", false);
        Steps.instructiontext.text = "add it to the sample";
        helper.sprite = putSample;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Ttext.text = ((int)Interaction_Time).ToString();
        if (Interaction_Time >= 2.0f)
        {
            DragStep.Interactable_Status[ID] = true;
        }
        else
            Interaction_Time += Time.deltaTime;

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
