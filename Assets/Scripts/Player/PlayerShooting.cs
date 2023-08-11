using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAim))]
public class PlayerShooting : MonoBehaviour
{   
    // [SerializeField] private Gun _currentGun;
    [SerializeField] WayPoint _currentPoint;
    private PlayerAim _currentAim;
    
    
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Shoot");
            OnShoot();
        }
    }
    private void Awake(){
        _currentAim = GetComponent<PlayerAim>();
    }
    public void OnShoot(){
        if(_currentPoint.IsEmpty) return;
        Vector3 aimPoint = _currentPoint.GetActivePosition();
        _currentAim.Aim(aimPoint);
        //TODO: TEST ONLY DELETE AFTER!
        _currentPoint.DestroyFirstEnemy();
    }
    //GetTargetsFromPoint
    //GetNearestTarget
    //On Tap Input
    //PlayerAim.Aim(Target)
    //Gun.Shoot();

}
