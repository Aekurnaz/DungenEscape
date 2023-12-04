using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator _anim;
    BoxCollider2D _collider;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move(float move)
    {
        if (Input.GetKeyDown(KeyCode.Space) && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") == false)
        {
            _anim.SetTrigger("RegSwing");
        }
        if (move > 0)
        {
            _anim.SetFloat("move", 1f);
            
        }
        else if(move < 0.1)
        {
            _anim.SetFloat("move", 0f);
        }
        
    }
    public void jumping(bool isgraund)
    {
        if (isgraund == true)
        {
            _anim.SetBool("Jumping", false);
        }
        else if(isgraund == false)
        {
            _anim.SetBool("Jumping", true);
        }
    }
    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
    public void Death()
    {
        _collider.enabled = false;
        _anim.SetBool("Death",true);
    }
}
