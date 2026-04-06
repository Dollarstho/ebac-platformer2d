using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public HealthBase healthBase;
    public BoxCollider2D BoxCollider2D;
    public Rigidbody2D rb;
    public Vector2 velocity;
    public Animator animator;

    public SOPlayerSetup sOPlayerSetup;

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
            _currentspeed = sOPlayerSetup.speedRun;
        }
        else
        {
            _currentspeed = sOPlayerSetup.speed;
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
            rb.velocity = Vector2.up * sOPlayerSetup.forcejump;
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
        rb.transform.DOScaleY(sOPlayerSetup.jumpScaleY, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
        rb.transform.DOScaleX(sOPlayerSetup.jumpScaleX, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);   
    }

    public void DestroyMe()
    
    {
        Destroy(gameObject);
    }

}
