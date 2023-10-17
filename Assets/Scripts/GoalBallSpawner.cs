using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBallSpawner : MonoBehaviour
{
    [SerializeField] GameObject goalBallPrefab;
    [SerializeField] float xRange;
    [SerializeField] float ballLerpSpeed = 3f;

    void Start() 
    {
        var goalBall = Instantiate(goalBallPrefab, transform.position, Quaternion.identity);
        Vector2 newPos = goalBall.transform.position;
        newPos.x = 0;
        goalBall.transform.position = newPos;
    }

    public void SpawnGoalBall()
    {
        float chosenXPos = Random.Range(-xRange, xRange + .003f);
        var goalBall = Instantiate(goalBallPrefab, transform.position, Quaternion.identity);
        Vector2 newPos = goalBall.transform.position;
        newPos.x = chosenXPos;
        goalBall.transform.position = newPos;
    }

}
