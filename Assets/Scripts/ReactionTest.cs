using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ReactionTest : MonoBehaviour
{

    public TextMeshProUGUI reactionText;
    public DifficultyManager difficultyManager;

    private float startTime;
    private bool waitingForInput = false;
    public float reactionTime;

    public bool isPreTest = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BeginReactionTest());
    }

    IEnumerator BeginReactionTest()
    {
        reactionText.text = "Wait for the signal...";
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        reactionText.text = "PRESS SPACE NOW!";
        startTime = Time.time;
        waitingForInput = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (waitingForInput && Input.GetKeyDown(KeyCode.Space))
        {
            reactionTime = Time.time - startTime;
            waitingForInput = false;

            if (isPreTest)
            {
                GameManager.instance.reactionBefore = reactionTime;

                if (difficultyManager != null)
                {
                    difficultyManager.CalculateDifficulty(reactionTime);
                }
            }
            else
            {
                GameManager.instance.reactionAfter = reactionTime;
            }

            reactionText.text = "Reaction Time: " + reactionTime.ToString("F3") + " seconds";

            StartCoroutine(NextSceneAfterDelay());
        }
    }
    IEnumerator NextSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        if (isPreTest)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("ResultsScene");
        }
    }

}
