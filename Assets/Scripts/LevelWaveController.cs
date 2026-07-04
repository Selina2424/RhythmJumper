using System.Collections;
using UnityEngine;
using TMPro;

public class LevelWaveController : MonoBehaviour
{
    public BeatSpawner beatSpawner;

    public GameObject waveClearText;
    public GameObject instructionText;

    public Transform finishObject;
    public Vector3 finishTargetPosition;
    public float slideSpeed = 4f;

    public float waveDuration = 15f;

    private bool moveFinish = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (waveClearText != null)
            waveClearText.SetActive(false);

        if (instructionText != null)
            instructionText.SetActive(false);

        StartCoroutine(RunWaveSequence());
    }




    IEnumerator RunWaveSequence()
    {
        //lets main gameplay run for a set time
        yield return new WaitForSeconds(waveDuration);

        //stops obstacles spawning
        if (beatSpawner != null)
        {
            beatSpawner.canSpawn = false;
            GameManager.instance.isGameplayActive = false;
        }

        //displays wave cleared text
        if (waveClearText != null)
        {
            waveClearText.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        //displays instructions
        if (instructionText != null)
        {
            instructionText.SetActive(true);
        }

        //starts to move finish object into view
        moveFinish = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (moveFinish && finishObject != null)
        {
            finishObject.position = Vector3.MoveTowards(
                finishObject.position,
                finishTargetPosition,
                slideSpeed * Time.deltaTime
            );

            if (Vector3.Distance(finishObject.position, finishTargetPosition) < 0.01f)
            {
                finishObject.position = finishTargetPosition;
                moveFinish = false;
            }
        }
    }
}

