using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform Player;

    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    { 
        if(Vector2.Distance(transform.position, Player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }

        bool isPlayerRight = transform.position.x < Player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Attack()
    {
        Debug.Log("Atacar");
    }

    private void Flip(bool isPlayerRight)
    {
        if((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
