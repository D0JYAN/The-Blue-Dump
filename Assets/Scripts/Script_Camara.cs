using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Camara : MonoBehaviour
{

    public Vector2 Min_Camara_Pos, MAx_Camara_Pos;
    public float Mov_Suave;

    private Vector2 Velocidad;

    //Esta variable hace referencia al personaje "buzo";
    public GameObject buzo;

    // Update is called once per frame
    void Update()
    {
        float Mov_Cam_X = Mathf.SmoothDamp(transform.position.x, buzo.transform.position.x, ref Velocidad.x, Mov_Suave);
        float Mov_Cam_Y = Mathf.SmoothDamp(transform.position.y, buzo.transform.position.y, ref Velocidad.y, Mov_Suave);

        transform.position = new Vector3(
            Mathf.Clamp(Mov_Cam_X, Min_Camara_Pos.x, MAx_Camara_Pos.x),
            Mathf.Clamp(Mov_Cam_Y, Min_Camara_Pos.y, MAx_Camara_Pos.y),
            transform.position.z);
    }
}
