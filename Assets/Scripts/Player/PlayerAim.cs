using System.Collections;
using UnityEngine;

public class PlayerAim : PlayerBased
{
    const float RESET_DELAY = 0.8f;
    [SerializeField] Transform _targetBodyAim, _targetGunAim;
    private Coroutine _aimCoroutine;
    private Vector3 _bodyTargetInitialPos, _gunTargetInitialPos;

    protected override void Awake(){
        base.Awake();
        _bodyTargetInitialPos = _targetBodyAim.localPosition;
        _gunTargetInitialPos = _targetGunAim.localPosition;
    } 
    
    public void Aim(Vector3 targetPoint){
        if(_aimCoroutine != null){
            StopCoroutine(_aimCoroutine);
        }
        _targetBodyAim.position = _targetGunAim.position = targetPoint;
        player.ID.Event.OnShoot?.Invoke();
        _aimCoroutine = StartCoroutine(ResetPositionAsync(RESET_DELAY));
    }
    private void ResetPosition(){
        _targetBodyAim.localPosition = _bodyTargetInitialPos; 
        _targetGunAim.localPosition = _gunTargetInitialPos;
    }
    private IEnumerator ResetPositionAsync(float time ){
        yield return new WaitForSeconds(time);
        ResetPosition();
    }
    private void OnEnable(){
        player.ID.Event.OnAim += Aim;
    }
    private void OnDisable(){
        player.ID.Event.OnAim -= Aim;
    }
}
