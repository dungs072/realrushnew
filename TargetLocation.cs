using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;
    Transform target;
    void Start()
    {
        target = FindObjectOfType<enemyMover>().transform;
       // projectileParticles = GetComponent<ParticleSystem>();
        //attack(false);
    }

    
    void Update()
    {
        FindClosestTarget();
        aimWeapon();

    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position,enemy.transform.position);
            
            if(targetDistance<maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    void aimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position,target.position);
       weapon.LookAt(target);
         if(targetDistance < range)
        {
              attack(true);
        }
        else{
        
           attack(false);
        }
        
    }
    void attack(bool isActive)
    {
       var emissionModule = projectileParticles.emission;
       emissionModule.enabled = isActive;
    }
}
