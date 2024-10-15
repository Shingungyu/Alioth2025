using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // 플레이어 이동 속도
    public float jumpForce; // 플레이어 점프력
    private int jumpCount = 2; // 점프 카운트 추적

    private bool onGround = true; // 플레이어 지면 접촉
    public bool isColliding = false; // 벽 접촉 확인

    private Rigidbody2D rigid;
    private Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어 좌,우 이동
        float moveDirection = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveDirection * moveSpeed, rigid.velocity.y);

        // 플레이어가 바라보는 방향 전환, 걷기 애니메이션
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

        // 지면 접촉 시, 점프 카운트 초기화
        if (onGround)
        {
            jumpCount = 1;
        }

        // 점프 키 누를 시, 점프 카운트 조건에 따라 점프 발생
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpCount--;

            // y축 속도를 0으로 초기화하여 이전 점프/하강 속도를 제거
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

            // 점프력을 적용
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 점프, 추락 애니메이션 업데이트
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
    private void Die()
    {

        rigid.velocity = Vector2.zero;

        anim.SetTrigger("isDie");
        rigid.bodyType = RigidbodyType2D.Static; // 플레이어 위치 고정

        // 애니메이션이 전환될 시간을 잠시 기다립니다.
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; // 한 프레임 대기
        yield return new WaitForSeconds(0.12f); // 약간의 추가 대기

        // 사망 애니메이션 길이를 가져옵니다.
        float dieDuration = anim.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(RestartScene(dieDuration));
    }

    private IEnumerator RestartScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }

}
