using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Baisc")]
    [SerializeField] protected int health = 3;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float gems = 4f;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected string idle_anim_name = "BimalOP_Idle";
    [SerializeField] protected BoxCollider2D object_collider;
    [SerializeField] protected GameObject diamond_prefab;

    [Header("Audio")]
    public AudioClip walk;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip dead;

    protected Player player;
    protected bool is_hit = false;
    protected Animator anim;
    SpriteRenderer sprite;
    Vector3 target_pos;
    protected AudioSource enemy_audio;


    public virtual void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        enemy_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Init();
        enemy_audio.enabled = false;
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(idle_anim_name) && anim.GetBool("IsCombat") == false || anim.GetBool("IsDead")) { return; }

        Movement();
    }

    private void Movement()
    {
        if (target_pos == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            target_pos = pointB.position;
            anim.SetTrigger("IsIdle");
        }
        else if (transform.position == pointB.position)
        {
            target_pos = pointA.position;
            anim.SetTrigger("IsIdle");
        }

        if (!is_hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_pos, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x < 0 && anim.GetBool("IsCombat"))
        {
            sprite.flipX = true;
        }

        else if (direction.x > 0 && anim.GetBool("IsCombat"))
        {
            sprite.flipX = false;
        }


        if (distance < 3)
        {
            enemy_audio.enabled = true;
        }

        else if (distance > 4)
        {
            enemy_audio.enabled = false;
        }

        if (distance > 3)
        {
            is_hit = false;
            anim.SetBool("IsCombat", false);
        }
    }

    public void TheIfStatement()
    {
        if (health <= 0)
        {
            enemy_audio.PlayOneShot(dead, 0.5f);

            Destroy(object_collider);
            anim.SetBool("IsDead", true);

            Vector3 diff_pos = new Vector3(0, 0, 0);

            for (int i = 0; i < gems; i++)
            {
                diff_pos += new Vector3(1f, 0f, 0f);
                Instantiate(diamond_prefab, transform.position + diff_pos, transform.rotation);
            }
        }
    }



    public void EnemyAttackSound()
    {
        enemy_audio.PlayOneShot(attack, 0.4f);
    }

    public void EnemyHitSound()
    {
        enemy_audio.PlayOneShot(hit, 0.3f);
    }

    public void PlayEnemyWalkSound()
    {
        enemy_audio.PlayOneShot(walk, 0.5f);
    }
}
