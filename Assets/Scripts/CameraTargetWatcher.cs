using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetWatcher : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _lerp;

    private Vector3 _targetPosition;
    private void Start()
    {
        _targetPosition = _target.transform.position;
    }
    private void Update()
    {
        _camera.transform.position += Vector3.Lerp(_camera.transform.position, _targetPosition, _lerp);
    }

}
