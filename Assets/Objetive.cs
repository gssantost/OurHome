using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetive : MonoBehaviour
{

    private float objetiveMax = 4f;
    private float objetiveComplete = 0f;

    private void Start()
    {
        //Aqui leo la papu
    }

    private void Update()
    {
        
    }

    public void completeObjetive() {
        this.objetiveComplete++;
    }

    public float getStatus() {
        return objetiveComplete/objetiveMax;
    }
}
