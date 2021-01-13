using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //obj vars
    public GameObject playerObj;
    public Animator playerAnimator;
    public Rigidbody rb;
    public int walkForce = 50;
    public int sprintForce = 70;

    //bools
    public bool isRunning;
    public bool isWalkingBackward;
    public bool isWalking;
    public bool runPressed;
    public bool forwardPressed;
    public bool backwardsPressed;    
    
    //hash
    private int isWalkingHash;
    private int isRunningHash;
    private int isWalkingBackwardsHash;

    
    void Start()
    {
        rb = playerObj.GetComponent<Rigidbody>();
        playerAnimator = playerObj.GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
    }

    void Update()
    {
        isWalkingBackward = playerAnimator.GetBool(isWalkingBackwardsHash);
        isWalking = playerAnimator.GetBool(isWalkingHash);
        isRunning = playerAnimator.GetBool(isRunningHash);

        backwardsPressed = Input.GetKey("s");
        forwardPressed = Input.GetKey("w");
        runPressed = Input.GetKey("left shift");


        //walk forward
        if (!isWalking && forwardPressed)
        {
            EnableRigidBody();
            rb.AddForce(transform.forward * walkForce);
            playerAnimator.SetBool(isWalkingHash, true);
        } 

        //stop walking
        if (isWalking && !forwardPressed)
        {
            DisableRigidBody();
            playerAnimator.SetBool(isWalkingHash, false);
        }

        //run forward
        if (!isRunning && (forwardPressed && runPressed))
        {
            EnableRigidBody();
            rb.AddForce(transform.forward * sprintForce);
            playerAnimator.SetBool(isRunningHash, true);
        }

        //stop running
        if (isRunning && (!forwardPressed || !runPressed))
        {
            DisableRigidBody();
            playerAnimator.SetBool(isRunningHash, false);
        }

        //walking backwards
        if (!isWalkingBackward && backwardsPressed)
        {
            EnableRigidBody();
            rb.AddForce(-transform.forward * walkForce);
            playerAnimator.SetBool(isWalkingBackwardsHash, true);
        }    

        //stop walking backwards
        if (isWalkingBackward && !backwardsPressed)
        {
            DisableRigidBody();
            playerAnimator.SetBool(isWalkingBackwardsHash, false);
        }


    }

    void EnableRigidBody()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    void DisableRigidBody()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }
}
