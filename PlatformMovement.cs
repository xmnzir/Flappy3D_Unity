using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{[SerializeField] int speed=7;
[SerializeField] float newPosValue;
 [SerializeField]   float ResetPos = 1764.2f; //always make variables private if possible

   
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {   
        if (GameManager.instance.gameOverPUBLIC!=true && GameManager.instance.playerActivePUBLIC==true)
     {
        
        transform.Translate(Vector3.left * (speed * Time.deltaTime ));

          if (transform.localPosition.x <= ResetPos)// Checks whether the platform has passes the screen
          {
              
              Vector3 LoopPos = new Vector3(newPosValue,transform.position.y,transform.position.z);
              transform.position = LoopPos;
              
              

          }
     }
    }
}
