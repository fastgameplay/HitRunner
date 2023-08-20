using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAgentMovement))]
public class PlayerCyclicMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _targets; 
    private PlayerAgentMovement _currentAgentMovement;
    int _currentTarget;
    private void Awake(){
        _currentAgentMovement = GetComponent<PlayerAgentMovement>();
        _currentTarget = 0;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            // _currentAgentMovement.Target = GetNextTarget().position;
        }
    }

    private Transform GetNextTarget(){
        _currentTarget = (_currentTarget + 1) % _targets.Length;
        return _targets[_currentTarget];
    }
}
