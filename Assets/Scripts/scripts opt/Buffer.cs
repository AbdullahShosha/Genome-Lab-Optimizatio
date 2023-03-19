using UnityEngine;


public class Buffer : SingleSubstanceContainer
{
    public bool IsOpen = false;
    public GameObject Cap;
    public enum BufferTypes
    {
        BloodBuffer, k_ProteinBuffer, LysisSolutionBuffer,
        IthanolBuffer, WashBuffer1, WashBuffer2, ElutionBuffer,
        Empty
    }
    public BufferTypes BufferType;
    // Start is called before the first frame update
    void Start()
    {
        Amount = 100000;
    }
    void Update()
    {
        if (IsActive)
        {
            Interact();
        }
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
