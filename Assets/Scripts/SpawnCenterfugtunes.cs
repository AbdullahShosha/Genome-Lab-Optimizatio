using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCenterfugtunes : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Centerfugtunes;

    public void Spawn()
    {
        Instantiate(Centerfugtunes,SpawnPos.position,SpawnPos.rotation);
    }
}
