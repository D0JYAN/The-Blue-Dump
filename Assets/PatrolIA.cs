using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolIA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint;
    private bool isWaiting;

    private void Update()
    {
        // Verifica si ya llegó al destino
        if (transform.position != waypoints[currentWaypoint].position)
        {
            // Mueve al enemigo hacia el waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

            // Calcular dirección para voltear el sprite
            float direccionX = waypoints[currentWaypoint].position.x - transform.position.x;

            if (direccionX != 0) // Evitar división por cero
            {
                // Voltear sprite según dirección en X
                Vector3 escala = transform.localScale;
                escala.x = direccionX > 0 ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
                transform.localScale = escala;
            }
        }
        else if (!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

        isWaiting = false;
    }
}
