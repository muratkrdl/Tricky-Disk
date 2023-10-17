using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBall : MonoBehaviour
{
    [SerializeField] GameObject goalParticle;

    public void Died()
    {
        Instantiate(goalParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
