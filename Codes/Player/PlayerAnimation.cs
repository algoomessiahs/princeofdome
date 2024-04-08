using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimator;
    Transform player_transform;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        player_transform = GetComponentInChildren<Transform>();
    }

    public void AnimateRun(float moveValue)
    {
        playerAnimator.SetFloat("Move", Mathf.Abs(moveValue));

        if (moveValue < 0)
        {
            player_transform.localScale = new Vector2(-1, transform.localScale.y);
        }

        else if (moveValue > 0)
        {
            player_transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
    public void AnimateJump(bool setItTo)
    {
        playerAnimator.SetBool("IsJumping", setItTo);
    }

    public void AnimateAttack()
    {
        playerAnimator.SetTrigger("IsAttacking");
    }

    public void AnimateHit()
    {
        playerAnimator.SetTrigger("IsHitting");
    }

    public void AnimateDeath()
    {
        playerAnimator.SetBool("IsDead", true);
    }
}
