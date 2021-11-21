using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFlexColor : MonoBehaviour
{
    public Color Color1, Color2, Color3, Color4, Color5, Color6;
    public float Speed = 1, Offset;

    private Color chosenColor;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        int randColor = Random.Range(1, 7);
        if (randColor == 1) chosenColor = Color1;
        else if (randColor == 2) chosenColor = Color2;
        else if (randColor == 3) chosenColor = Color3;
        else if (randColor == 4) chosenColor = Color4;
        else if (randColor == 5) chosenColor = Color5;
        else if (randColor == 6) chosenColor = Color6;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.
        //_propBlock.SetColor("_Color", Color.Lerp(Color1, Color2, (Mathf.Sin(Time.time * Speed + Offset) + 1) / 2f));
        _propBlock.SetColor("_Color", chosenColor);
        // Apply the edited values to the renderer.
        _renderer.SetPropertyBlock(_propBlock);
    }
}
