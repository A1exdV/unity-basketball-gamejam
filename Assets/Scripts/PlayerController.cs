using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator _animator;
    private bool _hasBall;
    private GameObject _ball;
    private string _currentState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _hasBall = false;
        _ball = GameObject.Find("Ball");
    }

    private void FixedUpdate()
    {
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (direction != Vector3.zero)
        {
            ChangeState("Run");
        }
        else
        {
            ChangeState("Idle");
        }

        transform.position -= direction * (speed * Time.deltaTime);
        transform.LookAt(transform.position + direction);
    }

    private void ChangeState(string state)
    {
        switch (state)
        {
            case "Run":
                _animator.Play("Run_ball");
                break;
            case "Idle":
                _animator.Play("Idle_ball");
                break;
        }
    }
}