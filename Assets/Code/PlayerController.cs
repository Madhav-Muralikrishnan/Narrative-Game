using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    float moveH = 0f;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask realGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Vector3 respawnPoint;

    public bool prevLevel = false;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public Transform castPoint;

    private bool attackBool = false;

    private float buttonPressTimer;

    private PlayerHealthSystem playerHealth;

    public static bool bAttack = false;
    public static bool bStrike = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        respawnPoint = transform.position;
        playerHealth = GetComponent<PlayerHealthSystem>();

        if(ChangeLevel.levelTrack == true)
        {
            transform.position = new Vector3(9f,2f,-1f);
            print("bool works");
        }
        else
        {
            print("bool no work");
        }

        //attackPoint = transform.GetChild(2).gameObject;

    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, realGround);

        if(moveInput > 0)
        {
            spriteRenderer.flipX = false;
            attackPoint.localPosition = new Vector3(1, 0, 0);
            castPoint.localPosition = new Vector3(0.7f, -0.5f, 0);

        }
        if(moveInput < 0)
        {
            spriteRenderer.flipX = true;
            attackPoint.localPosition = new Vector3(-1, 0, 0);
            castPoint.localPosition = new Vector3(-1f, -0.5f, 0);
        }
        

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();    
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            bAttack = false;
        }


        if(Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("IsDefending", true);
            speed = 0;
            isJumping = false;
        }
        else
        {
            animator.SetBool("IsDefending", false);
            speed = 5;
            isJumping = true;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            animator.SetBool("IsCasting", true);
        }
        else
        {
            animator.SetBool("IsCasting", false);
        }

        if(Input.GetKey(KeyCode.E))
        {
            buttonPressTimer += Time.deltaTime;
            print(buttonPressTimer);
        }

        if(buttonPressTimer >= 3)
        {
            Strike();
            //transform.position += new Vector3(2f,0,0);
            //transform.position += transform.right * Time.deltaTime;
            //transform.Translate(transform.right * 500 * Time.deltaTime, Space.Self);
        }
        else
        {
            animator.SetBool("IsStriking", false);
            bStrike = false;
        }
        

        //Animations
        animator.SetBool("IsJumping", !isGrounded);

        //animator.SetFloat("yVelocity", rb.velocity.y);
        /*
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }*/

        moveH = Input.GetAxisRaw("Horizontal") * speed;
        if(moveH != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if(Input.GetKeyUp(KeyCode.Y) || transform.position.y <= -6)
        {
            transform.position = respawnPoint;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "NextLevel")
        {
            prevLevel = false;
        }

        if(collider.tag == "PrevLevel")
        {
            prevLevel = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Fireball")
        {
            playerHealth.TakeDamage(1);
            playerHealth.UpdateHealth();
            print(collision.collider.gameObject.tag);
        }

        if(collision.collider.gameObject.tag == "BossFireball")
        {
            playerHealth.TakeDamage(1);
            playerHealth.UpdateHealth();
            print(collision.collider.gameObject.tag);
            print("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");
            Boss.isBossAttacking = true;
        }
    }
    

    void Attack()
    {
        animator.SetBool("IsAttacking", true);

        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enem in enemyHit)
        {
            Debug.Log("We hit" + enem.name);
            //print(enem.transform.GetChild(0).GetComponent<EnemyBear>().EnemyDamaged(5));
            enem.GetComponent<EnemyBear>().EnemyDamaged(1,enem);
            print("damaging");
        }
        
        bAttack = true;

    }

    void Strike()
    {
        animator.SetBool("IsStriking", true);
        buttonPressTimer = 0;

        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enem in enemyHit)
        {
            Debug.Log("We hit" + enem.name);
            //print(enem.transform.GetChild(0).GetComponent<EnemyBear>().EnemyDamaged(5));
            enem.GetComponent<EnemyBear>().EnemyDamaged(50,enem);
            print("damaging");
        }

        bStrike = true;
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
