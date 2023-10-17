using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GoalBallSpawner goalBallSpawner;
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        scoreText.text = score.ToString();  
    }

    public void SpawnGoalBall()
    {
        goalBallSpawner.SpawnGoalBall();
    }

    public void IncreaseScoreAmount()
    {
        score++;
        scoreText.text = score.ToString();  
    }

    public void DiedRestartGame()
    {
        Debug.Log("YouDied");
        Invoke("RestartGameForInvoke", 1);
    }

    void RestartGameForInvoke()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
