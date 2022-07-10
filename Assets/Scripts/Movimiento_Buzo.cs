using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Buzo : MonoBehaviour
{
    //Variable globales.
    public float JumpForce;
    public float DescendForce;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Capturar el input del juagdor.
        Horizontal = Input.GetAxisRaw("Horizontal");//Si pulsa la A = -1, si pulsa la D = 1 y si no pulsa nada = 0.

        //Girar al personaje.
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Salto del jugador.
        if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        else//El personaje puede decender.
            if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
        {
            Descend();
        }
    }

    //Invoca al metodo Jump para que el personaje Salte, en este caso suba.
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    //Invoca al metodo Descend para que el personaje descienda.
    private void Descend()
    {
        Rigidbody2D.AddForce(Vector2.down * DescendForce);
    }

    //Mover objetos en funcion de la velocidad.
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }


}
