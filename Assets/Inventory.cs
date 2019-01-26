using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Panel[] listPanel;

    private void Start()
    {
        listPanel[0].activated();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            listPanel[0].activated();
            desactivedAll(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            listPanel[1].activated();
            desactivedAll(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            listPanel[2].activated();
            desactivedAll(3);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            listPanel[3].activated();
            desactivedAll(4);
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            listPanel[4].activated();
            desactivedAll(5);
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            listPanel[5].activated();
            desactivedAll(6);
        } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            listPanel[6].activated();
            desactivedAll(7);
        } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            listPanel[7].activated();
            desactivedAll(8);
        } else if (Input.GetKeyDown(KeyCode.Alpha9)) {
            listPanel[8].activated();
            desactivedAll(9);
        }
    }


    private void desactivedAll(int key)
    {
        
        foreach (Panel panel in listPanel) {
            Debug.Log("panel Id:"+panel.id);
            Debug.Log("key Id:" + key);
            if (panel.id != key)
            {
                panel.desactivated(); 
            }
        }
    }

    public void add(GameObject item) {

        foreach (Panel panel in listPanel) {
            if (panel.item.sprite == null) {
                panel.addItem(item);
                break;
            }
        }
    }
}
