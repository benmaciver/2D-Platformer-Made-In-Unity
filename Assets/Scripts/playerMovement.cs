using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //creates private empty Rigidbody2D obbject from the UnityEngine class 
    private Rigidbody2D rigidBody;
    // Does the same with an animator object from the same class
    private Animator animator;
    // and then with a Camera object
    private Camera mainCamera;
 
    //float variable that stores how fast the player moves
    private float movementSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //assigns the Rigid Body Component that was assigned to the player character in the unity editor
        rigidBody = GetComponent<Rigidbody2D>();
        //does the same with the Animator Component
        animator = GetComponent<Animator>();
        // assigns mainCamera the value Camera.main (which unity already recognises as the main camera)
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //When the left or right arrow key is pressed a -1 or 1 float value is returned
        float moveDirection = Input.GetAxis("Horizontal");
        //calls Move() method with moveDirection as parameter
        Move(moveDirection,movementSpeed);

    }
    //when called the player will move in the correct direction, and face the right direction
    void Move(float movementDirection, float moveSpeed)
    {
        //stores the scale/size of the player(or at least the unity object this script is assigned to which in this case is the player)
        Vector3 characterScale = transform.localScale;
        //sets the moveStatus perameter in the animator component for the player to 1, which triggers the running animation
        animator.SetFloat("moveStatus", 1);
        //Left arrow key is pressed
        if (movementDirection == -1)
        {
            //changes the x value on the character scale to -1.6 rather than 1.6 which makes the players model face to the left
            characterScale.x = -1.6f;
        }
        //right arrow key is pressed
        if (movementDirection == 1)
        {
            //Does the same as when left key pressed, except facing the right
            characterScale.x = 1.6f;
        }
        if (movementDirection == 0) //if an arrow key isnt being clicked
        {
            //sets moveStatus to 0, which causes the player to change to an idle animation
            animator.SetFloat("moveStatus", 0);
        }
        
        //Time.deltaTime is a unity vakue that stores the time in seconds since the last frame
        //the position of the player is increased on the x axis by the movementDirection at moveSpeed (Time.deltaTime ensures that the player dosent zip past the screen when moving)
        transform.position += new Vector3(movementDirection, 0f, 0f) * Time.deltaTime * moveSpeed;
        //moves the camera on the x axis the player moves (only once the player passes the middle of the screen 
        if (transform.position.x > 0) { mainCamera.transform.position += new Vector3(movementDirection, 0f, 0f) * Time.deltaTime * moveSpeed; }
        // actually stores any character scale changes to the transform component of the player unity game object
        transform.localScale = characterScale;
    }

}
