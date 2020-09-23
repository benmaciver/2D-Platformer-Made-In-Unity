using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickups : MonoBehaviour
{
    //BoxCollider2D coinCollider;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //coinCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
  
    }

    // Update is called once per frame
    void Update()
    {
       bool touchingPlayer = GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>());
       print(touchingPlayer);
       if (touchingPlayer == true)
        {
            print("coin collected");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
        }

    }

}
