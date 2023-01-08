using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBear : MonoBehaviour
{
    public AIPath aP;
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float targetDistance;
    public PlayerHealthSystem playerHealth;

    private float damageTimer = 0;

    private Animator playerAnimator;

    public int health = 0;

    public bool isBird = false;

    
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>(); 
       animator = transform.GetChild(0).GetComponent<Animator>();
       playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        aP.canMove = false;
        if(Vector2.Distance(player.transform.position, transform.position) < targetDistance)
        {
            aP.canMove = true;
            animator.SetBool("EnemyMove", true);
            
        }
        else
        {
            animator.SetBool("EnemyMove", false);
        }
        if(aP.desiredVelocity.x >= 0.01f)
        {
            if(isBird == true)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            //spriteRenderer.flipX = false;
        }
        else if(aP.desiredVelocity.x <= 0.01f)
        {
            if(isBird == true)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            //spriteRenderer.flipX = true;
        }

        if(Vector2.Distance(player.transform.position, transform.position) < 0.5f)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {

            }
            else
            {
                damageTimer += Time.deltaTime;
                print(damageTimer);

                if(damageTimer >= 2)
                {
                    playerHealth.TakeDamage(1);
                    playerHealth.UpdateHealth();
                    damageTimer = 0;
                }
            }


            

        }

    }

    public void EnemyDamaged(int dmg, Collider2D enem)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(enem);
            enem.transform.gameObject.SetActive(false);
            print("Destroyed");
        }
    }

     public void EnemyDamaged(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            transform.gameObject.SetActive(false);
            print("Destroyed");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.tag == "Fireball")
        {
            EnemyDamaged(15);

        }

    }
}
