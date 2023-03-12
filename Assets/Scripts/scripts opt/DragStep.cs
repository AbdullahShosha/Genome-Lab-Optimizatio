using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drag Step", menuName = "Steps/Drag Step")]
public class DragStep : ExperimentStep
{
    enum interactable { Pipepitte, BloodBuffer , kKroteinBuffer, LysisSolutionBuffer, IthanolBuffer, WashBuffer1, ElutionBuffer, WashBuffer2,
                        Centerifuge, Thermomixer, Centerfugtunes, Tube, Freezer,Votrex }
    [SerializeField] private interactable interactable1;
    [SerializeField] private interactable interactable2;
    public static bool[] Interactable_Status = { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
