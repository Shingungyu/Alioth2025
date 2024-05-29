using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // �÷��̾� �̵� �ӵ�
    public float jumpForce; // �÷��̾� ������
    private int jumpCount = 2; // ���� ī��Ʈ ����

    private bool onGround = true; // �÷��̾� ���� ����
    public bool isColliding = false; // �� ���� Ȯ��

    private Rigidbody2D rigid;
    private Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // �÷��̾� ��,�� �̵�
        float moveDirection = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveDirection * moveSpeed, rigid.velocity.y);

        // �÷��̾ �ٶ󺸴� ���� ��ȯ, �ȱ� �ִϸ��̼�
        if (moveDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("isWalking", true);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (onGround)
        {
            jumpCount = 2;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpCount--;

            if (jumpCount > 0)
            {
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));

        RaycastHit2D bottomRay = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("BG1"));

        if (bottomRay.collider != null)
        {
            if (bottomRay.distance < 0.6f)
            {
                onGround = true;
            }
        }
        else
        {
            onGround = false;
        }

        if (isColliding)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }

    void UpdateAnimation()
    {
        if (onGround)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            if (rigid.velocity.y > 0)
            {
                anim.SetBool("isJumping", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }
        }
    }
}
