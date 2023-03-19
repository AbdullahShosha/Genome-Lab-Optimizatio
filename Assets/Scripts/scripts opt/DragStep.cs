using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drag Step", menuName = "Steps/Drag Step")]
public class DragStep : ExperimentStep
{
    enum interactable { Pipepitte, Buffer,Centerifuge, Thermomixer, Centerfugtunes, Tube, Freezer,Votrex }
    [SerializeField] private interactable interactable1;
    [SerializeField] private interactable interactable2;
    public static bool[] Interactable_Status = new bool[50];
    //private interactable Last_interactable = interactable.Votrex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public  void CheckStepCompletion()
    {
        if(Interactable_Status[(int)interactable1] && Interactable_Status[(int)interactable1])
        {
            IsDone = true;
        }
    }
}
