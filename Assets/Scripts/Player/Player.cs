using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { set; get; }
    [SerializeField]
    private bool _isGraund;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpForce = 5f;
    Rigidbody2D _rb2D;
    private float move;
    PlayerAnim _anim;
    SpriteRenderer _spriteRenderer;
    private IDamageable hit;
    [SerializeField]
    public int _health = 3;

    // Start is called before the first frame update
    void Start()
    {
        Health = _health;
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnim>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        hit = GetComponent<IDamageable>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 && !_isGraund)
        {
            _isGraund = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 && _isGraund)
        {
            _isGraund = false;
        }
    }
    void movement()
    {
        move = Input.GetAxis("Horizontal");
        _rb2D.velocity = new Vector2(move * _speed, _rb2D.velocity.y);
        _anim.move(Mathf.Abs(move));
        if (move < 0 && _health > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (move > 0 && _health > 0)
        {
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && _isGraund == true && _health!=0)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
        _anim.jumping(_isGraund); 
    }
    public void Damage()

    {
        Debug.Log("Player Damage()");
        Health--;
        _health--;
        if(Health > 0)
        {
            _anim.Hit();
        }
        if(Health <= 0 )
        {
            _speed = 0;
            _anim.Death();
        }
    }
   
}
