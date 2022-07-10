using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Camara : MonoBehaviour
{
    //Esta variable hace referencia al personaje "buzo";
    public GameObject buzo;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = buzo.transform.position.x;
        transform.position = position;
    }
}
