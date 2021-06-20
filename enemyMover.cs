using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class enemyMover : MonoBehaviour
{
    Enemy enemy;
     List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f,5f)] float speed = 1f;
    // Start is called before the first frame update
    void OnEnable()
    {
        findPath();
        returnToStart();
        StartCoroutine(FollowPath());
        
        
    }
    void Start(){
        enemy = GetComponent<Enemy>();
    }
    void findPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("path");
        foreach(Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if(wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }
  void finishPath()
  {
      enemy.stealGold();
      gameObject.SetActive(false);
  }
   IEnumerator FollowPath()
   {
       foreach(WayPoint wayPoint in path)
       {
           Vector3 startPosition = transform.position;
           Vector3 endPosition = wayPoint.transform.position;
           float travelPercent = 0f;
           transform.LookAt(endPosition);
           while(travelPercent<1f)
            {
               travelPercent += speed * Time.deltaTime;
               transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
               yield return new WaitForEndOfFrame();
            }
           
       }
       finishPath();
   }
     void returnToStart()
    { 
        transform.position = path[0].transform.position;
    }
   
}
