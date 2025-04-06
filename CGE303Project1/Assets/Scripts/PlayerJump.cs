using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    public UnityEvent OnLandEvent;

    public Animator animator;


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
