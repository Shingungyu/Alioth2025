using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // �÷��̾� �̵� �ӵ�
    public float jumpForce; // �÷��̾� ������
    private int jumpCount = 2; // ���� ī��Ʈ ����

    private bool onGround = true; // �÷��̾� ���� ����
    public bool isColliding = false; // �� ���� Ȯ��

    private Rigidbody2D rigid;
    private Animator anim;

    public AudioSource audioSource; // ����� �ҽ�
    public AudioClip jumpSound;
    public AudioClip portalKeySound;
    public AudioClip Deathsound;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // �ڵ� ��� ��Ȱ��ȭ

        // Resources �������� GameSounds/Playerjump ���� �ε�
        jumpSound = Resources.Load<AudioClip>("GameSounds/Playerjump");
        portalKeySound = Resources.Load<AudioClip>("GameSounds/Potalkey");
        Deathsound = Resources.Load<AudioClip>("GameSounds/Deathsound");
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

        // ���� ���� ��, ���� ī��Ʈ �ʱ�ȭ
        if (onGround)
        {
            jumpCount = 1;
        }

        // ���� Ű ���� ��, ���� ī��Ʈ ���ǿ� ���� ���� �߻�
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpCount--;

            // y�� �ӵ��� 0���� �ʱ�ȭ�Ͽ� ���� ����/�ϰ� �ӵ��� ����
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

            // �������� ����
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            PlayJumpSound();


        }

        // ����, �߶� �ִϸ��̼� ������Ʈ
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
                anim.SetBool("isFalling", false);
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
        rigid.bodyType = RigidbodyType2D.Static; // �÷��̾� ��ġ ����

        // �ִϸ��̼��� ��ȯ�� �ð��� ��� ��ٸ��ϴ�.
        StartCoroutine(WaitForAnimation());
    }

    private void GoUp()
    {
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; // �� ������ ���
        yield return new WaitForSeconds(0.12f); // �ణ�� �߰� ���

        // ��� �ִϸ��̼� ���̸� �����ɴϴ�.
        float dieDuration = anim.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(RestartScene(dieDuration));
    }

    private IEnumerator RestartScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpingBar"))
        {
            // GoUp(); ���� ƨ��
            // jumpForce = 7; ������ �� ������
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            PlayerDeathSound();
            Die();


        }
        else if (collision.gameObject.CompareTag("ClearKey"))
        {
            Destroy(collision.gameObject); // CleayKey ������ ����
            PlayPortalKeySound(); // Potalkey ���� ���
        }
    }

    //���� ���� �Լ�

    private void PlayJumpSound()
    {
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    //��Ż ���� �Լ�.
    private void PlayPortalKeySound()
    {
        if (portalKeySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(portalKeySound);
        }
    }

    //���� ���� �Լ�.

    private void PlayerDeathSound() {

        if (Deathsound != null && audioSource != null)
        {
            audioSource.PlayOneShot(Deathsound);
        }

    }


}
