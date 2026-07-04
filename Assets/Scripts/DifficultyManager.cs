using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public void CalculateDifficulty(float reactionTime)
    {
        if (reactionTime < 0.25f)
        {
            GameManager.instance.difficultyLevel = "Hard";
            GameManager.instance.obstacleSpeed = 7f;
            GameManager.instance.beatsPerSpawn = 1;
        }
        else if (reactionTime < 0.40f)
        {
            GameManager.instance.difficultyLevel = "Medium";
            GameManager.instance.obstacleSpeed = 5f;
            GameManager.instance.beatsPerSpawn = 2;
        }
        else
        {
            GameManager.instance.difficultyLevel = "Easy";
            GameManager.instance.obstacleSpeed = 3.5f;
            GameManager.instance.beatsPerSpawn = 3;
        }

        Debug.Log("Difficulty set to: " + GameManager.instance.difficultyLevel);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
