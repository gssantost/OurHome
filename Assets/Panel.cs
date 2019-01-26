using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public bool active;
    public int id;
    public Image item;

    public void Start()
    {
        this.item = transform.GetChild(0).GetComponent<Image>();
    }

    public void activated() {
        this.active = true;
        this.GetComponent<Image>().color = Color.black;
    }

    public void desactivated() {
        this.active = false;
        this.GetComponent<Image>().color = Color.white;
    }

    public void addItem(GameObject item)
    {
        Debug.Log("Tuqui tuqui");
        this.item.sprite = item.GetComponent<SpriteRenderer>().sprite;
        this.item.color = Color.white;
    }
}
