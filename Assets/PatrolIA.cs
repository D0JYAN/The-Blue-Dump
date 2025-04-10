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

    // Update is called once per frame
    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            //currentWaypoint++;
            StartCoroutine(Wait());
        }

        
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if(currentWaypoint == waypoints.Length){
            currentWaypoint = 0;
        }
        isWaiting = false;
    }

    
}
