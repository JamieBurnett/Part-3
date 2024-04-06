using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public static bool playerInDialogue = false;
    private Vector2 moveInput;
    private Vector2 change;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInDialogue)
        {

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            change = moveInput.normalized * speed;

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + change * Time.deltaTime);

    }
}
