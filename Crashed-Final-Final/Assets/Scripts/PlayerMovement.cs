using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerObj;
    public Animator playerAnimator;

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

        if (!isWalking && forwardPressed)
        {
            playerAnimator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            playerAnimator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            playerAnimator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            playerAnimator.SetBool(isRunningHash, false);
        }

    }
}
