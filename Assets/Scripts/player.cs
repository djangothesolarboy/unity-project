using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    // ran at the start
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    // runs every frame
    {

        // handles controls 
        // -1 = left | 0 = none | 1 = right
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset movedelta
        moveDelta = new Vector3(x, y, 0);

        // swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // checks a direction by casting a box first, if box returns null the player can move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Entities", "Blocking"));

        if (hit.collider == null) {
            // making sprite move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x, 0),Mathf.Abs(moveDelta.x * Time.deltaTime),LayerMask.GetMask("Entities", "Blocking"));

        if (hit.collider == null) {
            // making sprite move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }


        // Debug.Log(y);
    }
}
