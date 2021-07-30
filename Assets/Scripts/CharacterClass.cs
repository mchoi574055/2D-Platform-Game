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

    // DEFINE HEALTH VALUES
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPos = new Vector2(0, 0);
        transform.position = _initialPos;

        // INITIALIZE VELOCITY VALUES
        rightVelocity = new Vector2(5, 0);
        leftVelocity = new Vector2(-5, 0);
        downVelocity = new Vector2(0, -5);
        upVelocity = new Vector2(0, 5);

        // INITIALIZE HEALTH VALUES
        maxHealth = 100;
        currentHealth = 100;
        healthbar.SetMaxHealth(maxHealth);


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

        if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("J key pressed");
            currentHealth -= 2;
            healthbar.SetHealth(currentHealth);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnMouseDrag()
    {
        Vector3 movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = movePos;
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
