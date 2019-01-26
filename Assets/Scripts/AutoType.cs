using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {

    public Text displayText;
    public float letterPause = 0.2f;

    private string message;
    public GameObject optionsMenu;
    public GameObject choiceA;
    public GameObject choiceB;
    public GameObject choiceC;
    

    private enum States {
        beginning, parents, sun
    }

    private States currentState;

    void Start() {
        beginning();
    }

    void beginning() {
        toggleChoices(false);
        currentState = States.beginning;
        type();
    }

    void parents() {
        toggleChoices(false);
        currentState = States.parents;
        type();
    }

    void sun() {
        toggleChoices(false);
        currentState = States.sun;
    }

    private void setChoice(GameObject obj, string text) {
        obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }

    private Button getChoiceButton(GameObject obj) {
        return obj.transform.GetComponent<Button>();
    }

    private void toggleChoices(bool t) {
        optionsMenu.SetActive(t);
    }


    public void type() {
        switch (currentState)
        {
            case States.beginning:
                message = "En el medio de la tormenta y la bruma del desastre, ves todo lo preciado desvanecerse. " +
                    "Lluvia y relámpagos a lo lejos, hacen crecer la caótica sinfonía. Estás sólo, con la vista hacía el cielo " +
                    "impenetrable. Qué piensas?";
                setChoice(choiceA, "En mis padres");
                getChoiceButton(choiceA).onClick.AddListener(parents);
                setChoice(choiceB, "En mi mascota");
                setChoice(choiceC, "En mí");
                break;
            case States.parents:
                message = "La historia continúa";
                setChoice(choiceA, "En el sol");
                getChoiceButton(choiceA).onClick.AddListener(sun);
                setChoice(choiceB, "En la luna");
                choiceC.SetActive(false);
                break;
        }
        displayText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText() {
        foreach (char letter in message.ToCharArray()) {
            displayText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        toggleChoices(true);
    }
}
