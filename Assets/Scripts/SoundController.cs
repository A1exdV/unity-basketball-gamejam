using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip jump;

    [SerializeField] private AudioClip ballBounce;

    [SerializeField] private List<AudioClip> steps;
    [SerializeField] private AudioSource playerAudioSource;

    private BallController _ballController;

    public void Start()
    {
        _ballController = GetComponent<BallController>();
    }

    public void Step()
    {
        playerAudioSource.clip = steps[Random.Range(0, steps.Count - 1)];
        playerAudioSource.Play();
    }

    public void Bounce()
    {
        if (_ballController.ballInHand)
        {
            playerAudioSource.clip = ballBounce;
            playerAudioSource.Play();
        }
    }

    public void Jump()
    {
        playerAudioSource.clip = jump;
        playerAudioSource.Play();
    }
}