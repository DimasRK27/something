using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackplayer : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Atk();
        }

    }

    void Atk()
    {
        // play anim
        animator.SetTrigger("isAtk");
        // detect enemy
        // damage them
    }
}
