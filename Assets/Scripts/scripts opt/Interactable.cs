using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string Name = "Default";
    public int ID;
    public bool IsActive;
    public enum interactable { None, Pipepitte, Buffer, Centerfugtunes,
                            Centerifuge, Thermomixer,Votrex , Freezer, Tube }
    public static interactable FunctionIndexer1;
    public static interactable FunctionIndexer2;
    public        interactable Inter;
    public static float Interaction_Time;
    

    //public static Thermomixer thermomixter= null;
    //public static Centerifuge Centerifuge= null;
    //public static Freezer freezer= null;
    private void Start()
    {
        FunctionIndexer1 = interactable.None;
        FunctionIndexer2 = interactable.None;
        Inter = interactable.None;
        IsActive = false;
    }
    public abstract void Interact();
}
