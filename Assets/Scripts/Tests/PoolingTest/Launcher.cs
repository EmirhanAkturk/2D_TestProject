using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    
    private IObjectPool<Bullet> bulletPool;
    
    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnDestroy, maxSize: 3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }

    private void ReleaseBullet(Bullet bullet)
    {
        bulletPool.Release(bullet);
    }

    #region Bullet Pool

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint);
        bullet.SetReleaseAction(ReleaseBullet);
        return bullet;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector3.zero;
    }

    // ReSharper disable once Unity.IncorrectMethodSignature
    private void OnDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    #endregion
}
