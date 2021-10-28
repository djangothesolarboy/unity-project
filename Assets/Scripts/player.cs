using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

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

        // making sprite move
        transform.Translate(moveDelta * Time.deltaTime);

        Debug.Log(y);
    }
}
