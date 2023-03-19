using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Container : Interactable
{
    //public bool IsEmpty = true;
    // Start is called before the first frame update
    /*public bool Taker = false;
    public bool Giver = false;*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public abstract bool IsEmpty();
}
