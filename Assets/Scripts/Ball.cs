using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidBody;

    [SerializeField] float throwForce = 500f;

    Vector3 turnBackDirection;

    public void ThrowBall(Vector3 direction)
    {
        turnBackDirection = direction;
        myRigidBody.AddForce(direction * throwForce);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            myRigidBody.velocity = Vector2.zero;
            GameManager.Instance.DiedRestartGame();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Catch"))
        {
            Destroy(gameObject);

            if(FindObjectOfType<BallThrower>() != null)
            {
                FindObjectOfType<BallThrower>().ballThrowed = false;
            }

            GameManager.Instance.SpawnGoalBall();
        }

        if(other.CompareTag("Goal"))
        {
            if(other.gameObject.GetComponent<GoalBall>() != null)
            {
                other.gameObject.GetComponent<GoalBall>().Died();
            }

            GameManager.Instance.IncreaseScoreAmount();

            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(-turnBackDirection * throwForce);
        }  
    }

}
