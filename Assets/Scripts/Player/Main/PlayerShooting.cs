using UnityEngine;
public class PlayerShooting : PlayerBased
{   
    private Camera _mainCamera;
    private Plane plane = new(Vector3.up, -1.5f);
    protected override void Awake(){
        base.Awake();
        _mainCamera = Camera.main;
    }
  
    void OnEnable(){
        player.ID.Events.OnTapPosition += TapRegistered;
    }
    void OnDisable(){
        player.ID.Events.OnTapPosition -= TapRegistered;
    }

    private void TapRegistered(Vector3 screenPosition){
        Ray ray = _mainCamera.ScreenPointToRay(screenPosition);
        if(plane.Raycast(ray, out float distance)){
            player.ID.Events.OnAim?.Invoke(ray.GetPoint(distance));
            return;
        }

    }
}
