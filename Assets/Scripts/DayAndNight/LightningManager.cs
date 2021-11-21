using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LightningManager : MonoBehaviour
{
    // Tydligen referencer
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightningPreset Preset;

    // Uppenbarligen variabler 
    [SerializeField, Range (0, 24)]public float TimeOfDay;
    [SerializeField] public Slider mySlider;


    private void Update()
    {
       
        if (Preset == null)
            return;
        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24; //gör värdet mellan 0-24

           UpdateLightning(mySlider.value/24f);
            //Testar att använda slidern...
            //UpdateLightning(TimeOfDay / 24f);
        }
        else
        {
            UpdateLightning(mySlider.value / 24f);
            //Testar att använda slidern...
            //UpdateLightning(TimeOfDay / 24f);
        }
    }

    public float getTime()
    {
        return TimeOfDay;
    }

    
    private void UpdateLightning(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight !=null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, -170, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

}
