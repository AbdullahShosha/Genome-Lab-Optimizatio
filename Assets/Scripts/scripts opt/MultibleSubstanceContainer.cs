using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MultibleSubstanceContainer : Container
{

    public IDictionary<string, int> Inside = new Dictionary<string, int>();
    public int NumberOfElements = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    override public bool IsEmpty()
    {
        return Inside.Count == 0;
    }
}
