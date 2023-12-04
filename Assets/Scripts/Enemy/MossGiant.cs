using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    [SerializeField]
    
    public int Health { set; get; }

    public override void init()
    {
        base.init();
        health = 3;
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("damage()");
        Health--;
        anim.SetTrigger("Hit");
        
            _isHit = true;
        
        if (Health == 0 )
        {
            boxCollider.enabled = false;
            anim.SetTrigger("Death");
            speed = 0;
            Destroy(this.gameObject, 2f);
        }
    }
}
