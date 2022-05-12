using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator _animator;
    private GameObject _ball;
    private string _currentState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _ball = GameObject.Find("Ball");
        _currentState = "Idle";
    }

    private void FixedUpdate()
    {
        if (_currentState is "Shoot" or "Preparing")
        {
            return;
        }
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


        transform.position -= direction * (speed * Time.deltaTime);
        transform.LookAt(transform.position + direction);


        if (direction != Vector3.zero)
        {
            ChangeState("Run");
        }
        else
        {
            ChangeState("Idle");
        }
    }

    public void ChangeState(string state)
    {
        switch (state)
        {
            case "Run":
                _animator.Play("Run_ball");
                _currentState = "Run";
                break;
            case "Idle":
                _animator.Play("Idle_ball");
                _currentState = "Idle";
                break;
            case "Shoot":
                _animator.Play("Shoot");
                _currentState = "Shoot";
                break;
            case "Preparing":
                _animator.Play("Preparing");
                _currentState = "Preparing";
                break;
        }
    }
}