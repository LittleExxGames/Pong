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
        if (ballY.x <= transform.position.x - 0.2f)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, Mathf.Clamp(ballY.y, -maxDistance, maxDistance)), Time.deltaTime * speed);
        }

        //Debug.Log("This is AI ball target position --- " + ballY);
        //transform.position = Vector3.MoveTowards(paddle, new Vector3(ball.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);
        //transform.position = Vector2.Lerp(paddle, new Vector2(ball.transform.position.x, transform.position.y), Time.deltaTime * speed);

        //if (Mathf.Abs(transform.position.y) < maxDistance)
        //{
        //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, Mathf.Clamp(ball.transform.position.y, -maxDistance, maxDistance)), Time.deltaTime * speed);
        //}
        
    }
}
