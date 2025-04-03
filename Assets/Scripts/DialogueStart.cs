using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{

    [SerializeField] private GameObject dialogueMark;

    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Se puede iniciar dialogo");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("No se puede iniciar dialogo");
        }
            
    }

}
