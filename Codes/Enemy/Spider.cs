using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    public AudioClip idleAudio;
    public override void Update()
    {

    }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public void Damage()
    {
        if (health < 1)
        {
            return;
        }

        health -= 1;
        is_hit = true;

        TheIfStatement();
    }

    public void SpiderIdleSound()
    {
        enemy_audio.PlayOneShot(idleAudio, 0.3f);
    }
}
