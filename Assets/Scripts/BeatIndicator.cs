using UnityEngine;
using TMPro;
using System.Collections;
public class BeatIndicator : MonoBehaviour
{
    public TextMeshProUGUI beatText;

    public void ShowBeat()
    {
        StartCoroutine(FlashBeat());
    }

    IEnumerator FlashBeat()
    {
        beatText.text = "BEAT!";
        yield return new WaitForSeconds(0.1f);
        beatText.text = "";
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
