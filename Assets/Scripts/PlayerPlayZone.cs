using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayZone : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (_playerTransform.position.x > maxX)
        {
            _playerTransform.position = new Vector3(maxX, _playerTransform.position.y, _playerTransform.position.z);
        }
        if (_playerTransform.position.x < minX)
        {
            _playerTransform.position = new Vector3(minX, _playerTransform.position.y, _playerTransform.position.z);
        }
        if (_playerTransform.position.z > maxZ)
        {
            _playerTransform.position = new Vector3(_playerTransform.position.x,_playerTransform.position.y, maxZ);
        }
        if (_playerTransform.position.z < minZ)
        {
            _playerTransform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, minZ);
        }
    }
}
