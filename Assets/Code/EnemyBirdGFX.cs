using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBirdGFX : MonoBehaviour
{
    public AIPath aP;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(aP.desiredVelocity.x >= 0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else if(aP.desiredVelocity.x <= 0.01f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
