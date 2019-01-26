using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(3, 20)]
    public int speed = 5;
    private Animator animator;

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
    }

    private void Movement()
    {
        
        Vector3 axisInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical",Input.GetAxisRaw("Vertical"));
        transform.position = Vector2.MoveTowards(transform.position, axisInput+transform.position, Time.deltaTime * speed);



    }


}