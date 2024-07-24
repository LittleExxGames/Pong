using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public BallManager ballManager;
    private Vector2 ballY;
    private bool found = false;
    private Vector2 velocity;
    private static float speed = 7;
    private float maxDistance = 3.15f;
    private Rigidbody2D rb;
    private static bool canMove = true;

    private void Awake()
    {
        ballManager = GameMaster.ballManager;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        if (transform.position.x > 0)
        {
            foreach (GameObject go in ballManager.ballList)
            {
                velocity = go.GetComponent<Rigidbody2D>().velocity;
                if (Mathf.Sign(velocity.x) == Mathf.Sign(transform.position.x))
                {
                    ballY = go.transform.position;
                    found = true;
                    break;
                }
            }
        }
        else
        {
            foreach (GameObject go in ballManager.ballList.AsEnumerable().Reverse())
            {
                velocity = go.GetComponent<Rigidbody2D>().velocity;
                if (Mathf.Sign(velocity.x) == Mathf.Sign(transform.position.x))
                {
                    ballY = go.transform.position;
                    found = true;
                    break;
                }
            }
        }

        if (Mathf.Abs(ballY.x) < Mathf.Abs(transform.position.x) && found)
        {
            rb.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Mathf.Clamp(ballY.y, -maxDistance, maxDistance)), Time.deltaTime * speed);
        }

        found = false;
    }

    public static void CanMove(bool set)
    {
        canMove = set;
    }

    public static void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}