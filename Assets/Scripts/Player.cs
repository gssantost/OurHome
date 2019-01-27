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

    public GameObject emoji;

    private float objetiveComplete = 0f;
    private int objetiveMax = 1;

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
                if (another.CompareTag("Primary")){
                    Debug.Log("Primary");
                    completeObjetive();
                    another.gameObject.GetComponent<Interactive>().Interaction();
                    another.gameObject.SetActive(false);
                    emoji.SetActive(false);
                }
                else if (another.CompareTag("Secondary"))
                {
                    Debug.Log("Secondary");
                    inventory.add(another.gameObject);
                    Destroy(another.gameObject);
                }
                else if (another.CompareTag("NPC")) {
                    Debug.Log("NPC");
                    another.gameObject.GetComponent<Interactive>().Interaction();
                } else if (another.CompareTag("Event")) {
                    Debug.Log("Event");
                    another.gameObject.GetComponent<EventInteraction>().Interaction();
                } else if (another.CompareTag("Final")){

                    another.gameObject.GetComponent<FinalEvent>().Interaction();
                }
                another = null;
            }
        }
    }

    private void Movement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 axisInput = new Vector2((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical",Input.GetAxisRaw("Vertical"));
        rb.velocity = axisInput * speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
        another = other;
        emoji.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
        another = null;
        emoji.SetActive(false);
    }

    public float getPercentage() {
        return objetiveComplete / (float) (PlayerPrefs.GetInt("length")+1);
    }

    public void completeObjetive() {
        //if (objetiveMax < objetiveComplete+1) {
            objetiveComplete++;
        //}
    }

}