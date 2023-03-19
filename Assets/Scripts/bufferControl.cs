using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bufferControl :  Interactable
{
    public bool IsOpen = false;
    public GameObject Cap;
    public Text bufName;

    private void Start()
    {
        Interaction_Time = 0;
    }

    void OnMouseOver()
    {
        bufName.text = Name;
    }
    private void OnTriggerStay(Collider other)
    {
        if(Interaction_Time >= 2.0)
        DragStep.Interactable_Status[ID] = true;
        Interaction_Time += Time.deltaTime;
    }
    private void OnTriggerExit(Collider other)
    {
        DragStep.Interactable_Status[ID] = false;
        Interaction_Time = 0;
    }

    public void OpenCloseBuffer()
    {
        IsOpen = !IsOpen;
        Cap.GetComponent<Animator>().SetBool("isopen", IsOpen);

    }
    public override void Interact()
    {
        Debug.Log(Name);
    }
}
