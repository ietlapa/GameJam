using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float groundDistance;
    public LayerMask groundLayer; 
    public SpriteRenderer sr;
    
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb == null)
        {
            return;
        }
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, groundLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDistance;
                transform.position = movePos;
            }
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0, y);
        rb.velocity = moveDirection * speed;

        if(x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if(x != 0 && x > 0)
        {
            sr.flipX = false;
        }

    }
}