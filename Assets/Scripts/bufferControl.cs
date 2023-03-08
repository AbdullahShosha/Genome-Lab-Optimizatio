using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bufferControl : MonoBehaviour
{
   
    public string Name ;
    public bool IsOpen = false;
    public GameObject Cap;
    public Text bufName;


    public void OpenCloseBuffer()
    {
        IsOpen = !IsOpen;
        Cap.GetComponent<Animator>().SetBool("isopen", IsOpen);

    }

    void OnMouseOver()
    {
        bufName.text = Name;
    }
}
