using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public bool active;
    public int id;
    public GameObject item;

    public void activated() {
        this.active = true;
        this.GetComponent<Image>().color = Color.black;
    }

    public void desactivated() {
        this.active = false;
        this.GetComponent<Image>().color = Color.white;
    }
}
