using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    [SerializeField] Transform _target;
    void Update() => transform.SetPositionAndRotation(_target.position, _target.rotation);
}
