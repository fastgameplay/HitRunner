using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : PlayerBased
{
    [SerializeField] Transform _spawnPosition;
    [SerializeField] LaserBulletPool _bulletPool;
    [SerializeField] HitParticlePool _hitParticlePool;

    private void Shoot(){
        RaycastHit hit;
        Vector3 hitPoint;
        if (Physics.Raycast(_spawnPosition.position, _spawnPosition.forward, out hit, player.ID.BulletRange, 128)){
            hitPoint = hit.point;
            _hitParticlePool.GetParticle().SetUp(hit.point,_spawnPosition);
        }
        else{

            hitPoint =  new Ray(_spawnPosition.position, _spawnPosition.forward).GetPoint(player.ID.BulletRange);
        }
        
        _bulletPool.GetBullet().Initialize(_spawnPosition.position, hitPoint, _spawnPosition.rotation, player.ID.BulletSpeed);      
    }

    private void OnEnable() => player.ID.Events.OnShoot += Shoot;
    private void OnDisable() => player.ID.Events.OnShoot -= Shoot;
}
