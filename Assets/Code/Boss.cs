using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    public GameObject player;
    public PlayerHealthSystem playerHealth;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask realGround;

    Rigidbody2D rb;
    public float speed = 1f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    private Animator animator;

    public Transform castPoint;
    public GameObject fireball;

    public int bossHealth = 1000;
    private HealthSystemForDummies healthBar;

    public LayerMask whatIsPlayer;

    public static bool isBossAttacking = false;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar = GetComponent<HealthSystemForDummies>();

        StartCoroutine(CastAttack());
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, realGround);

        RaycastHit2D playerOnHead = Physics2D.Raycast(transform.position, Vector2.up, 5, whatIsPlayer);
        if(playerOnHead)
        {
            Debug.DrawRay(playerOnHead.point, playerOnHead.normal, Color.blue);
            timer += Time.deltaTime;
            print(timer + " timer");
        } 
            //print("Debugging");

        if(player.transform.position.x < transform.position.x)
        {
            //print("Looking Left");
            //transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            GetComponent<SpriteRenderer>().flipX = true;
            attackPoint.localPosition = new Vector3(-1, -0.75f, 0);
            castPoint.localPosition = new Vector3(-1f, -0.75f, 0);
            fireball.GetComponent<SpriteRenderer>().flipX = true;

            if(timer > 2)
            {
                Vector2 headPos = Vector2.MoveTowards(transform.position, new Vector2 (3,0), speed * Time.fixedDeltaTime);
                rb.MovePosition(headPos);
            }

            
        }
        else if(player.transform.position.x > transform.position.x)
        {
            //print("Looking right");
            //transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            GetComponent<SpriteRenderer>().flipX = false;
            attackPoint.localPosition = new Vector3(1, -0.75f, 0);
            castPoint.localPosition = new Vector3(1f, -0.75f, 0);
            fireball.GetComponent<SpriteRenderer>().flipX = false;

            if(timer > 2)
            {
                Vector2 headPos = Vector2.MoveTowards(transform.position, new Vector2 (-3,0), speed * Time.fixedDeltaTime);
                rb.MovePosition(headPos);
            }

            
        }

        if(Vector2.Distance(player.transform.position, transform.position) > 2)
        {
            Vector2 target = new Vector2(player.transform.position.x, transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        
        if(Vector2.Distance(player.transform.position, transform.position) < 2)
        {
            if(PlayerController.bAttack == true)
            {
                BossDamaged(10);
                healthBar.AddToCurrentHealth(-10);
                print(bossHealth);
            }

            if(PlayerController.bStrike == true)
            {
                BossDamaged(100);
                healthBar.AddToCurrentHealth(-20);
                print(bossHealth);
            }    
        }

    }

    private float castTimer;
    private float strikeTimer;
    private float defTimer;
    public bool cast = true;
    public bool strk = true;
    public bool def = true;

    private float timePassed = 0;

    IEnumerator CastAttack()
    {
        speed = 1;
        if(cast == true)
        {
            print("Casting");
            animator.SetBool("IsCasting", true);
            
            while(timePassed < 0.05)
            {
                Instantiate(fireball, castPoint.transform.position, castPoint.transform.rotation);
                timePassed += Time.deltaTime;
                //print(timePassed);
                yield return new WaitForSeconds(1);
                //yield return null;

            }
            
            //yield return new WaitForSeconds(5);
            timePassed = 0;
            animator.SetBool("IsCasting", false);
            yield return StartCoroutine(StrikeAttack());
        }
        else
        {
            speed = 0;
            yield return new WaitForSeconds(5);
            yield return StartCoroutine(StrikeAttack());
        }
    }

    IEnumerator StrikeAttack()
    {
        speed = 1;
        if(strk == true)
        {
            print("Striking");
            animator.SetBool("IsStriking", true);

            while(timePassed < 0.05)
            {
                Strike();
                timePassed += Time.deltaTime;
                yield return new WaitForSeconds(1);
                //yield return null;

            }
            //print("strike method complete");
        
            timePassed = 0;
            animator.SetBool("IsStriking", false);
            yield return StartCoroutine(DefAttack());
        }
        else
        {
            speed = 0;
            yield return new WaitForSeconds(5);
            yield return StartCoroutine(DefAttack());
        }
    }

    IEnumerator DefAttack()
    {
        speed = 1;
        if(def == true)
        {
            print("Defending");
            speed = 0;
            animator.SetBool("IsDefending", true);
            yield return new WaitForSeconds(5);
            animator.SetBool("IsDefending", false);
            speed = 1;
            yield return StartCoroutine(CastAttack());
        }
        else
        {
            speed = 0;
            yield return new WaitForSeconds(5);
            yield return StartCoroutine(CastAttack());
        }
    }


     void Strike()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach(Collider2D player in playerHit)
        {
            if(player.GetType() == typeof(BoxCollider2D))
            {
                Debug.Log("We hit" + player.name);
                playerHealth.TakeDamage(1);
                playerHealth.UpdateHealth();
                print("player damage");
                isBossAttacking = true;
            }
        }

    }

     public void BossDamaged(int dmg)
    {
        bossHealth -= dmg;

        if(bossHealth <= 0)
        {
            print("dead");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Fireball")
        {
            BossDamaged(5);
            healthBar.AddToCurrentHealth(-5);
            print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
    }

}
