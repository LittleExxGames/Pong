using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour//, IComparable
{
    public List<GameObject> ballList;
    [SerializeField]
    private GameObject ballPrefab;

    private void Update()
    {
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
        go.transform.position = Vector2.zero;
        Vector2 start = new Vector2(Random.Range(1f, 5f), Random.Range(1f, 5f));
        Vector2 direction = new Vector2(Random.Range(0, 2) * 2 - 1, Random.Range(0, 2) * 2 - 1);
        go.GetComponent<Ball>().SetVelocity(start * direction);
    }
    /*public float CompareTo(GameObject go)
    {
        for (int i = 0; i < ballList.Count; i++)
        {

        }
    }*/
}
