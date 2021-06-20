using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField][Range(0.1f,30f)] float spawnTimer = 1f;
    [SerializeField][Range(0,50)] int poolSize = 5;
    GameObject[] pool;
    void Awake() {
        populatePool();
    }
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }
    void populatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i<pool.Length;i++)
        {
            pool[i] = Instantiate(Enemy,transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for(int i = 0 ; i<pool.Length;i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
            
        }
    }
    IEnumerator InstantiateEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

   
}
