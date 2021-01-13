using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerObj;
    public Animator playerAnimator;
    public Rigidbody rb;

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
            playerAnimator.SetBool(isWalkingHash, true);
        } 

        //stop walking
        if (isWalking && !forwardPressed)
        {
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
}
