using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fi_Controller : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    float normallySpeed;
    Rigidbody rigid;
    Vector3 direction;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jump = 7f;
    bool isGrounded = true;
    [SerializeField] Animator anim;


    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("Jump", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        normallySpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0.0f, vertical);
        direction = transform.TransformDirection(direction);
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Run", true);
        }
        if (direction.x == 0 || direction.z == 0)
        {
            anim.SetBool("Run", false);
        }
    

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);
        }
    }

    void FixedUpdate()
    {
        rigid.MovePosition(transform.position + direction * normallySpeed * Time.deltaTime);
    }
}
