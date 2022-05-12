using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private AudioSource sound;
    [SerializeField] private LayerMask _groundLayer;
    void Update()
    {

        if (!IsGrounded()) return;
        sound.Play();
    }

    private bool IsGrounded() => Physics.CheckSphere(groundCheck.transform.position, 0.22f, _groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.transform.position, 0.22f);
    }
}
