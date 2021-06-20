using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 123123123;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    } 
    void Awake()
    {
        currentBalance = startingBalance ;
        updateDisplay();
    }
   public void deposit(int amount)
   {
       currentBalance += Mathf.Abs(amount);
       updateDisplay();
   }
   public void withDraw(int amount)
   {
       currentBalance -= Mathf.Abs(amount);
       updateDisplay();
       if(currentBalance<0)
       {
          Invoke("reloadLevel",1f);
       }
   }
   void reloadLevel()
   {
       Scene currentScene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(currentScene.buildIndex);
   }
   void updateDisplay()
   {
       displayBalance.text = "Gold : " + currentBalance;
   }

}
