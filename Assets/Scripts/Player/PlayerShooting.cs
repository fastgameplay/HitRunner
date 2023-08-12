using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAim))]
public class PlayerShooting : PlayerBased
{   
    // [SerializeField] private Gun _currentGun;
    // [SerializeField] WayPoint _currentPoint;
    // private PlayerAim _currentAim;
    private Camera _mainCamera;
    private Plane plane = new Plane(Vector3.up, -1.5f);
    private void Awake(){
        base.Awake();
        _mainCamera = Camera.main;
        // _currentAim = GetComponent<PlayerAim>();
    }
  
    void OnEnable(){
        player.ID.Event.OnTapPosition += TapRegistered;
    }
    void OnDisable(){
        player.ID.Event.OnTapPosition -= TapRegistered;
    }

    private void TapRegistered(Vector3 screenPosition){
        Ray ray = _mainCamera.ScreenPointToRay(screenPosition);
        if(plane.Raycast(ray, out float distance)){
            player.ID.Event.OnAim?.Invoke(ray.GetPoint(distance));
            return;
        }

    }
}
