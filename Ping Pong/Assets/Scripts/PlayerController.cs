using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int maxDistance = 3;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y > -maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 0.5f), speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y < maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 0.5f), speed * Time.fixedDeltaTime);
        }
    }
}
