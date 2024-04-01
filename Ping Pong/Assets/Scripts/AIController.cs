using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public BallManager ballManager;
    private Vector2 ballY;
    private Vector2 velocity;
    public float speed = 1;
    private float maxDistance = 3.15f;
    private static bool canMove = true;
    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        foreach (GameObject go in ballManager.ballList)
        {
            velocity = go.GetComponent<Rigidbody2D>().velocity;
            if (Mathf.Sign(velocity.x) == Mathf.Sign(transform.position.x))
            {
                ballY = go.transform.position;
                break;
            }
        }
        if (Mathf.Abs(ballY.x) < Mathf.Abs(transform.position.x))
        {
            if (Mathf.Abs(ballY.y - transform.position.y) < 0.5f || Mathf.Abs(Mathf.Abs(transform.position.y) - maxDistance) < 0.5f)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, Mathf.Clamp(ballY.y, -maxDistance, maxDistance)), Time.deltaTime * speed);
                Debug.Log("Using Lerp");
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Mathf.Clamp(ballY.y, -maxDistance, maxDistance)), Time.deltaTime * speed);
                Debug.Log("Using MoveTowards");
            }
        }  
    }
    public static void CanMove(bool set)
    {
        canMove = set;
    }
}
