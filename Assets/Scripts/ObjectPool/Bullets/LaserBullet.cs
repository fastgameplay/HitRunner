using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserBullet : MonoBehaviour
{
    private event Action<LaserBullet> _killAction;
    public LaserBullet Initialize(Vector3 startPosition, Vector3 hitPosition, Quaternion rotation, float speed){
        LeanTween.cancel(gameObject);
        //TODO: Add randomness inside BulletData
        transform.position = startPosition + (hitPosition - startPosition)/2;
        transform.rotation = rotation;
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,Vector3.Distance(startPosition, hitPosition));
        float correctedSpeed = speed * (Vector3.Distance(startPosition,hitPosition) / 5f);
        LeanTween.move(gameObject, hitPosition, correctedSpeed);
        LeanTween.scaleZ(gameObject, 0, correctedSpeed)
            .setOnComplete( ()=> { 
                
                _killAction.Invoke(this); 
            } );
        return this;
    }
    public void Init(Action<LaserBullet> killAction){
        _killAction = killAction;
    }
}
