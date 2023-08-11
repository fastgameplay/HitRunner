using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDeath;
    // public int Health => _curentHealth.value;
    public Vector3 Position => transform.position;


    void OnDestroy(){
        OnDeath?.Invoke(this);
    }
}
