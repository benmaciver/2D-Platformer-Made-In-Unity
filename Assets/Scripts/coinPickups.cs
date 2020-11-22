using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickups : MonoBehaviour
{
    BoxCollider2D coinCollider;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //coinCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        coinCollider = GetComponent<BoxCollider2D>();
  
    }

    // Update is called once per frame
    void Update()
    {
       if (coinCollider.gameObject.tag.Equals("Player"))
        {
            print("coin collected");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
        }

    }

}
