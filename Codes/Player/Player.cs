using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    Rigidbody2D playerRigidbody;
    BoxCollider2D player_collider;

    [Header("Science")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float walkSpeed = 3f;
    public int health = 5;
    public int diamonds;
    public int Health { get; set; }

    public Slider jumpForceSlider;
    public Slider walkSpeedSlider;

    [Header("Sound")]
    public AudioClip IdleSound;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip dieSound;

    bool resetJump = false;
    bool grounded = false;
    AudioSource playerAudio;

    public Joystick player_joystick;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        player_collider = GetComponent<BoxCollider2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Walk();

        jumpForce = jumpForceSlider.value;
        walkSpeed = walkSpeedSlider.value;
        //Jump();
        //Attack();
    }

    public void SetDefaults()
    {
        jumpForceSlider.value = 7;
        walkSpeedSlider.value = 5;
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.Update_Gem_Count(diamonds);
    }

    public void Damage()
    {
        if (health < 1)
        {
            return;
        }

        GetComponent<PlayerAnimation>().AnimateHit();
        health -= 1;

        UIManager.Instance.UpdateLives(health);

        if (health <= 0)
        {
            Destroy(playerRigidbody);
            Destroy(player_collider);
            GetComponent<PlayerAnimation>().AnimateDeath();
            Destroy(this.gameObject, 4.7f);

            FindObjectOfType<SceneHandler>().LoadGameOver();
        }
    }

    public void Walk()
    {
        //Walk
        //float move_input = Input.GetAxisRaw("Horizontal");
        float move_input = player_joystick.Horizontal;
        grounded = IsGrounded();

        playerRigidbody.velocity = new Vector2(move_input * walkSpeed, playerRigidbody.velocity.y);

        FindObjectOfType<PlayerAnimation>().AnimateRun(move_input);
    }

    public void Jump()
    {
        //Jump
        if (IsGrounded())
        {
            FindObjectOfType<PlayerAnimation>().AnimateJump(true);
            playerRigidbody.velocity = new Vector2(transform.position.x, jumpForce);
            StartCoroutine(ResetJump());
        }

    }

    public void Attack()
    {

        FindObjectOfType<PlayerAnimation>().AnimateAttack();

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                FindObjectOfType<PlayerAnimation>().AnimateJump(false);
                return true;
            }
        }

        return false;
    }
    IEnumerator ResetJump()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }







    public void PlayIdleSound()
    {
        playerAudio.PlayOneShot(IdleSound, 0.7f);
    }

    public void PlayJumpSound()
    {
        playerAudio.PlayOneShot(jumpSound, 0.7f);
    }

    public void PlayDeathSound()
    {
        playerAudio.PlayOneShot(dieSound, 1f);
    }

    public void PlayAttackSound()
    {
        playerAudio.PlayOneShot(attackSound, 0.4f);
    }

    public void PlayHitSound()
    {
        playerAudio.PlayOneShot(hitSound, 0.3f);
    }
}
