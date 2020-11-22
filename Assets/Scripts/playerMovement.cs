using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //creates public unity LayerMask object, that is assigned the platform layer in the unity editor
    public LayerMask platformLayerMask;
    //creates private empty Rigidbody2D obbject from the UnityEngine class 
    private Rigidbody2D rigidBody;
    // Does the same with an animator object from the same class
    private Animator animator;
    // and then with a Camera object
    private Camera mainCamera;

    private Collider2D playerCollider;

    //float variable that stores how fast the player moves
    private float movementSpeed = 5f;

    private float nextAttackTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //assigns the Rigid Body Component that was assigned to the player character in the unity editor
        rigidBody = GetComponent<Rigidbody2D>();
        //does the same with the Animator Component
        animator = GetComponent<Animator>();
        // assigns mainCamera the value Camera.main (which unity already recognises as the main camera)
        mainCamera = Camera.main;
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the left or right arrow key is pressed a -1 or 1 float value is returned
        float moveDirection = Input.GetAxis("Horizontal");
        //calls Movement() method with moveDirection as parameter
        Movement(moveDirection,movementSpeed);
        mainCamera.transform.position = CameraMovement(mainCamera.transform);
        
        if (IsGrounded() == true){animator.SetBool("isJumping", false);} // Calls IsGrounded method to check whether playing is touching the ground, if so stops jumping animation
        if (IsGrounded() == false){animator.SetBool("isJumping", true);} //Does the opposite
        
        if (Input.GetKeyDown(KeyCode.UpArrow)){Jump();} //If Up arrow key pressed calls Jump() method
        if (Input.GetKeyDown(KeyCode.Space)){Attack();} //when space is clicked Attack() is called

        if( transform.position.y < -10) { Dead(); }//when the player falls off the map it changes to the death screen
    }
    //when called the player will move in the correct direction, and face the right direction
    void Movement(float movementDirection, float moveSpeed)
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
        // actually stores any character scale changes to the transform component of the player unity game object
        transform.localScale = characterScale;
    }

    //this method moves the camera  along with the player as they move
    private Vector3 CameraMovement(Transform camera)
    {
        Vector3 cameraPosition = camera.position;
        if (transform.position.x > 0) { cameraPosition.x = transform.position.x; } //after the player gets half way through the start screen, the camera follows where the player goes
        if (transform.position.x > 90) { print("Track Complete!"); }
        return cameraPosition;
    }

    //When called this method causes the player's character to jump in the air
    void Jump()
    {
        //As long as the player is touching the ground (prevents flying)
        if (IsGrounded() == true)
        {
            //uses unityEngine method to apply force to the player upwards in the y direction, with the unity 2d ForceMode of Impulse (force applied all at once)
            rigidBody.AddForce(Vector2.up * 7.5f, ForceMode2D.Impulse); //
        }
    }
    //this method triggers the player to do their attack ability
    void Attack()
    {
 
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f;
        }
    }
    //this method checks whether the player is currently grounded or not
    private bool IsGrounded()
    {
        //creates a raycascast2d object from UnityEngine that starts at the centre of the player going down on the y axis to the bottom of the players box collider plus 1, looking for other collisders pn the platform Layer (the ground)
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 1f,platformLayerMask);
        Color rayColour;
        if (raycastHit.collider == null)
        {
            rayColour = Color.red;
        }
        else
        {
            rayColour = Color.green;
        }
        
        return raycastHit.collider != null;
    }
    // is called when the player has died (loses health or falls off the map
    void Dead()
    {
        SceneManager.LoadScene(2);
    }

}
