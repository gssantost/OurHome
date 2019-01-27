using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoType : MonoBehaviour {

    public Text displayText;
    public float letterPause = 0.2f;

    private string message;
    private string textFragment;
    private int counter = 0;

    public GameObject optionsMenu;
    public GameObject choiceA;
    public GameObject choiceB;
    public GameObject choiceC;
    
   
    private enum States {
        beginning, garden, pet, feeling, room, store, park, end, areYouSure, completelySure
    }

    private States currentState;

    void Start() {
        PlayerPrefs.DeleteAll();
        beginning();
    }

    private void setChoice(GameObject obj, string text) {
        obj.transform.GetChild(0).GetComponent<Text>().text = text;
    }

    private Button getChoiceButton(GameObject obj) {
        return obj.transform.GetComponent<Button>();
    }

    private void toggleChoices(bool t) {
        optionsMenu.SetActive(t);
    }

    string readString(string name) {
        textFragment = "";
        string path = "Assets/Resources/novel/" + name + ".txt";
        StreamReader reader = new StreamReader(path);
        textFragment = reader.ReadToEnd();
        reader.Close();
        return textFragment;
    }

    void removeAllListeners() {
        getChoiceButton(choiceA).onClick.RemoveAllListeners();
        getChoiceButton(choiceB).onClick.RemoveAllListeners();
        getChoiceButton(choiceC).onClick.RemoveAllListeners();
    }

    void beginning() {
        toggleChoices(false);
        currentState = States.beginning;
        message = "Despiertas rodeado por la bruma del desastre. La tormenta ha pasado llevándose consigo todo lo que te era más preciado. " +
            "Algunas lágrimas te rozan las mejillas. Sí, has estado llorando durante los últimos instantes. Aun así, la caótica sinfonía se ha ido muy lejos." +
            "Estás solo, con la vista hacia el cielo.Todo es penumbra: un manto gris se ha apoderado del mundo. ¿Qué piensas?";

        type();
    }

    void garden() {
        toggleChoices(false);
        currentState = States.garden;
        message = "Les recuerdas dándote la mano en cada recorrido a la montaña, caminando de lado junto a ti mientras las aves cantan. " +
            "Te ahoga nuevamente el deseo de llorar. Te has dado cuenta de que la memoria de tus padres no es más que una telaraña: eres incapaz de recordarlos por completo." +
            "Por alguna razón, de pronto sólo puedes evocar la flor preferida del jardín de mamá. ¿De qué color era?";
        type();
    }

    void pet() {
        toggleChoices(false);
        currentState = States.pet;
        message = "Intentas recordar a tus seres queridos, aquellos que te hacen sentir más feliz. Recuerdas incluso a la mascota de casa, sin embargo, ahora ves una burbuja deforme en tu mente. Parece más bien una quimera, algo desconocido por los humanos. " +
            "Recuerdas a tu mascota como un…";
        type();
    }

    void feeling() {
        toggleChoices(false);
        currentState = States.feeling;
        message = "La tormenta te ha debilitado, pero algunas piezas están restando, como si unas garras te hubiesen despojado de algo valioso.\nSerá…";
        type();
    }

    void room() {
        toggleChoices(false);
        currentState = States.room;
        message = "Mientras sigues contemplando el cielo, cuyo color sabes alguna vez fue el azul, recuerdas la calidez de tu habitación y tu preciosa colección sobre la alta repisa. Diriges la mano hacía las nubes, cómo para intentar alcanzar tu reliquia más preciada:";
        type();
    }

    void store() {
        toggleChoices(false);
        currentState = States.store;
        message = "Muy lejos, crees observar las ruinas de una ciudad. El lugar bullicioso al que solías acudir de la mano de tu abuela… Tarde o temprano, esperabas su pregunta: Dime ya, ¿qué golosina deseas?";
        type();
    }

    void park() {
        toggleChoices(false);
        currentState = States.park;
        message = "La brisa del parque y tus días de caminata vuelven de improvisto, ese lugar estampado por el entusiasma y la alegría de los niños. ¡Anhelas todo aquello tan hermoso de vuelta! Ves a una familia, a un inspirado cocinero y también a una anciana dándole semillas a los pájaros.\n\n ¿Qué extrañas más? ";
        type();
    }

    void end() {
        toggleChoices(false);
        currentState = States.end;
        message = "Retomas el aliento. Desear recuperarlo todo. Y atado a la esperanza de esto, decides ponerte en pie.\n¿Será posible reconstruir tu hogar?";
        type();
    }
    
    void areYouSure()
    {
        toggleChoices(false);
        currentState = States.areYouSure;
        message = "¿Estás seguro de dejar atrás tu hogar?";
        type();
    }

    void completelySure()
    {
        toggleChoices(false);
        currentState = States.completelySure;
        message = "¿Estás completamente seguro?\n\nSi no haces esto podrás perder todo lo realmente importante para tí.";
        type();
    }

    void setPreference(string key) {
        Debug.Log(counter);
        PlayerPrefs.SetString(counter.ToString(), key);
        PlayerPrefs.SetInt("length", counter);
        counter++;
    }

    void changeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void type() {
        removeAllListeners();
        switch (currentState) {
            case States.beginning:
                setChoice(choiceA, "En mis padres");
                getChoiceButton(choiceA).onClick.AddListener(garden);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("parents"); });
                setChoice(choiceB, "En alguien preciado");
                getChoiceButton(choiceB).onClick.AddListener(pet);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("friend"); });
                setChoice(choiceC, "En mí");
                getChoiceButton(choiceC).onClick.AddListener(feeling);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("myself"); });
                break;
            case States.garden:
                setChoice(choiceA, "Azul");
                getChoiceButton(choiceA).onClick.AddListener(room);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("blue"); });
                setChoice(choiceB, "Amarillo");
                getChoiceButton(choiceB).onClick.AddListener(store);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("yellow"); });
                setChoice(choiceC, "Rojo");
                getChoiceButton(choiceC).onClick.AddListener(store);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("red"); });
                break;
            case States.room:
                setChoice(choiceA, "Tu primer mando de consola");
                getChoiceButton(choiceA).onClick.AddListener(end);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("gamepad"); });
                setChoice(choiceB, "Tu balón de baloncesto");
                getChoiceButton(choiceB).onClick.AddListener(park);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("basketball"); });
                setChoice(choiceC, "Tu oso de peluche");
                getChoiceButton(choiceC).onClick.AddListener(store);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("teddy"); });
                break;
            case States.pet:
                setChoice(choiceA, "Perro");
                getChoiceButton(choiceA).onClick.AddListener(park);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("dog"); });
                setChoice(choiceB, "Gato");
                getChoiceButton(choiceB).onClick.AddListener(park);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("cat"); });
                setChoice(choiceC, "Pájaro");
                getChoiceButton(choiceC).onClick.AddListener(feeling);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("bird"); });
                break;
            case States.park:
                setChoice(choiceA, "La niñez");
                getChoiceButton(choiceA).onClick.AddListener(end);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("moon"); });
                setChoice(choiceB, "Tu familia");
                getChoiceButton(choiceB).onClick.AddListener(end);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("sun"); });
                setChoice(choiceC, "La bondad");
                getChoiceButton(choiceC).onClick.AddListener(end);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("stars"); });
                break;
            case States.feeling:
                setChoice(choiceA, "¿Alegría?");
                getChoiceButton(choiceA).onClick.AddListener(park);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("joy"); });
                setChoice(choiceB, "¿Paz?");
                getChoiceButton(choiceB).onClick.AddListener(park);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("peace"); });
                setChoice(choiceC, "¿Amor?");
                getChoiceButton(choiceC).onClick.AddListener(park);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("love"); });
                break;
            case States.store:
                setChoice(choiceA, "Helado");
                getChoiceButton(choiceA).onClick.AddListener(park);
                getChoiceButton(choiceA).onClick.AddListener(delegate { setPreference("icecream"); });
                setChoice(choiceB, "Chocolate");
                getChoiceButton(choiceB).onClick.AddListener(park);
                getChoiceButton(choiceB).onClick.AddListener(delegate { setPreference("chocolate"); });
                setChoice(choiceC, "Pastel");
                getChoiceButton(choiceC).onClick.AddListener(park);
                getChoiceButton(choiceC).onClick.AddListener(delegate { setPreference("cake"); });
                break;
            case States.end:
                setChoice(choiceA, "Sí");
                getChoiceButton(choiceA).onClick.AddListener(delegate { changeScene("SampleScene");  });
                setChoice(choiceB, "No");
                getChoiceButton(choiceB).onClick.AddListener(areYouSure);
                choiceC.SetActive(false);
                break;
            case States.areYouSure:
                setChoice(choiceA, "Sí");
                getChoiceButton(choiceA).onClick.AddListener(completelySure);
                setChoice(choiceB, "No");
                getChoiceButton(choiceB).onClick.AddListener(end);
                choiceC.SetActive(false);
                break;
            case States.completelySure:
                setChoice(choiceA, "Sí");
                getChoiceButton(choiceA).onClick.AddListener(delegate { changeScene("Start Screen"); });
                setChoice(choiceB, "No");
                getChoiceButton(choiceB).onClick.AddListener(end);
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
        message = "";
    }
}
