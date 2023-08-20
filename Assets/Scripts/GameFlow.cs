using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] WayPoint[] _wayPoints;
    [SerializeField] PlayerSO _currentPlayerSO;
    void Awake(){
        for (int i = 0; i < _wayPoints.Length; i++){   
            _wayPoints[i].OnWayPointEmpty += ActivateNextPoint;
        }
    }

    void ActivateNextPoint(int id){
        _wayPoints[id].OnWayPointEmpty -= ActivateNextPoint;
        _currentPlayerSO.Events.OnMovement?.Invoke(_wayPoints[id+1].transform.position);
        if(id+1 == _wayPoints.Length-1){
            _currentPlayerSO.Events.FinishOnDestinationReach?.Invoke();
        }
    }
}
