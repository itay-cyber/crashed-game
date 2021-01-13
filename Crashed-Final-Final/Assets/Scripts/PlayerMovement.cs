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
    public bool isWalking;
    public bool runPressed;
    public bool forwardPressed;
    
    //hash
    private int isWalkingHash;
    private int isRunningHash;
    

    
    void Start()
    {
        rb = playerObj.GetComponent<Rigidbody>();
        playerAnimator = playerObj.GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    void Update()
    {
        isWalking = playerAnimator.GetBool(isWalkingHash);
        isRunning = playerAnimator.GetBool(isRunningHash);

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

            playerAnimator.SetBool(isRunningHash, true);
        }

        //stop running
        if (isRunning && (!forwardPressed || !runPressed))
        {

            playerAnimator.SetBool(isRunningHash, false);
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
