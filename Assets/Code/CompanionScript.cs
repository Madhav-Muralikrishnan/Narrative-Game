using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionScript : MonoBehaviour
{
    public float speed;
    private float moveInput;

    Rigidbody2D rb;

    private Transform target;
    public LayerMask whatIsGround;

    private float angle; 

    public Vector3 respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        transform.position = new Vector3(-10f, -1.7f,-1f);
        respawnPoint = transform.position;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5, whatIsGround);
        if(hit)
        {
            //rb.AddRelativeForce(Vector2.Perpendicular(hit.normal));
            //print("sloping");
            angle = Vector2.Angle(hit.normal, Vector2.up);
            

            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }

        if(Vector2.Distance(target.transform.position, transform.position) > 2)
        {
           transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        RaycastHit2D jump = Physics2D.Raycast(transform.position + new Vector3(0.5f,0, 0), Vector2.down, 5, whatIsGround);
        if(jump)
        {
            Debug.DrawRay(jump.point, jump.normal, Color.blue);
            //rb.velocity = Vector2.up * 5;
        }
        else
        {
            
                print("jumping");
                //rb.velocity = Vector2.up * 5;
                rb.AddForce(Vector2.up * 10);
            
        }

        if(Input.GetKeyUp(KeyCode.Y) || transform.position.y <= -6)
        {
            transform.position = respawnPoint;
        }
    }


}
