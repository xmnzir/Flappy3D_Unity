using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneScript : MonoBehaviour
{
    
    public void restart()
    {   GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void level1()
    {   GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene("level1");
    }
   public void level2()
    {   GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene("level2");
    }
    public void level3()
    {   GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene("level3");
    }

         public void levelSelect()
    {   
        GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene("levelSelect");
    }

    public void mainmenu()
    {   
    GameManager.instance.gameOverPUBLIC=false;
        GameManager.instance.playerActivePUBLIC=false;

        SceneManager.LoadScene("main");
    }
}
