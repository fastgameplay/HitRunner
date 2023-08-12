using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player ID", menuName = "Data/Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] int _maxHealth;
    [SerializeField] int _speed;

    public PlayerEventSystem Event;

   
}
