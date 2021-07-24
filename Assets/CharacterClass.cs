using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    Vector2 _initialPos;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RigidBody2D>().isKinematic = true;
        _initialPos = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnMouseDrag()
    {
        Vector3 movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = movePos;
    }
}
