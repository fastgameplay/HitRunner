using System;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
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
    private ThirdPersonCharacter _thirdPersonCharacter;
    private NavMeshAgent _currentAgent;
    private Vector3 _target;
    private bool _isMoving;

    void Awake(){
        _currentAgent = GetComponent<NavMeshAgent>();
        _thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        _currentAgent.updateRotation = false;
        InvokeRepeating("CheckDestination", TIME_BETWEEN_EXECUTION, TIMER_DELAY);
    }
    void Update(){
        if(_isMoving == false) return;
        _thirdPersonCharacter.Move(_currentAgent.desiredVelocity, false, false);
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
