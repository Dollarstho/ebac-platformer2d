using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectilePrefab;

    public Transform positionToShoot;
    public float timeBetweenShoot = 0.5f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    { 
      var projectile = Instantiate(projectilePrefab);
        projectile.transform.position = positionToShoot.transform.position;
        projectile.side = playerSideReference.transform.localScale.x;

    }
    
}
