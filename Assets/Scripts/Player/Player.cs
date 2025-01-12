using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    [Header("Moviment setup")]
    public BoxCollider2D BoxCollider2D;
    public Rigidbody2D rb;
    public Vector2 velocity;
    public float speed;
    public float forcejump = 2;
    public float speedRun;

    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .1f;
    public Ease ease = Ease.OutBack;

    private float _currentspeed;

    private bool _isJump = false;

    
    
    void Start()
    {
        
    }

    private void Update()
    {
        HandleMoviments();
        HandleJump();
    }

    private void HandleMoviments()
    {
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            _currentspeed = speedRun;
        }
        else
        {
            _currentspeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-_currentspeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentspeed, rb.velocity.y);
        }
    }

    private void HandleJump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forcejump;
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);

            HandleScaleJump();

            _isJump = true;
            
        }
    }

    private void HandleScaleJump()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);

        
    }
}
