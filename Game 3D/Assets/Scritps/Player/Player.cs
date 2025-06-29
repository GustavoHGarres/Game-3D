using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
      public Animator animator;

      public float jumpSpeed = 15f;
      public CharacterController characterController;    
      public float speed = 1f;    
      public float turnSpeed = 1f;    
      public float gravity = 9.8f;    
      private float vSpeed = 0f;
        
      public KeyCode jumpKeyCode = KeyCode.Space;

      [Header("Run Setup")]   
        public KeyCode keyRunCode = KeyCode.LeftShift;    
        public float speedRun = 1.5f;

      [Header("Flash")]
      public List<Flashcolor> flashcolors;

#region LIFE

      public void Damage(float damage)
      {
           flashcolors.ForEach(i => i.Flash());
      }

      public void Damage(float damage, Vector3 dir)
      {

      }


#endregion

      void Update()    
      {        
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);        
        var inputAxisVertical = Input.GetAxis("Vertical");        
        var speedVector = transform.forward * inputAxisVertical * speed;  

         if(characterController.isGrounded)        
         {            
            vSpeed = 0;            
            if(Input.GetKeyDown(jumpKeyCode)) 
            //if(Input.GetKeyDown(KeyCode.Space))           
            {                
                vSpeed = jumpSpeed;            
            }        
         }

        vSpeed  -= gravity * Time.deltaTime;        
        speedVector.y = vSpeed;        
          

          if(inputAxisVertical !=0)       
          {            
             animator.SetBool("Run", true);
          }       
          
          else       
          {             
            animator.SetBool("Run", false);        
          }

           var isWalking = inputAxisVertical != 0;        
           if(isWalking)        
           {            
            if(Input.GetKey(keyRunCode))            
            {                
                speedVector *= speedRun;                
                animator.speed = speedRun;
            }
            
            else            
                {                
                    animator.speed = 1;            
                }        
           }

            characterController.Move(speedVector * Time.deltaTime); 
    }
}
