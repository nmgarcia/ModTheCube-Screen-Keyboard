using Assets.ModTheCube;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    [SerializeField] private KeyCode[] keyCodes;
    private float horizontal;
    private float vertical;
    private float scaleMultiplier = 0.001f;
    private float signScaleMultiplier;
    private Vector3 maxScale = new Vector3(2.5f,2.5f,2.5f);
    private Vector3 minScale = new Vector3(0.5f,0.5f,0.5f);
    public float speed =1500f;
    private Renderer meshRenderer;

    
    
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }
    
    void Update()
    {
        if(Input.anyKey)
        {
            var keysPressed = KeysHelper.GetCurrentInterestedKeys(keyCodes);

            foreach (var key in keysPressed)
            {
                switch (key)
                {
                    case KeyCode.UpArrow:
                    case KeyCode.DownArrow:
                    case KeyCode.LeftArrow:
                    case KeyCode.RightArrow:                        
                        Rotate();
                        break;
                    case KeyCode.KeypadPlus:
                    case KeyCode.KeypadMinus:
                        Scale(key);
                        break;
                    case KeyCode.Space:
                        ChangeColor();
                        break;
                }


            }
        }
        
        
    }


    private void ChangeColor()
    {
        Color randomColor = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),1f);

        meshRenderer.material.SetColor("_Color",randomColor);
    }

    private void Scale(KeyCode key)
    {
        signScaleMultiplier = key == KeyCode.KeypadPlus ? 1 : -1;

        float scaleAxis = scaleMultiplier * signScaleMultiplier;

        Vector3 newScale = transform.localScale + new Vector3(scaleAxis, scaleAxis, scaleAxis);

        bool canScale = newScale.x <= maxScale.x && newScale.x >= minScale.x;

        if(canScale)
            transform.localScale = newScale;
    }

    private void Rotate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Rotate(-vertical * speed * Time.deltaTime, -horizontal * speed * Time.deltaTime, 0,Space.World);
    }
}
