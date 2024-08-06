using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPillarGen : MonoBehaviour
{  
    public GameObject pillar0 ;
    public GameObject pillar1 ;
    public GameObject pillar2 ;
    public GameObject pillar3 ;
    public GameObject pillar4 ;
    public GameObject pillar5 ;
    public GameObject pillar6 ;
    public GameObject pillar7 ;
    public GameObject pillar8 ;
    public GameObject pillar9 ;
    

   GameObject[] pillars = new GameObject[10];
   GameObject[] randomPillarSelect = new GameObject[10];
  private GameObject[] clonedPillars = new GameObject[10];
  
    
   Vector3[] pillarPos = new Vector3[10];

   int random; // to generate a random number
   int y=0; // for position change

  

    void Start()
    {
        
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicThrough>().StopMusic();
        pillarPos[0] = new Vector3(170.0f,43.5f,-142.0f);
        pillarPos[1] = new Vector3(200.0f,43.5f,-142.0f);
        pillarPos[2] = new Vector3(230.0f,43.5f,-142.0f);
        pillarPos[3] = new Vector3(260.0f,43.5f,-142.0f);
        pillarPos[4] = new Vector3(290.0f,43.5f,-142.0f);
        pillarPos[5] = new Vector3(320.0f,43.5f,-142.0f);
        pillarPos[6] = new Vector3(350.0f,43.5f,-142.0f);
        pillarPos[7] = new Vector3(380.0f,43.5f,-142.0f);
        pillarPos[8] = new Vector3(410.0f,43.5f,-142.0f);
        pillarPos[9] = new Vector3(440.0f,43.5f,-142.0f);

        
      
        pillars[0] = pillar4;
        pillars[1] = pillar2;
        pillars[2] = pillar6;
        pillars[3] = pillar1;
        pillars[4] = pillar0;
        pillars[5] = pillar8;
        pillars[6] = pillar3;
        pillars[7] = pillar9;
        pillars[8] = pillar7;
        pillars[9] = pillar9;
        
       for(int i=0; i<randomPillarSelect.Length; i++) 
       { randomPillarSelect [i] = pillars [Random.Range(0,10)] ;}
       
       
       for(int i=0; i<randomPillarSelect.Length; i++) 
       {  GameObject x = randomPillarSelect [i];
          Instantiate(x, pillarPos [i], Quaternion.identity);

       }
      
    }

    // Update is called once per frame
    void Update()
    { 
    }

  

}