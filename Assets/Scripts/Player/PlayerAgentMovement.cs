using System;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAgentMovement : MonoBehaviour
{
    const float TIMER_DELAY = 1f;
    const float TIME_BETWEEN_EXECUTION = 1f;
    public Action OnPathEndReached;
    public Vector3 Target{
        set{
            if(_target == value) return;
            _target = value;
            _isMoving = true;
            _currentAgent.SetDestination(_target);
        }

    } 
    private Vector3 _target;
    private NavMeshAgent _currentAgent;
    private bool _isMoving;

    void Awake(){
        _currentAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("CheckDestination", TIME_BETWEEN_EXECUTION, TIMER_DELAY);
    }


    public void CheckDestination(){
        Debug.Log($"IsMoving = {_isMoving}");
        if(_isMoving == false) return;
        if (_currentAgent.remainingDistance > _currentAgent.stoppingDistance) return;
        if (!_currentAgent.hasPath || _currentAgent.velocity.sqrMagnitude == 0f)
        {
            OnPathEndReached?.Invoke();
            Debug.Log("REACHED PATH END");
            _isMoving = false;
        }
    }


}
