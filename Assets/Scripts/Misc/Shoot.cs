using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public float projectileSpeed;
    public float projectileSpeedUp;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;
    public Transform spawnPointDiag;
    public Transform spawnPointDiagLeft;
    public Transform spawnPointUp;
    public Transform spawnPointUpLeft;
    public Transform spawnPointCrouchR;
    public Transform spawnPointCrouchL;


    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (projectileSpeed < 0)
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab || !spawnPointDiag || !spawnPointDiagLeft || !spawnPointUp)
            Debug.Log("Please setup default values on " + gameObject.name);

        if (projectileSpeedUp <= 0)
            projectileSpeedUp = 5.0f;

       

    }

 
    public void Fire()
    {
        if(!sr.flipX) 
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else 
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }
    }

    public void FireUp()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointDiag.position, spawnPointDiag.rotation);
            curProjectile.speed = projectileSpeed;
            curProjectile.speedUp = projectileSpeedUp;

        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointDiagLeft.position, spawnPointDiagLeft.rotation);
            curProjectile.speed = -projectileSpeed;
            curProjectile.speedUp = projectileSpeedUp;
        }
    }

    public void FireUpUp()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointUp.position, spawnPointUp.rotation);
            curProjectile.speed = 0;
            curProjectile.speedUp = 12;
        }
        else
       
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointUpLeft.position, spawnPointUpLeft.rotation);
            curProjectile.speed = 0;
            curProjectile.speedUp = 12;
        }
       


        
    }
    public void FireCrouch()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointCrouchR.position, spawnPointCrouchR.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointCrouchL.position, spawnPointCrouchL.rotation);
            curProjectile.speed = -projectileSpeed;
        }
    }
}
