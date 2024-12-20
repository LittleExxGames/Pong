using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem particles;
    [SerializeField] private GameObject lightBurstPref;
    private static float brightness = 0;
    private bool settingVelocity = true;
    private float ballIncrease = 1.1f;
    private float maxSpeed = 20;
    private float minSpeed = 3.5f;
    private bool pastMinY = false;
    private Vector2 velocity = new Vector2(-3.5f, 4);
    private Vector2 enterVel;
    public bool invert = false;
    public Camera c;

    private void Start()
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
        if (invert == true)
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
            enterVel = rb.velocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (Mathf.Sign(enterVel.x) == Mathf.Sign(rb.velocity.x))
            {
                collision.gameObject.GetComponent<Goal>().Scored(gameObject);
                GetComponent<TrailRenderer>().Clear();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameMaster.gameAudio.PlayWallSound();
            velocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);
            BurstParticles(5);
            BurstLight();
        }
        if (collision.gameObject.CompareTag("Ping"))
        {
            if (collision.contacts[0].normal.y > 0 || collision.contacts[0].normal.y < 0)
            {
                GameMaster.gameAudio.PlayPaddleSound();
                BurstParticles(12);
                transform.DetachChildren();
                var main = particles.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                Destroy(gameObject);
            }
            else
            {
                GameMaster.gameAudio.PlayPaddleSound();
                velocity = Vector2.Reflect(velocity, collision.GetContact(0).normal);
                float randomDir = 0;
                if (velocity.y <= 0.2f && velocity.y >= -0.2f)
                {
                    randomDir = Mathf.Sign(velocity.y) * (Mathf.Abs(velocity.y) + Random.Range(-1.6f, 1.6f));
                }
                else if (velocity.y > 0.2f)
                {
                    randomDir = Mathf.Sign(velocity.y) * (Mathf.Abs(velocity.y) + Random.Range(-1.6f, 1.6f));
                    Mathf.Clamp(randomDir, 0, -Mathf.Infinity);
                }
                else if (velocity.y < -0.2f)
                {
                    randomDir = Mathf.Sign(velocity.y) * (Mathf.Abs(velocity.y) + Random.Range(-1.6f, 1.6f));
                    Mathf.Clamp(randomDir, 0, -Mathf.Infinity);
                }
                velocity = new Vector2(velocity.x * ballIncrease, randomDir);
                BurstParticles(8);
                BurstLight();
            }
        }
        CapVelocity();
    }

    //Simulates collision to destroy balls when colliding on the top or bottom.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ping"))
        {
            if (collision.contacts[0].normal.y > 0 || collision.contacts[0].normal.y < 0)
            {
                GameMaster.gameAudio.PlayPaddleSound();
                BurstParticles(12);
                transform.DetachChildren();
                var main = particles.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                BurstLight();
                Destroy(gameObject);
            }
        }
    }

    public void SetVelocity(Vector2 v2)
    {
        velocity = v2;
        CapVelocity();
    }

    public void DisableVelocity()
    {
        settingVelocity = false;
    }

    public void SetMaxVelocity(float newMax)
    {
        maxSpeed = newMax;
    }

    public void SetMinVelocity(float newMin)
    {
        minSpeed = newMin;
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
        pastMinY = Random.Range(0, 2) == 1;
    }

    private void BurstParticles(int amount)
    {
        particles.Emit(amount);
    }

    public static void SetBrightness(float newBrightness)
    {
        brightness = newBrightness;
    }

    public void BurstLight()
    {
        GameObject burst = Instantiate(lightBurstPref);
        burst.transform.position = transform.position;
        LightBurst lb = burst.GetComponent<LightBurst>();
        lb.StartCoroutine(lb.Burst(brightness));
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