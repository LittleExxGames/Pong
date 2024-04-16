using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour//, IComparable
{
    public List<GameObject> ballList;
    [SerializeField]
    private GameObject ballPrefab;
    private Vector2[] spawnPositions = new Vector2[1] { Vector2.zero };

    private void Start()
    {
        GameMaster.ballManager = this;
    }

    private void Update()
    {
        ReplaceNullObjects();
        ballList.Sort((obj1, obj2) =>
        {
            // Get the x values of the transforms
            float x1 = obj1.transform.position.x;
            float x2 = obj2.transform.position.x;

            // Compare the x values
            if (x1 > x2)
                return -1;
            else if (x1 < x2)
                return 1;
            else
                return 0;
        });

            //Debug.Log("Ball Order: " + ballList[0].name + " And: " + ballList[1]);
    }
    public GameObject SpawnBall()
    {
        GameObject ballPre = Instantiate(ballPrefab);
        ballPre.name = ballPre.name + " " + ballList.Count;
        ballList.Add(ballPre);
        Center(ballPre);
        return ballPre;
    }
    public void Center(GameObject go)
    {
        go.transform.position = spawnPositions[Random.Range(0, spawnPositions.Count())];
        Vector2 start = new Vector2(Random.Range(1f, 6f), Random.Range(1f, 6f));
        Vector2 direction = new Vector2(Random.Range(0, 2) * 2 - 1, Random.Range(0, 2) * 2 - 1);
        go.GetComponent<Ball>().SetVelocity(start * direction);
    }
    private void RemoveNullObjects()
    {
        ballList.RemoveAll(ball => ball == null);
    }
    // Replaces the balls that were destroyed by spawning new ones through detecting if a gameobject is null in ballList.
    private void ReplaceNullObjects()
    {
        for (int i = ballList.Count - 1; i >= 0; i--)
        {      
            if (ballList[i] == null)
            {
                ballList.RemoveAt(i);
                SpawnBall();
            }
        }
    }

    public void BallDrop()
    {
        foreach (GameObject  b in ballList)
        {
            b.GetComponent<BoxCollider2D>().enabled = false;
            b.GetComponent<Rigidbody2D>().gravityScale = 2;
            b.GetComponent<Ball>().DisableVelocity();
            StartCoroutine(DisableWait(b));
        }
    }
    private IEnumerator DisableWait(GameObject b)
    {
        yield return new WaitForSeconds(2f);
        b.SetActive(false);
    }
    public void SetSpawnPositions(Vector2[] positions)
    {
        spawnPositions = positions;
    }
}
