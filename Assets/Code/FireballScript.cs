using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<SpriteRenderer>().flipX == false)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -transform.right * speed; 
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);  

        }

        if(collision.collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.tag == "Fireball")
        {
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.tag == "Temp")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);

        }

    }

}
