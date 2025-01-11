using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 velocity;
    public float speed;
    public float forcejump = 2;
    public float speedRun;

    private float _currentspeed;

    
    
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
        if(Input.GetKey(KeyCode.LeftControl)) 
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
        }
    }
}
