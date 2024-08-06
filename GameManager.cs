using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance=null; // variable with type of the class and instance as variable name set to null
    private bool playerActive=false;
    private bool gameOver=false; // WE MADE IT PRIVATE AND WE ARE GOING TO USE DATA ENCAPSULATION RULE

    public bool playerActivePUBLIC {get{return playerActive;}
                                    set {playerActive=value; }// sets the data
           }
    public bool gameOverPUBLIC     {get{return gameOver;}
                                   set { gameOver=value;}}

    void Awake()  { // to make sure there is only on instance of this game manager
     if (instance==null)
     {
         instance=this;
     }
     else if(instance!=this)
     {
         Destroy(gameObject);
     }
     DontDestroyOnLoad(gameObject); // keeps GameManager Through MULTIPLE SCENES
    }
     public void playerCollidedFn()  
     {
      gameOver=true;   
     }
     public void playerActiveFn()
     {
      playerActive=true;   
     }

     

   
}
