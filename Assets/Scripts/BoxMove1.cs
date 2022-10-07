using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove1 : MonoBehaviour
{

    public int forwardBackwards;
    public int leftRight;
    public int health;

    bool ableToJump;
    bool damaged;

    Animator animator;
    Animator otherAnimator;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {

        forwardBackwards = 0;
        leftRight = 0;
        health = 10;

        ableToJump = false;
        damaged = false;

        animator = transform.GetChild(0).GetComponent<Animator>();
        otherAnimator = GameObject.Find("Box2").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        forwardBackwards = 0;
        leftRight = 0;

        if (Input.GetKey(KeyCode.W)) // forward
        {
            forwardBackwards = 1;

        }
        else if (Input.GetKey(KeyCode.S)) // backwards
        {
            forwardBackwards = -1;
        }

        if (Input.GetKey(KeyCode.A)) // left
        {
            leftRight = -1;
        }
        else if (Input.GetKey(KeyCode.D)) // right
        {
            leftRight = 1;
        }



        if (Input.GetKeyDown(KeyCode.Q)) // hit
        {
            // hit and increment damage to other player
            animator.SetTrigger("hitTrigger");
        }
        if (Input.GetKeyDown(KeyCode.E) && ableToJump) // jump
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * forwardBackwards * 20.0f);
        transform.Rotate(Vector3.up * Time.deltaTime * 180.0f * leftRight, Space.World);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Equals("Cylinder"))
        {
            ableToJump = true;
        }
        
        if (collision.gameObject.name.Equals("Box2Parent") && otherAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit") && (damaged == false))
        {
            damaged = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name.Equals("Cylinder"))
        {
            ableToJump = false;
        }

        if (collision.gameObject.name.Equals("Box2Parent") && (damaged == true))
        {
            health -= 1;
            damaged = false;
        }
    }

}
