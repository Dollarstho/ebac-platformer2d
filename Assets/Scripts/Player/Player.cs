using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public HealthBase healthBase;

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

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;
    public Animator animator;

    private float _currentspeed;

    private bool _isJump = false;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(sOPlayerSetup.triggerDeath);
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
            if(rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX (-1, .1f);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentspeed, rb.velocity.y);
            if (rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1, .1f);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolRun, false);
        }
    }

    private void HandleJump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool(sOPlayerSetup.boolJump, true);
            rb.velocity = Vector2.up * forcejump;
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);

            HandleScaleJump();

            _isJump = true;
            
        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolJump, false);
        }
    }

    private void HandleScaleJump()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);   
    }

    public void DestroyMe()
    
    {
        Destroy(gameObject);
    }

}
