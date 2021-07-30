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

    void OnCollisionEnter2D()
    {
        Grounded = true;
    }

    
    private void OnMouseDrag()
    {
        //Vector3 movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = movePos;
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
