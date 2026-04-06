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

    [Header("Setup")]
    public SOPlayerSetup sOPlayerSetup;

    private float _currentspeed;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;



    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + spaceToGround);
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
        IsGrounded();
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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool(sOPlayerSetup.boolJump, true);
            rb.velocity = Vector2.up * sOPlayerSetup.forcejump;
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);

            HandleScaleJump();
            PlayJumpVFX();

        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolJump, false);
        }
    }

    private void PlayJumpVFX()
    {
        if (jumpVFX != null)
        {
            VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.Jump, transform.position);
            //jumpVFX.Play();
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
