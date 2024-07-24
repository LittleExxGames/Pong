using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private static float speed = 7;
    private float maxDistance = 3.15f;
    private Rigidbody2D rb;
    private static bool canControl = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canControl)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y > -maxDistance)
        {
            rb.velocity = new Vector2(0, -1) * speed;
            if (rb.position.y < -maxDistance)
            {
                rb.position = new Vector2(rb.position.x, -maxDistance);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y < maxDistance)
        {
            rb.velocity = new Vector2(0, 1) * speed;
            if (rb.position.y > maxDistance)
            {
                rb.position = new Vector2(rb.position.x, maxDistance);
            }
        }
        else
        {
            //rb.velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(0, Mathf.Lerp(rb.velocity.y, 0, Time.deltaTime * 50));
        }
    }

    public static void CanControl(bool set)
    {
        canControl = set;
    }
    public static void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
