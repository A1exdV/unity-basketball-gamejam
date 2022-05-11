using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject ballAnc;
    [SerializeField] private GameObject basketTrigger;
    private GameObject _ball;
    private bool _ballToHand;
    private Rigidbody _ballRB;
    private Collider _ballCol;
    private bool _ballInHand;

    private PlayerController _playerController;
    private Rigidbody _thisRB;

    private void Start()
    {
        _ballToHand = false;
        _ballInHand = false;
        _ball = GameObject.Find("Ball");
        _ballRB =_ball.GetComponent<Rigidbody>();
        _ballCol = _ball.GetComponent<Collider>();
        _playerController = this.GetComponent<PlayerController>();
        _thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_ballToHand )
        {
            if ((_ball.transform.position - ballAnc.transform.position).magnitude > 1)
            {
                _ball.transform.position -= (_ball.transform.position - ballAnc.transform.position) * Time.deltaTime*10;
            }
            else
            {
                _ballToHand = false;
                _ball.transform.position = ballAnc.transform.position;
                _ball.transform.SetParent(ballAnc.transform);
                _ballRB.isKinematic = true;
                _ballCol.enabled = false;
                _ballInHand = true;
            }
        }

        if ((Input.GetAxisRaw("Jump") == 1) && _ballInHand)
        {
            _playerController.ChangeState("Shoot");
            _thisRB.isKinematic = true;
            var direction = new Vector3(basketTrigger.transform.position.x,0,basketTrigger.transform.position.z);
            transform.LookAt(transform.position - direction);
        }
    }

    public void ShootEnd()
    {
        _playerController.ChangeState("Idle");
        _thisRB.isKinematic = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _ball)
        {
            _ballToHand = true;
            Debug.Log("Ball in trigger");
        }
    }
}
