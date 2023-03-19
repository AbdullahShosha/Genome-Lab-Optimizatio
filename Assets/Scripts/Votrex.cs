using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Votrex : Interactable
{
    public static bool Vortexon = false;


    private void Start()
    {
        
    }
    public void TurnOnAndOff()
    {
        Vortexon = !Vortexon;
        GetComponent<Animator>().SetBool("IsWorking", Vortexon);
        if (Vortexon)
            gameObject.GetComponent<AudioSource>().Play();
        else gameObject.GetComponent<AudioSource>().Stop();

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    public override void Interact()
    {
        Debug.Log("Buffer");
    }
}
