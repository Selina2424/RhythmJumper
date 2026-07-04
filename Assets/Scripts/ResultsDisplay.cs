using TMPro;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{
    public TextMeshProUGUI resultsText;
    float avgAccuracy = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 

        if (GameManager.instance.levelsPlayed > 0)
        {
            avgAccuracy = GameManager.instance.totalAccuracy / GameManager.instance.levelsPlayed;
        }
        resultsText.text =
         "Pre-Test Reaction Time: " + GameManager.instance.reactionBefore.ToString("F3") + " s" +
            "\nPost-Test Reaction Time: " + GameManager.instance.reactionAfter.ToString("F3") + " s" +
            "\nDifficulty Level: " + GameManager.instance.difficultyLevel +
            "\nCollisions: " + GameManager.instance.totalCollisions +
            "\nCompletion Time: " + GameManager.instance.totalTime.ToString("F2") + " s" +
            "\nAccuracy: " + (avgAccuracy * 100f).ToString("F1") + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
