using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject ballAnc;
    [SerializeField] private GameObject basketTrigger;
    [SerializeField] private GameObject ForceGo;
    [SerializeField] private Image _forceImg;
    [SerializeField] private float forceChangeSpeed;
    private bool addForce;

    private GameObject _ball;
    private bool _ballToHand;
    private Rigidbody _ballRb;
    private Collider _ballCol;
    public bool ballInHand;


    private bool _preparing;

    private PlayerController _playerController;
    private Rigidbody _thisRB;

    private void Start()
    {

        _ballToHand = false;
        ballInHand = false;
        _preparing = false;
        _ball = GameObject.Find("Ball");
        _ballRb =_ball.GetComponent<Rigidbody>();
        _ballCol = _ball.GetComponent<Collider>();
        _playerController = this.GetComponent<PlayerController>();
        _thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_preparing)
        {
            switch(addForce)
            {
                case true:
                    _forceImg.fillAmount += Time.deltaTime * forceChangeSpeed;

                    break;
                case false:
                    _forceImg.fillAmount -= Time.deltaTime * forceChangeSpeed;

                    break;
            }

            if (_forceImg.fillAmount is >= 1 or <= 0)
            {
                addForce = !addForce;
            }

            if (Input.GetAxisRaw("Fire1") == 1)
            {
                _preparing = false;
                _playerController.ChangeState("Shoot");
            }
        }

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
                _ballRb.isKinematic = true;
                _ballCol.enabled = false;
                ballInHand = true;

            }
        }

        if ((Input.GetAxisRaw("Jump") == 1) && ballInHand)
        {
            _playerController.ChangeState("Preparing");
            _thisRB.isKinematic = true;
            var direction = new Vector3(basketTrigger.transform.position.x,transform.position.y,basketTrigger.transform.position.z);
            transform.LookAt(direction);
            ballInHand = false;
            _preparing = true;
            ForceGo.SetActive(true);
        }
    }

    public void OnTrow()
    {
        _ball.GetComponent<FlyingBall>().enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,
            new Vector3(basketTrigger.transform.position.x,transform.position.y,basketTrigger.transform.position.z));
    }

    public void ShootEnd()
    {
        _playerController.ChangeState("Idle");
        _thisRB.isKinematic = false;
        _forceImg.fillAmount = 0;
        ForceGo.SetActive(false);
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
