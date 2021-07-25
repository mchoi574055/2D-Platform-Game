using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    Vector2 _initialPos;
    Vector2 jumpPos;
    Vector2 jumpLeftPos;
    Vector2 jumpRightPos;
    private Rigidbody2D rb;
    //[SerializeField] private float _launchpower = 150;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        _initialPos = new Vector2(0, 0);
        jumpRightPos = new Vector2(200, 400);
        jumpLeftPos = new Vector2(-200, 400);
        jumpPos = new Vector2(0, 400);
        transform.position = _initialPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log ("update test");
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
}
