using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem particles;
    private bool settingVelocity = true;
    private float ballIncrease = 1.1f;
    private float maxSpeed = 15;
    private float minSpeed = 2f;
    private bool pastMinY = false;
    private Vector2 velocity;
    public bool invert = false;
    public Camera c;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particles = GetComponentInChildren<ParticleSystem>();
        if (velocity == null)
        {
            velocity = new Vector2(-3.5f, 4);
        }
    }

    private void FixedUpdate()
    {
        if ( invert == true)
        {
            InvertMovement();
            invert = false;
        }
        if (settingVelocity)
        {
            rb.velocity = velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            collision.gameObject.GetComponent<Goal>().Scored(gameObject);
            GetComponent<TrailRenderer>().Clear();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameMaster.gm.gameAudio.PlayWallSound();
            velocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);
            BurstParticles(5);
        }
        if (collision.gameObject.CompareTag("Ping"))
        {
            GameMaster.gm.gameAudio.PlayPaddleSound();
            velocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);
            float randomDir = Mathf.Sign(velocity.y) * (Mathf.Abs(velocity.y) + Random.Range(-1.5f, 1.6f));
            velocity = new Vector2(velocity.x * ballIncrease, randomDir);
            BurstParticles(8);
        }
        CapVelocity();
    }

    //Simulates collision to destroy balls when colliding on the top or bottom.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ping"))
        {
            if (Mathf.Abs(collision.gameObject.transform.position.x) - 0.2f <= Mathf.Abs(gameObject.transform.position.x))
            {
                GameMaster.gm.gameAudio.PlayPaddleSound();
                BurstParticles(12);
                transform.DetachChildren();
                var main = particles.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                Destroy(gameObject);
            }
        }
    }
    public void SetVelocity(Vector2 v2)
    {
        velocity = v2;
    }
    public void DisableVelocity()
    {
        settingVelocity = false;
    }
    private void CapVelocity()
    {
        velocity = new Vector2(Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed));
        if (Mathf.Abs(velocity.x) < minSpeed)
        {
            velocity.x = minSpeed * Mathf.Sign(velocity.x);
        }
        if (pastMinY == false)
        {
            if (Mathf.Abs(velocity.y) < minSpeed)
            {
                velocity.y = minSpeed * Mathf.Sign(velocity.y);
            }
        }
        pastMinY = !pastMinY;
    }

    private void BurstParticles(int amount)
    {
        particles.Emit(amount);
    }
    public void InvertMovement()
    {
        if (c.transform.rotation != Quaternion.Euler(0, 0, 90))
        {
            c.transform.rotation = Quaternion.Euler(0, 0, 90);
            c.orthographicSize = 7;
        }
        else
        {
            c.transform.rotation = Quaternion.Euler(0, 0, 0);
            c.orthographicSize = 5;
        }
        transform.position = new Vector2(transform.position.y, transform.position.x);
        velocity = new Vector2(velocity.y, velocity.x);
    }
}
