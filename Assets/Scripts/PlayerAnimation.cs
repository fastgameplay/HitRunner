using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public AnimationState State{
        get => _animationState;
        set{
            if(_animationState == value) return;
            _animationState = value;
            Play(value);
        }
    }
    private AnimationState _animationState;
    private Animator _animator;
     
    
    private void Awake(){
        _animator = GetComponent<Animator>();
    }

    private void Play(AnimationState currentState){
        if(currentState == AnimationState.Shooting){
            //PlayIdle + Kinematics To Gun
            _animator.Play("Idle");
            return;
        }
        if(currentState == AnimationState.Idle){
            _animator.Play("Idle");
        }
        if(currentState == AnimationState.Running){
            _animator.Play("Running");
        }

    } 
}
