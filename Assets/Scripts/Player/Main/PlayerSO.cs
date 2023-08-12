using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player ID", menuName = "Data/Player")]
public class PlayerSO : ScriptableObject
{
    public float BulletRange => _bulletRange;
    [SerializeField] float _bulletRange;
    public float BulletSpeed => _bulletSpeed;
    [SerializeField] float _bulletSpeed;
    
    public PlayerEventSystem Events;

   
}
