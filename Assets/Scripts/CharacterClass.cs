using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    
    Vector2 _initialPos;
    Rigidbody2D _rb;

    // DEFINE VELOCITY VALUES
    Vector2 rightVelocity;
    Vector2 leftVelocity;
    Vector2 downVelocity;
    Vector2 upVelocity;

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
        rightVelocity = new Vector2(5, 0);
        leftVelocity = new Vector2(-5, 0);
        downVelocity = new Vector2(0, -5);
        upVelocity = new Vector2(0, 5);
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
            Debug.Log("Space key was pressed");
            moveUp();
        }
    }



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
            _rb.velocity = rightVelocity;

    }


    private void moveDown()
    {
        if (_rb.velocity.y > downVelocity.y)
            _rb.velocity = downVelocity;
    }


    private void moveLeft()
    {
        if (_rb.velocity.x > leftVelocity.x)
            _rb.velocity = leftVelocity;
    }
    
    private void moveUp()
    {
        if (_rb.velocity.y < upVelocity.y)
            _rb.velocity = upVelocity;
    }
}
