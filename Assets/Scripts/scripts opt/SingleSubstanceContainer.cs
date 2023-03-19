using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleSubstanceContainer : Container
{
    public string Inside = "Empty";
    public int Amount = 0;



    override public bool IsEmpty()
    {
        return Inside == "Empty";
    }
}
