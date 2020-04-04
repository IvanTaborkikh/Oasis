using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuvement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool Crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            Crouch = false;
        }
    }
   public void Onlanding()
    {
        animator.SetBool("jumping", false);
    }
    public void Oncroaching (bool croaching)
    {
        animator.SetBool("crouching", croaching);
    }
     void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, jump);
        jump = false;
        
    }
}
