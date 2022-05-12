using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    [SerializeField] private GameObject target;
    private float timer;
    void OnEnable()
    {
        transform.parent = null;
        _startPos = transform.position;
        _endPos = target.transform.position;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - _endPos).magnitude < 1)
        {
            transform.position = _endPos;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = true;
            GetComponent<FlyingBall>().enabled = false;

        }
        else
        {
            timer += Time.deltaTime;
            var duration = 0.5f;
            var t01 = timer / duration;
            var pos = Vector3.Lerp(_startPos, _endPos, t01);

            var arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            transform.position = pos + arc;
        }
    }
}
