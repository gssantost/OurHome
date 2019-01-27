using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private string textFragment;
    private bool done;
    public string message;
    public Text displayText;
    public float letterPause = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        message = "N U E S T R O   H O G A R   comienza a tejerse desde el momento en el nacemos, de la mano de tu familia. Seres queridos vendrán de todas partes. Emociones, sentimientos y demás, uno tras otro, se van transformando en lo que tu definirás como hogar.\nAquí y en todo momento, tras tormentas o separaciones, serás capaz de crearlo.";
        StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            displayText.text = "";
            message = "Gracias por Jugar";
            done = true;
            StartCoroutine(TypeText());
        }
    }

    string readString(string name)
    {
        textFragment = "";
        string path = "Assets/Resources/novel/" + name + ".txt";
        StreamReader reader = new StreamReader(path);
        textFragment = reader.ReadToEnd();
        reader.Close();
        return textFragment;
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        message = "";
        if (done)
        {
            SceneManager.LoadScene("Start Screen");
        }
    }
}
