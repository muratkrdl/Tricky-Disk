using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float lineMoveSpeed = 4;
    [SerializeField] LineRenderer line;
    [SerializeField] float lineXRange = .5f;

    Vector3 direction;
    float changeableXRange;

    float elapsed = 0;
    float duration = 1;
    float t;

    public bool ballThrowed = false;
    bool lineCanMove = false;

    void Start() 
    {
        changeableXRange = -lineXRange;
        direction = new Vector3(0,1,0);
        line.SetPosition(1,direction);
    }

    void Update()
    {
        if(ballThrowed) { return; }

        if(Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }  

        if(!lineCanMove) { return; }
        elapsed += Time.deltaTime;
        MoveLine();
        ChangeLinePos();
    }

    void ChangeLinePos()
    {
        if(line.GetPosition(1).x < -lineXRange + .02f || line.GetPosition(1).x > lineXRange - .02f)
        {
            elapsed = 0;
            changeableXRange *= -1;
        }
    }

    void MoveLine()
    {
        t = elapsed / duration;
        Vector3 newPosForLine = line.GetPosition(1);
        
        newPosForLine.x = Mathf.Lerp(newPosForLine.x, changeableXRange, t * lineMoveSpeed * Time.deltaTime);

        line.SetPosition(1,newPosForLine);
        direction = newPosForLine;
    }

    void ThrowBall()
    {
        if(lineCanMove != true) { lineCanMove = true; }
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Ball>().ThrowBall(direction);
        ballThrowed = true;
    }

}
