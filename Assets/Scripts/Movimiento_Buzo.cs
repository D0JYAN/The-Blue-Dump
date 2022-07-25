using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Buzo : MonoBehaviour
{
    //Variable globales.
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Capturar el input del juagdor.
        float moveX = Input.GetAxisRaw("Horizontal");//Si pulsa la A = -1, si pulsa la D = 1 y si no pulsa nada = 0.
        float moveY = Input.GetAxisRaw("Vertical");//Si pulsa la S = -1, si pulsa la W = 1 y si no pulsa nada = 0.
        moveInput = new Vector2(moveX, moveY);

        //Girar al personaje.
        if (moveX < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    //Mover objetos en funcion de la velocidad.
    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + moveInput * Speed * Time.fixedDeltaTime);
    }

    //Vida del personaje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Burbujas_Contaminadas")
        {
            Debug.Log("Quita salud");
            PierdeVida();
        }
    }

    private void PierdeVida()
    {
        Debug.Log("Pierde Vida");
        Reaparecer();
    }

    private void Reaparecer()
    {
        Rigidbody2D.velocity = Vector3.zero;
        transform.position = moveInput;
    }

}
