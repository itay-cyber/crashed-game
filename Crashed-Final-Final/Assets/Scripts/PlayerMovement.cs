using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject playerObj;

    //bools

    public bool isWalking;
    public bool forwardPressed;
    public bool runPressed;
    public int isWalkingHash;
    public bool isRunning;
    public int isRunningHash;

    void Start()
    {
        animator = playerObj.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");


    }

    void Update()
    {
        forwardPressed = Input.GetKey("w");
        runPressed = Input.GetKey("left shift");

        isRunning = animator.GetBool(isRunningHash);
        isWalking = animator.GetBool(isWalkingHash);

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
