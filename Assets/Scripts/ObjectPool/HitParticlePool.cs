using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitParticlePool : MonoBehaviour
{
    [SerializeField] HitParticle _prefab;
    [SerializeField] int _initialAmountToPool;
    [SerializeField] int _maxPoolAmount;

    private ObjectPool<HitParticle> _pool;
    private void Start(){
        _pool = new ObjectPool<HitParticle>(
            () => {
                return Instantiate(_prefab);
            }, laserBullet => {
                laserBullet.Init(Kill);
                laserBullet.gameObject.SetActive(true);
            }, laserBullet => {
                laserBullet.gameObject.SetActive(false);
            }, laserBullet => {
                Destroy(laserBullet.gameObject);
            }, false, _initialAmountToPool, _maxPoolAmount
        );
    }
    public HitParticle GetParticle(){
        return _pool.Get();
    }
    private void Kill(HitParticle particle){
        _pool.Release(particle);
    }
}
