using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEvent : MonoBehaviour
{
    private Player player;

    private GameObject canvas;
    public GameObject message;
    private GameObject auxMessage;
    [TextArea]
    public string text;


    private void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
        this.canvas = GameObject.Find("Canvas");
    }

    public void Interaction()
    {

        //this.canvas.transform.GetChild(0).gameObject.SetActive(false);
        auxMessage = Instantiate(message, canvas.transform);
        auxMessage.GetComponent<Message>().setGrandparent(this.gameObject);
        if (player.getPercentage() < 1)
        {
            auxMessage.GetComponent<Message>().setText("No... Aun esto no es un hogar.");
        } else{
            SceneManager.LoadScene("Win");
        }
    }

    public void finishMessage()
    {
        Destroy(auxMessage);
        this.canvas.transform.GetChild(0).gameObject.SetActive(true);
    }
}
