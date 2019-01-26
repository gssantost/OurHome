using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

    private string caption;

    public Option(string capt)
    {
        caption = capt;
    }

    public string Caption() {
        return caption;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
