using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CameraController : MonoBehaviour
{
    [Header("Camera Follow")]
    private Camera _playerCamera;
    [SerializeReference] private Vector3 _offset;
    [SerializeReference] private Transform _Player;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _Player.position + _offset;
    }
}
