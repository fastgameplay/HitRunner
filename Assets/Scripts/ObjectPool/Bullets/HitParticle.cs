using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HitParticle : MonoBehaviour
{
    private event Action<HitParticle> _onKill;
    private ParticleSystem _currentParticleSystem;
    void Awake(){
        _currentParticleSystem = GetComponent<ParticleSystem>();
    }
    public void SetUp(Vector3 position, Transform lookPosition){
        transform.position = position;
        transform.LookAt(lookPosition);
        _currentParticleSystem.Clear();
        _currentParticleSystem.Play();
    }
    public void Init(Action<HitParticle> onKill){
        _onKill = onKill;
    }
    public void OnParticleSystemStopped(){
        _onKill.Invoke(this);
    }
}
