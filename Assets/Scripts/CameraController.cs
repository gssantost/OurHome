using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour
{
     
    public GameObject player;
    public PostProcessingProfile effectProfile;
    private float progress = 0f;

    private void Start()
    {
        var colorGradient = effectProfile.colorGrading.settings;
        colorGradient.basic.saturation = 0f;
        effectProfile.colorGrading.settings = colorGradient;
        Debug.Log("length Pref " + PlayerPrefs.GetInt("length"));
        for (int i = 0; i <= PlayerPrefs.GetInt("length"); i++)
        {
            Debug.Log(PlayerPrefs.GetString(i.ToString()));
        }
    }

    IEnumerator setSaturation(float saturation) {
        if (effectProfile.colorGrading.enabled)
        {
            var colorGradient = effectProfile.colorGrading.settings;
            while (saturation >= colorGradient.basic.saturation) {    
                colorGradient.basic.saturation += 0.01f;
                effectProfile.colorGrading.settings = colorGradient;
                yield return new WaitForSeconds(0.1f);
            }  
        }
        //Debug.Log("Saturation:" + saturation);
        
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = player.GetComponent<Player>().getPercentage();
        Debug.Log(percentage);
        if (progress<percentage) {
            progress = percentage;
            StartCoroutine(setSaturation(percentage));
        }
        

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z);
    }
}
