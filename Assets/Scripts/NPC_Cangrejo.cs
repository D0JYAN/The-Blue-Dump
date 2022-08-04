using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Cangrejo : MonoBehaviour
{
    [SerializeField] Animator Animator;
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator.SetBool("Libre", true);
            Debug.Log("Cambia Animacion");
        }
    }
}
