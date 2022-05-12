using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] int timeLeft;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshPro timeText;


    void Start()
    {
        endPanel.SetActive(false);
        StartCoroutine(TimerUpdate());
    }

    IEnumerator TimerUpdate()
    {
        while (timeLeft != 0)
        {
            timeText.text = "Time left\n" + timeLeft;
            timeLeft--;
            yield return new WaitForSeconds(1f);
        }

        endPanel.SetActive(true);
        Time.timeScale = 0;
        yield return null;
    }
}