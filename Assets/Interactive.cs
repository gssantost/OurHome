using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private GameObject canvas;
    public GameObject message;
    private GameObject auxMessage;

    [TextArea]
    public string text;

    private void Awake()
    {
        this.canvas = GameObject.Find("Canvas");
    }

    public void Interaction() {
        Time.timeScale = 0f;
        //Inventario oculta
        //this.canvas.transform.GetChild(0).gameObject.SetActive(false);
        auxMessage = Instantiate(message, canvas.transform);
        auxMessage.GetComponent<Message>().setGrandparent(this.gameObject);
        auxMessage.GetComponent<Message>().setText(text);
    }

    public void finishMessage() {
        Time.timeScale = 1f;
        Destroy(auxMessage);
        this.canvas.transform.GetChild(0).gameObject.SetActive(true);
    }
}
