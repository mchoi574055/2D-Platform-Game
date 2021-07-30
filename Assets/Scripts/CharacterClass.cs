using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    
    Vector2 _initialPos;
    Rigidbody2D _rb;
    
    public bool Grounded;
    public bool canDoubleJump;
    // DEFINE VELOCITY VALUES
    Vector2 rightVelocity;
    Vector2 leftVelocity;
    Vector2 downVelocity;
    Vector2 upVelocity;
    int jumped = 0;
    Vector2 testVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPos = new Vector2(0, 0);
        jumpRightPos = new Vector2(200, 400);
        jumpLeftPos = new Vector2(-200, 400);
        jumpPos = new Vector2(0, 400);
        transform.position = _initialPos;

        // INITIALIZE VELOCITY VALUES
        rightVelocity = new Vector2(7, 0);
        leftVelocity = new Vector2(-7, 0);
        downVelocity = new Vector2(0, -6);
        upVelocity = new Vector2(0, 6);
        testVelocity = new Vector2(0, 0);
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key was pressed");
            moveRight();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S key was pressed");
            moveDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key was pressed");
            moveLeft();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Grounded)
            {
                Debug.Log("Space key was pressed");
                moveUp();
                Grounded = false;
            }

            else if (canDoubleJump)
            {
                doubleJump();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && jumped == 1)
        {
            Debug.Log("Space key was released");
            canDoubleJump = true;
        }

        if (Grounded)
        {
            canDoubleJump = false;
            jumped = 0;
        }
    }

<<<<<<< Updated upstream

=======
    void OnCollisionEnter2D()
    {
        Grounded = true;
    }
>>>>>>> Stashed changes

    
    private void OnMouseDrag()
    {
        //Vector3 movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = movePos;
        if (Input.GetKeyDown(KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }

        if (Input.GetKeyUp(KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }

        if (Input.GetKeyUp(KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
              GetComponent<Rigidbody2D>().AddForce(jumpPos);
        } 
    }

    private void moveRight()
    {
        if (_rb.velocity.x < rightVelocity.x)
        {
            _rb.AddForce(rightVelocity);
        }

    }


    private void moveDown()
    {
        if (_rb.velocity.y > downVelocity.y)
            _rb.velocity = downVelocity;
        
    }


    private void moveLeft()
    {
        if (_rb.velocity.x > leftVelocity.x)
        {
            _rb.AddForce(leftVelocity);
        }
    }
    
    private void moveUp()
    {
        jumped = 1;
        _rb.velocity = testVelocity;
        _rb.AddForce(transform.up*800);
        
    }

    private void doubleJump()
    {
        canDoubleJump = false;
        _rb.velocity = testVelocity;
        _rb.AddForce(transform.up*600);
        jumped = 0;
    }
}
