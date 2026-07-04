using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public string nextSceneName;
    public LevelTimer levelTimer;
    public RhythmAccuracy rhythmAccuracy;

    private bool hasFinished = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasFinished && other.CompareTag("Player"))
        {
            hasFinished = true;

            //adds time
            GameManager.instance.totalTime += levelTimer.timer;

            //adds accuracy once per level
            GameManager.instance.totalAccuracy += rhythmAccuracy.averageAccuracy;
            GameManager.instance.levelsPlayed++;

            SceneManager.LoadScene(nextSceneName);
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
