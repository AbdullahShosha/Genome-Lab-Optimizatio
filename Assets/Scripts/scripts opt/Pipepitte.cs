using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipepitte : SingleSubstanceContainer
{
    public GameObject PipepittePanel;
    public enum PipepitteSizes
    {
        _0_to_100,
        _100_to_1000,
        _1000_to_10000,
    }
    public PipepitteSizes PipepitteSize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            Interact();
        }
    }
    public override void Interact()
    {
        PipepittePanel.SetActive(true);
        Debug.Log(Name);
    }
}
