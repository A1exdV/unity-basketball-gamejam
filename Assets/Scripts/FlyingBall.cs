using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingBall : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    [SerializeField] private GameObject target;
    [SerializeField] private Image forceImg;

    private float _force;
    private float _timer;
    void OnEnable()
    {
        transform.parent = null;
        _startPos = transform.position;
        _endPos = target.transform.position;
        _timer = 0;
        _force = forceImg.fillAmount;

        if (_force is <= 0.65f or >= 0.765f)
        {
            _endPos += new Vector3(Random.Range(-5, 5), 0, 0);
        }
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
            _timer += Time.deltaTime;
            var duration = 0.5f;
            var t01 = _timer / duration;
            var pos = Vector3.Lerp(_startPos, _endPos, t01);

            var arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            transform.position = pos + arc;
        }
    }
}
