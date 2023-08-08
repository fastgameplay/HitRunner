using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Transform Target{
        set{
            _target = value;
        }
    }
    [SerializeField] 
    private Vector3 _forwardDirection;
    [SerializeField] 
    private Transform _target;
    void OnValidate(){
        if(_forwardDirection == Vector3.zero) _forwardDirection = Vector3.forward;
        _forwardDirection = _forwardDirection.normalized;
    }
    void Update(){
        if(_target == null) return;
        transform.rotation = Quaternion.LookRotation(_target.position, _forwardDirection);
    }
}
