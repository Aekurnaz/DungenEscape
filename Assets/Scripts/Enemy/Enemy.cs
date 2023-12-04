using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class  Enemy : MonoBehaviour
{
    [SerializeField] protected int health, speed, gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Animator anim;
    protected SpriteRenderer spriteRenderer;
    protected BoxCollider2D boxCollider;
    protected Vector3 CurrentPos;
    protected bool _isHit=false;
    protected float distance;
    Player player;
    protected float enemyFaceDistance;
    
    public virtual void init()
    { 
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }
    private void Start()
    {
        init();
    }
    public virtual void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
        {
            return;
        }
        Movement();
        
    }
    public virtual void Movement()
    {
        if (pointA.position.x == transform.position.x)
        {
            CurrentPos = pointB.position;
            spriteRenderer.flipX = false;
            anim.SetTrigger("Idle");
        }
        else if (pointB.position.x == transform.position.x)
        {
            CurrentPos = pointA.position;
            spriteRenderer.flipX = true;
            anim.SetTrigger("Idle");
            
        }
        transform.position = Vector3.MoveTowards(transform.position, CurrentPos, speed * Time.deltaTime);
        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        enemyFaceDistance = player.transform.localPosition.x - transform.localPosition.x;

        if (distance > 3.0f || player._health == 0)
         {
             _isHit = false;
         }
        else
        {
            _isHit = true;
        }
       

        if (_isHit == true )
        {
            anim.SetBool("Attack", true);
            speed = 0;
            if (enemyFaceDistance < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (enemyFaceDistance > 0)
            {
                spriteRenderer.flipX = false;
            }
            
        }
        else if ( _isHit == false && health != 0) 
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false)
            {
                anim.SetBool("Attack", false);
                speed = 2;
                if (CurrentPos == pointA.position)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }
    
}
