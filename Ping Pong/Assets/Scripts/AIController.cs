using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public BallManager ballManager;
    //public GameObject ball;
    private Vector2 ballY;
    private Vector2 velocity;
    public float speed = 1;
    private float maxDistance = 3.15f;
    private void FixedUpdate()
    {
        foreach (GameObject go in ballManager.ballList)
        {
            velocity = go.GetComponent<Rigidbody2D>().velocity;
            if (Mathf.Sign(velocity.x) != -1)
            {
                ballY = go.transform.position;
                break;
            }
        }
        if (ballY.x < transform.position.x)
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
}
