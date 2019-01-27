using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    GameObject grandparent; 

    public void actionMessage() {

        if (grandparent.GetComponent<Interactive>() != null){
            grandparent.GetComponent<Interactive>().finishMessage();
        } else if(grandparent.GetComponent<EventInteraction>() != null){
            grandparent.GetComponent<EventInteraction>().finishMessage();
        }

    }


    public void setGrandparent(GameObject grandparent) {
        this.grandparent = grandparent;
    }

    public void setText(string text) {
        transform.GetChild(1).GetComponent<Text>().text = text;
    } 
}
