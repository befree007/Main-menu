using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [HideInInspector] public int _coinCount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _onGround;

    private const string AnimationRun = "Run";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _rigidbody2D.velocity.y);
        _animator.SetFloat(AnimationRun, Mathf.Abs(Input.GetAxis("Horizontal")));

        if (_rigidbody2D.velocity.x > transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_rigidbody2D.velocity.x < transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround == true)
        {
            Debug.Log("Jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Coin>(out Coin coin))
        {
            _coinCount += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _onGround = false;
        }
    }
}
