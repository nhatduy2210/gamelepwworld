using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Rigidbody2D rgb;
    private Animator animator;
    public float Speed;
    public bool IsOnGround;
    public bool IsOnWater;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Speed = 0f;
        IsOnGround = true;
        IsOnWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsOnGround", IsOnGround);
        animator.SetFloat("Speed", Speed);
        animator.SetBool("IsOnWater", IsOnWater);

        // lấy vận tốc chuyển động 
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            Speed = 1f;
        }
        else
        {
            Speed = 0f;
        }
    }
    public void SetJumping(bool value)
    {
        IsOnGround = value;
    }
    public void SetRunning(float value)
    {
        Speed = value;
    }
    public void SetSwim(bool value)
    {
        IsOnWater = value;
        
    }
}
