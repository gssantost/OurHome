using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour
{
     
    public GameObject target;
    public PostProcessingProfile effectProfile;
    public float saturation = 0.5f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (effectProfile.colorGrading.enabled)
        {
            //Debug.Log("Saturation:" + saturation);
            var colorGradient = effectProfile.colorGrading.settings;
            colorGradient.basic.saturation = saturation;
            effectProfile.colorGrading.settings = colorGradient;

            //Debug.Log("Saturation setting:" + colorGradient.basic.saturation);
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y,transform.position.z);
    }
}
