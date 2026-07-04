using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float reactionBefore;
    public float reactionAfter;

    public int totalCollisions = 0;
    public float totalTime = 0f;
    public float totalAccuracy = 0f;
    public int levelsPlayed = 0;

    public bool isGameplayActive = true;

    public float averageBeatAccuracy;

    public string difficultyLevel = "Medium";
    public float obstacleSpeed = 5f;
    public int beatsPerSpawn = 2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        
        }
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
