using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject

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

    [Header("Animation player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";


}
