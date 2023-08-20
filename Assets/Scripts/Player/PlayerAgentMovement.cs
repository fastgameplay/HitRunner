using System;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerAgentMovement : PlayerBased
{
    private ThirdPersonCharacter _thirdPersonCharacter;
    private NavMeshAgent _currentAgent;

    private Vector3 _target;
    private bool _isMoving;

     protected override void Awake(){
        base.Awake();
        _currentAgent = GetComponent<NavMeshAgent>();
        _thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        _currentAgent.updateRotation = false;
    }
    void Update(){
        if(_isMoving == false) return;
    
        _thirdPersonCharacter.Move(_currentAgent.desiredVelocity, false, false);
        CheckDestination();
    }

    private void CheckDestination(){
        if(_isMoving == false) return;
        if (_currentAgent.remainingDistance > _currentAgent.stoppingDistance) return;
        if (!_currentAgent.hasPath || _currentAgent.velocity.sqrMagnitude == 0f)
        {
            player.ID.Events.OnDestinationReached?.Invoke();
            _thirdPersonCharacter.StopAndFaceDirection(Vector3.zero);
            _isMoving = false;
        }
    }
    private void Move(Vector3 value){
        if(_target == value) return;
        _target = value;
        _isMoving = true;
        _currentAgent.SetDestination(_target);
    }
    void OnEnable(){
        player.ID.Events.OnMovement += Move;
    }
    void OnDisable(){
        player.ID.Events.OnMovement -= Move;
    }

}
