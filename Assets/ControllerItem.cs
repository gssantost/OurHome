using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerItem : MonoBehaviour
{
    public GameObject[] mapPosition;
    public GameObject[] listPrefab;


    void Start() {
        for (int i = 0; i<= PlayerPrefs.GetInt("length"); i++) {
            foreach (GameObject prefab in listPrefab){
                //Debug.Log("Prefab lenght:" + listPrefab.Length);
                if (prefab.GetComponent<Item>().getItemName() == PlayerPrefs.GetString(""+i)) {
                    //Debug.Log(PlayerPrefs.GetString(""+i));
                    Instantiate(prefab, mapPosition[i].transform);
                }
            }
        }

    }

    void Update()
    {
        
    }
}
