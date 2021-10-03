using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Vertical");
        bool isRunning=animator.GetBool("IsRunning");
        bool isWalking=animator.GetBool("IsWalking");
        bool forwardPressed=false;
        if(horizontal!=0||vertical!=0)
        forwardPressed=true;
        bool RunningPressed=Input.GetKey("left shift");
        bool CrouchPressed=Input.GetKey("c");
        bool JumpPressed=Input.GetKey("space");

        if(!isWalking&&forwardPressed)
        {
            animator.SetBool("IsWalking",true);
        }
        if(isWalking&&!forwardPressed)
        {
            animator.SetBool("IsWalking",false);
        }
        if (!isRunning&&(RunningPressed&&forwardPressed))
        {
            animator.SetBool("IsRunning",true);
        }
        if(isRunning&&(!RunningPressed||!forwardPressed))
        {
            animator.SetBool("IsRunning",false);
        }
        if(!isWalking&&CrouchPressed)
        {
            animator.SetBool("IsCrouch",true);
        }
        if(!isWalking&&!CrouchPressed)
        {
            animator.SetBool("IsCrouch",false);
        }
        if(JumpPressed)
        {
            animator.SetBool("IsJumping",true);
            //  if(isWalking)
            // animator.SetBool("IsWalking",false);
            // else if(isRunning)
            // animator.SetBool("IsRunning",false);
        }
        else
        {
            animator.SetBool("IsJumping",false);
        }

    }
}
