using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    [SerializeField] int cost = 75;
     
    // Start is called before the first frame update
    // void Start()
    // {
        
    //     parentGameObject = GameObject.FindWithTag("parentOfTower");
    // }

    public bool CreateTower(Tower tower, Vector3 position)
    {
       Bank bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        if(bank.CurrentBalance >= 75)
        {
            // vi tri ham bank.withDraw duoi co vi tri het suc quan trong
            bank.withDraw(cost);
            Tower vh = Instantiate(tower,position,Quaternion.identity);
            //vh.transform.parent = parentGameObject.transform;
            
            return true;
        }
        return false;
    }

}
