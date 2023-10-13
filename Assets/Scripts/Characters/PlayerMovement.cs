using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000)]
    private float MoveSpeed = 10.0f;

    private Rigidbody2D rb;

    public Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();

        
    }
    private void MoveCharacter()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 inputVec = new Vector2(xInput, yInput);
        Vector2 normalizedInput = inputVec.normalized;
        rb.MovePosition(rb.position +
                        new Vector2(normalizedInput.x * MoveSpeed, normalizedInput.y * MoveSpeed) * Time.deltaTime);
        if (normalizedInput.x != 0 || normalizedInput.y != 0)
        {
        animator.SetFloat("X", xInput);
        animator.SetFloat("Y", yInput);

        animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
