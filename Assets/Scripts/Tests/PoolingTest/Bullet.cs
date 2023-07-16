using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 speed = Vector3.right;

    private Action<Bullet> OnReleaseAction;
    public void SetReleaseAction(Action<Bullet> releaseAction)
    {
        OnReleaseAction = releaseAction;
    }
    
    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        OnReleaseAction.Invoke(this);
    }
}
