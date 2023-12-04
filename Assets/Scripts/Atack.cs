using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    private float _hitRate = 1f;
    private float _canHit = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit:" + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if ((hit != null) && _canHit < Time.time )
        {
            _canHit = Time.time + _hitRate;
            hit.Damage();
        }
    }
    
}
