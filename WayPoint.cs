using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //GameObject parentGameObject;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }
    void Start() {
        //parentGameObject = GameObject.FindWithTag("parentOfTower");
        
    }
    void OnMouseDown() {
        if(isPlaceable){
            bool isPlaced = towerPrefab.CreateTower(towerPrefab,transform.position);
            //GameObject tower = Instantiate(towerPrefab,transform.position,Quaternion.identity);
            //tower.transform.parent = parentGameObject.transform;
            isPlaceable = !isPlaced;
        } 
    }
}
