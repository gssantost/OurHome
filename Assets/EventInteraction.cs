using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteraction : MonoBehaviour
{
    private GameObject canvas;
    public GameObject message;
    private GameObject auxMessage;
    public string textEvent;
    public string textComplete;
    public string itemRequired;
    public int countItemRequired = 1 ;
    private Player player;

    private void Awake()
    {
        this.canvas = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            player = collision.gameObject.GetComponent<Player>();
        }
    }

    public void Interaction()
    {
        Time.timeScale = 0f;
        //Inventario oculta
        //this.canvas.transform.GetChild(0).gameObject.SetActive(false);
        auxMessage = Instantiate(message, canvas.transform);
        auxMessage.GetComponent<Message>().setGrandparent(this.gameObject);
       if (testingCondition()){
            auxMessage.GetComponent<Message>().setText(textComplete);
       }else{
            auxMessage.GetComponent<Message>().setText(textEvent);
       }
        
    }

    public void finishMessage()
    {
        Time.timeScale = 1f;
        Destroy(auxMessage);
        this.canvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    bool testingCondition() {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        int count = 0;
        foreach (Panel panel in player.inventory.listPanel) {
            if (panel.itemName == itemRequired) {
                count++;
                if (count == countItemRequired){
                    foreach (Panel auxPanel in player.inventory.listPanel) {
                        if (auxPanel.itemName == itemRequired) {
                            auxPanel.clearPanel();
                        }
                    }
                    return true;
                }
            }
        }

        return false; 

    }


}
