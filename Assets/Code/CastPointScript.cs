using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastPointScript : MonoBehaviour
{
    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(GetComponentInParent<SpriteRenderer>().flipX == false)
            {
                fireball.GetComponent<SpriteRenderer>().flipX = false;
               
            }
            else
            {
                fireball.GetComponent<SpriteRenderer>().flipX = true;
                
    
            }
            
                
            Instantiate(fireball, transform.position, transform.rotation);
        }

        
    }

    

}
