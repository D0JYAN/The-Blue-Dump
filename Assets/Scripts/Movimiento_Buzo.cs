using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Movimiento_Buzo : MonoBehaviour
{
    //Variable globales.
    public float Speed;

    public event EventHandler muerteBuzo;

    private Rigidbody2D Rigidbody2D;
    private Vector2 moveInput;

    [Header("Barra De Salud")]
    [SerializeField] public int Vida = 8;
    [SerializeField] private GameObject Barra_Vida;
    [SerializeField] private Sprite vida_10, vida_9, vida_8, vida_7, vida_6, vida_5, vida_4, vida_3, vida_2, vida_1, vida_0;

    public bool Daño_Buzo;
    public int Empuje;

    [SerializeField] public Animator Ani_Buzo;

    //Movil
    public Joystick joystick;
    private Vector2 move_joystick;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Ani_Buzo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Capturar el input del juagdor.
        float moveX = Input.GetAxisRaw("Horizontal");//Si pulsa la A = -1, si pulsa la D = 1 y si no pulsa nada = 0.
        float moveY = Input.GetAxisRaw("Vertical");//Si pulsa la S = -1, si pulsa la W = 1 y si no pulsa nada = 0.
        moveInput = new Vector2(moveX, moveY);

        //Movimiento con el joystick
        float Vert_Move = joystick.Vertical;
        float Hori_Move = joystick.Horizontal;
        move_joystick = new Vector2(Hori_Move, Vert_Move);

        //Girar al personaje pero con el joystick
        if (Hori_Move < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Hori_Move > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


        //Girar al personaje.
        if (moveX < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    //Mover objetos en funcion de la velocidad.
    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + moveInput * Speed * Time.fixedDeltaTime);

        Rigidbody2D.MovePosition(Rigidbody2D.position + move_joystick * Speed * Time.fixedDeltaTime);
    }

    //Vida del personaje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Burbujas_Contaminadas")
        {
            Debug.Log("Quita salud");
            PierdeVida();
        }

        if (collision.gameObject.tag == "Burbujas_Sanas")
        {
            Debug.Log("Ganar Vida");
            GanaVida();
        }

        if (collision.gameObject.tag == "Medusa")
        {
            Debug.Log("perder vida por medusa");
            PierdeVida();
        }
    }


    private void PierdeVida()
    {
        if (Vida > 1)
        {
            Debug.Log("Pierde Vida");
            Vida--;
            Barra_Vida_Buzo(Vida);
        } else
        {
            Barra_Vida.GetComponent<Image>().sprite = vida_0;
            muerteBuzo?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            //Reaparecer();
        }
    }

    private void Barra_Vida_Buzo(int salud)
    {
        if (salud == 9) Barra_Vida.GetComponent<Image>().sprite = vida_9;
        if (salud == 8) Barra_Vida.GetComponent<Image>().sprite = vida_8;
        if (salud == 7) Barra_Vida.GetComponent<Image>().sprite = vida_7;
        if (salud == 6) Barra_Vida.GetComponent<Image>().sprite = vida_6;
        if (salud == 5) Barra_Vida.GetComponent<Image>().sprite = vida_5;
        if (salud == 4) Barra_Vida.GetComponent<Image>().sprite = vida_4;
        if (salud == 3) Barra_Vida.GetComponent<Image>().sprite = vida_3;
        if (salud == 2) Barra_Vida.GetComponent<Image>().sprite = vida_2;
        if (salud == 1) Barra_Vida.GetComponent<Image>().sprite = vida_1;
        if (salud == 0) Barra_Vida.GetComponent<Image>().sprite = vida_0;
    }

    private void Reaparecer()
    {
        Rigidbody2D.velocity = Vector3.zero;
        transform.position = moveInput;
        Barra_Vida.GetComponent<Image>().sprite = vida_4;
        Vida = 4;
    }

    private void GanaVida()
    {
        if (Vida < 10)
        {
            Debug.Log("Gana Vida");
            Vida++;
            Barra_Vida_Buzo_1(Vida);
        }
    }

    private void Barra_Vida_Buzo_1(int salud)
    {
        if (salud == 10) Barra_Vida.GetComponent<Image>().sprite = vida_10;
        if (salud == 9) Barra_Vida.GetComponent<Image>().sprite = vida_9;
        if (salud == 8) Barra_Vida.GetComponent<Image>().sprite = vida_8;
        if (salud == 7) Barra_Vida.GetComponent<Image>().sprite = vida_7;
        if (salud == 6) Barra_Vida.GetComponent<Image>().sprite = vida_6;
        if (salud == 5) Barra_Vida.GetComponent<Image>().sprite = vida_5;
        if (salud == 4) Barra_Vida.GetComponent<Image>().sprite = vida_4;
        if (salud == 3) Barra_Vida.GetComponent<Image>().sprite = vida_3;
        if (salud == 2) Barra_Vida.GetComponent<Image>().sprite = vida_2;
        if (salud == 1) Barra_Vida.GetComponent<Image>().sprite = vida_1;
        
    }

}
