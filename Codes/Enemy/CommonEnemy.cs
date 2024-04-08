using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : Enemy, IDamageable
{
    public int Health { get; set; }

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
        anim.SetTrigger("IsHitting");
        is_hit = true;
        anim.SetBool("IsCombat", true);

        TheIfStatement();
    }
}
