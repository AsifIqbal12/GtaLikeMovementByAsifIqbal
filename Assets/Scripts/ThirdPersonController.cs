using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
  public CharacterController controller;
  public float speed=4f;
  public float turnSmoothTime=0.1f;
  float turnSmoothVelocity;
  Vector3 velocity;
  public float gravity=-9.81f;
  public Transform groundCheck;
  public float groundDistance=0.7f;
  public LayerMask groundMask;
  bool isGrounded;
      // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(isGrounded&&velocity.y<0)
        {
            velocity.y=-2f;
        }
        velocity.y+=gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Vertical");
        bool SprintPressed=Input.GetKey("left shift");
        if(SprintPressed)
        speed=10f;
        else
        {
            speed=4f;
        }
       if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y=5f;
            if(SprintPressed)
            velocity.y=7f;
        } 
        Vector3 direction=new Vector3(horizontal,0f,vertical).normalized;
        if(direction.magnitude>=0.1f)
        {
            float targetAngle=Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle=Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation=Quaternion.Euler(0f,angle,0);
            controller.Move(direction * speed * Time.deltaTime);
        }
        
    }
}
