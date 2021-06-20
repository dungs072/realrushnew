using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class healthEnemy : MonoBehaviour
{

    Enemy enemy;
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("adds amount to maxHitPoints when enemies die")]
    [SerializeField] int difficultyRamp = 1;

    
     int currentHitPoints = 0;
    void OnEnable() {
        currentHitPoints = maxHitPoints;
    }
    void Start(){
        enemy = GetComponent<Enemy>();
    }
    void OnParticleCollision(GameObject other) {
        processHit();
    }
    void processHit()
    {
        currentHitPoints--;
        if(currentHitPoints<=0)
        {
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
            
        }
    }
}
