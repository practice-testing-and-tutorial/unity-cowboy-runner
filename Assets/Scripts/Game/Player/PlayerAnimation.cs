using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        _anim.Play("Player_idle");
    }

    public void PlayRun()
    {
        _anim.Play("Player_run");
    }

    public void PlayJump()
    {
        _anim.Play("Player_jump");
    }
}
