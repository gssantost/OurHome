using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    GameObject grandparent; 

    public void actionMessage() {
        grandparent.GetComponent<Interactive>().finishMessage();
    }


    public void setGrandparent(GameObject grandparent) {
        this.grandparent = grandparent;
    }
}
