using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LaserBulletPool : MonoBehaviour
{
    [SerializeField] LaserBullet _prefab;
    [SerializeField] int _initialAmountToPool;
    [SerializeField] int _maxPoolAmount;

    private ObjectPool<LaserBullet> _pool;
    private void Start(){
        _pool = new ObjectPool<LaserBullet>(
            () => {
                return Instantiate(_prefab);
            }, laserBullet => {
                laserBullet.Init(KillBullet);
                laserBullet.gameObject.SetActive(true);
            }, laserBullet => {
                laserBullet.gameObject.SetActive(false);
            }, laserBullet => {
                Destroy(laserBullet.gameObject);
            }, false, _initialAmountToPool, _maxPoolAmount
        );
    }
    public LaserBullet GetBullet(){
        return _pool.Get();
    }
    private void KillBullet(LaserBullet bullet){
        _pool.Release(bullet);
    }
}
