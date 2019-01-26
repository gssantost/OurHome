using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private GameObject canvas;
    public GameObject message;

    private void Awake()
    {
        this.canvas = GameObject.Find("Canvas");
    }

    public void Interaction() {
        Time.timeScale = 0f;
        this.canvas.transform.GetChild(0).gameObject.SetActive(false);
        Instantiate(message, canvas.transform);
    }
}
