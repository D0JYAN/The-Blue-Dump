using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInRange = true;
    }


}
