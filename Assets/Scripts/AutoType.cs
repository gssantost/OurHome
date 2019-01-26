using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {

    public Text displayText;
    public float letterPause = 0.2f;

    private string message;

    private enum States {
        beginning, parents
    }

    private States currentState;

    void Start() {
        currentState = States.beginning;
        //type(displayText.text);
    }

    void Update() {
        switch (currentState) {
            case States.beginning:
                message = "En el medio de la tormenta y la bruma del desastre, ves todo lo preciado desvanecerse. " +
                    "Lluvia y relámpagos a lo lejos, hacen crecer la caótica sinfonía. Estás sólo, con la vista hacía el cielo " +
                    "impenetrable. Qué piensas?";
                type(message);
            break;
            case States.parents:
                message = "DBUGdudbsdcvdIOYSVDS";
                type(message);
            break;
        }
    }

    public void setState(string state) {
        
    }

    public void type(string m) {
        message = m;
        displayText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText() {
        foreach (char letter in message.ToCharArray()) {
            displayText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
