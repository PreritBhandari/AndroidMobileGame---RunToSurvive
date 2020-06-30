using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed =5.0f;
    private float verticalVelocity =0.0f;
    private float gravity =12.0f;

    private float animationDuration=3.0f;
 


    private bool isDead =false;

    private Animator anim;

    AudioSource playerAudio;

   
    
    // Start is called before the first frame update
    void Start()
    {   
       
        controller=GetComponent<CharacterController> ();

       
    }

    // Update is called once per frame
    void Update()
    {   
        if (isDead)
        {
            return;
            
        }

        if (Time.timeSinceLevelLoad<10){
            controller.Move(Vector3.forward*speed*Time.deltaTime);
            return;

            // animation naseko samma chai forward matra move garnu paryo 
            // tei bhara forward speed le multiply garyo
        }


        moveVector=Vector3.zero;


        if (controller.isGrounded)
        {
            verticalVelocity=-0.5f;
        }
        else
        {
            verticalVelocity-=gravity * Time.deltaTime;
        }

        //X -Left and Right     
        moveVector.x =Input.GetAxisRaw("Horizontal")*speed;
        if (Input.GetMouseButton(0))
        {
            // are we holding touch on right side?
            if (Input.mousePosition.x>Screen.width/2)
            {
                moveVector.x=speed;
            
            }
            else
            {
                moveVector.x=-speed;
            }
        }

        //Y - Up and Down  
        moveVector.y = verticalVelocity; 

        //Z - Forward and Backward
        moveVector.z =speed;


        controller.Move(moveVector * Time.deltaTime);
        //Time.deltaTime le speed maintain garcha fps anushar
    }

    public void SetSpeed(float modifier)
    {

        speed = 5.0f + modifier;
    }



// // called whenever our player hits some colliders
//     private void OnControllerColliderHit(ControllerColliderHit hit)
//     {
//         if(hit.point.z > transform.position.z +controller.radius)
//             Death(); 


//     }


    private void Death()
    {
        isDead =true;
        GetComponent<CountDownTimer>().OnDeath();
        // Invoke("SceneOnDeath", 3);//wait for 3seconds before calling function
        
    }


 private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger on");
        anim = gameObject.GetComponent<Animator>();

        anim.Play("dead");

        playerAudio = GetComponent <AudioSource> ();
        playerAudio.Play ();



        Death();

        // Invoke ("Death", 2);  // call Death() function
    }

// private void SceneOnDeath()
// {
//     SceneManager.LoadScene("DeathScene");
// }








}
