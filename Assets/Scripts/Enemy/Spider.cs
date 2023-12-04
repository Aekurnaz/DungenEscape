using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { set; get; }

    public override void init()
    {
        base.init();
        health = 3;
        Health = health;
    }

    public void Damage()
    {
        Health--;

       
            _isHit = true;
        
        if (Health == 0)
        {
            boxCollider.enabled = false;
            anim.SetTrigger("Death");
            speed = 0;
            Destroy(this.gameObject, 2f);
        }
    }



}
