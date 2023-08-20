using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalHealthManager : MonoBehaviour, IDamagable
{
    public int Health => _health;
    private int _health;
    [SerializeField] int _maxHealth;
    void Awake(){
        _health = _maxHealth;
    }

    public void Damage(int value){
        if(value >= _health){
            _health = 0;
            Destroy(gameObject);
        }
        _health -= value;
    }

}
