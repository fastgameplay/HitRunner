using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WayPoint : MonoBehaviour
{
    public event Action<int> OnWayPointEmpty;
    public bool IsEmpty => _enemies.Count == 0;
    [SerializeField] int _id;
    [SerializeField] List<Enemy> _enemies;
    void Awake(){
        for (int i = 0; i < _enemies.Count; i++){
            _enemies[i].OnDeath += EnemyDeathHandler; 
        }
    }

    //TODO: TEST ONLY DELETE AFTER!
    public void DestroyFirstEnemy(){
        Destroy(_enemies[0].gameObject);
    }
    public Vector3 GetActivePosition(){
        return _enemies[0].Position;
    }
    private void EnemyDeathHandler(Enemy enemy){
        enemy.OnDeath -= EnemyDeathHandler;
        _enemies.Remove(enemy); 
        if(_enemies.Count == 0) OnWayPointEmpty?.Invoke(_id);
    }
}
