using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Votrex : Interactable
{
    public static bool Vortexon = false;

    public void TurnOnAndOff()
    {
        Vortexon = !Vortexon;
        GetComponent<Animator>().SetBool("IsWorking", Vortexon);
        if (Vortexon)
            gameObject.GetComponent<AudioSource>().Play();
        else gameObject.GetComponent<AudioSource>().Stop();

    }

}
