using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshPro textOnWall;
    [SerializeField] private TextMeshProUGUI textEndGame;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private Transform player;
    private int _score;

    private void Start()
    {
        _score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            _score += (int)(transform.position - player.position).magnitude;
            textEndGame.text = "Score: " + _score;
            textOnWall.text = "Score: " + _score;
            if (_score > 100)
            {
                endText.text = "Jordan, is that you?";
                return;
            }

            if (_score > 60)
            {
                endText.text = "Admit it, have you trained anywhere?";
                return;
            }

            if (_score > 30)
            {
                endText.text = "Not bad for a beginner";
            }
        }
    }
}