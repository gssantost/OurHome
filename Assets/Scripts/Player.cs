using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1, 20)]
    public int speed = 5;
    private Animator animator;
    private bool trigger = false;
    public Collider2D another;
    public Inventory inventory;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (trigger)
            {
                if (another.CompareTag("Primary")) {
                    Debug.Log("Primary");
                } else if (another.CompareTag("Secondary")) {
                    Debug.Log("Secondary");
                    inventory.add(another.gameObject);
                    Destroy(another.gameObject);
                }
            }
        }
    }

    private void Movement()
    {
        
        Vector3 axisInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical",Input.GetAxisRaw("Vertical"));
        transform.position = Vector2.MoveTowards(transform.position, axisInput+transform.position, Time.deltaTime * speed);



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
        another = other;
    }

}