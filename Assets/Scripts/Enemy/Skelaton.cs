using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelaton : Enemy, IDamageable
{
    
    public int Health { set; get; }


    public override void Update()
    {
        base.Update();
    }

    public override void init()
    {
        base.init();
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Damage()");
        Health--;
        health--;
        anim.SetTrigger("hit");
        
            _isHit = true;
        
        
        if (Health == 0)
        {
            boxCollider.enabled = false;
            anim.SetTrigger("Death");
            speed = 0;
            Destroy(this.gameObject,2.07f);
        }
    }
}
