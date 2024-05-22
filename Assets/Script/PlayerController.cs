using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //플레이어 이동 속도
    public float jumpForce; //플레이어 점프력

    private bool isGrounded = false; //플레이어 지면 접촉

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    
 
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //플레이어 좌,우 이동------------------------------------//
        float moveDirection = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(moveDirection * moveSpeed, playerRigidbody.velocity.y);
        //-------------------------------------------------------//



        //플레이어가 바라보는 방향 전환, 걷기 애니메이션----------//
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isWalking", true);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        //----------------------------------------------------------//



        //플레이어 점프----------------------------------------------//
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
           
            playerRigidbody.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            
        }
        else if (Input.GetButtonUp("Jump") && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //------------------------------------------------------------//

        if (playerRigidbody.velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
        }
        else if (playerRigidbody.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }    
    }




    //플레이어 지면 접촉 검사--------------------------------------------//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }
    //------------------------------------------------------------------//
}
