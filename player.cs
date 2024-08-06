using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for ordinary test mesh
using TMPro;//clear text mesh


public class player : MonoBehaviour
{
    [SerializeField] int deadForceY;
    [SerializeField] int deadForceX;
    [SerializeField] float force=150f;
    [SerializeField] AudioClip jumpSfx;
    [SerializeField] AudioClip deadSfx1;
    [SerializeField] AudioClip deadSfx2;
    
    private Animator jump;  // For Animating Bird Movement
    private Animator dead;
    private Rigidbody bird; 
    private bool Click;
    private AudioSource playJumpSfx; // Triggers sfx on bird
    private AudioSource playDeadSfx;
    private int score=0;
    private int tscore=0;
    public TMP_Text pscore;// PLAYER score text
    public TMP_Text gOver;//game over tmp
    public TMP_Text hscore;//highscore
    private int highScore;
    public GameObject blood1;//PARTICLE 1
    public GameObject blood2;//PARTICLE 2
    private GameObject CurrentGameobject; // used to store selected particle . eg- if we hit pillars then particle1 will be played else particle 2
    public GameObject buttonRestart;//to show button only when gameover

    

    void Start()
    {
        jump = GetComponent<Animator>();
        dead = GetComponent<Animator>();
        bird = GetComponent<Rigidbody>();
        playJumpSfx = GetComponent<AudioSource>();
        playDeadSfx = GetComponent<AudioSource>();
        pscore.text="SCORE:"+score;bird.useGravity=false;
        bird.useGravity=false;
        buttonRestart.active=false; // sets the button hidden by default
        highScore = PlayerPrefs.GetInt("highscore");

    }

 // Update is called once per frame
    void Update()
    {  if (GameManager.instance.gameOverPUBLIC==false)
       { if(Input.GetMouseButtonDown(0))
    
        {   GameManager.instance.playerActiveFn();
            jump.Play("jump");
        Click= true;
        playJumpSfx.PlayOneShot(jumpSfx);
        bird.useGravity=true;//uses gravity only if first mouse button is clicked because it is disabled in start
        }   
      }
    }

    void FixedUpdate()
    {
        
      if(Click==true)
      {
          Click=false;
          bird.AddForce(new Vector2 (0,force),ForceMode.Impulse);
          bird.velocity=new Vector2 (0,0);
      }
   
    }

    void OnCollisionEnter(Collision ColDetect) {
    if(ColDetect.gameObject.tag=="pillars")
    {
     bird.AddForce(new Vector2 (deadForceX,deadForceY),ForceMode.Impulse);//CODE TO ADD BOUNCE AFTER DEATH
     dead.Play("dead1");
     gOver.text="GAME OVER";
     hscore.text="HIGHSCORE  :  "+highScore;
     playDeadSfx.PlayOneShot(deadSfx1);
     CurrentGameobject=blood1;//particle1 is selected for play
     playBloodParticle();//plays the particle once
     GameManager.instance.playerCollidedFn();

     buttonRestart.active=true;//shows button after GameOver
   
    }
    
    

    if(ColDetect.gameObject.tag=="platforms")
    { dead.Play("dead2");
      gOver.text="GAME OVER";
      hscore.text="HIGHSCORE  :  "+highScore;
      playDeadSfx.PlayOneShot(deadSfx2);
      playBloodParticle();//plays the particle on loop
      CurrentGameobject=blood2;//particle2 is selected for play  
      GameManager.instance.playerCollidedFn();
    }

    }
    
    void playBloodParticle () { 
          GameObject bloodTemp = Instantiate(CurrentGameobject, transform.localPosition, Quaternion.identity); //currentgameobj is a varible to store either one of the particles  effect depending upon the scenarios
          bloodTemp.GetComponent<ParticleSystem>().Play();//plays the blood particle
      } 

    void OnTriggerEnter(Collider trigDetect)
    {
        if(trigDetect.gameObject.tag=="score")
        {   tscore=tscore+1;// for a single trigger it adds up 3 values for some reason . so we divide it 
        
            score = (tscore/3);
            Debug.Log(score);
            Debug.Log(highScore+"HS");
            pscore.text="SCORE:"+score;
            if(PlayerPrefs.GetInt("highscore") < score)
            {
              PlayerPrefs.SetInt("highscore",score);
            }
            }
    }
    

    
}
