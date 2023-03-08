using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticc : MonoBehaviour
{
    public static int X = 20;

    private void Start()
    {
        Debug.Log(staticc.X);
    }

    private void Update()
    {
        X += 1;
    }
}
