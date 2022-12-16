using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBear : MonoBehaviour
{
    public AIPath aP;
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        aP.canMove = false;
        if(Vector2.Distance(player.transform.position, transform.position) < 7.5f)
        {
            aP.canMove = true;
        }
        if(aP.desiredVelocity.x >= 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if(aP.desiredVelocity.x <= 0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
