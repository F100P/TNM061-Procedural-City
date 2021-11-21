
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName  ="Lightning Preset", menuName ="Scriptables/Lightning Preset", order =1)]

public class LightningPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;

}
