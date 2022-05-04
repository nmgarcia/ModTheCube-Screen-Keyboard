using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnKeyPressed : MonoBehaviour
{
    private Button button;
    [SerializeField] private KeyCode keyCode;
    void Start()
    {
        button = GetComponent<Button>();
        //button.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            FadeColor(button.colors.pressedColor);
            button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(keyCode))
        {
            FadeColor(button.colors.normalColor);
        }
    }

    private void FadeColor(Color pressedColor)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(pressedColor, button.colors.fadeDuration, true, true);
    }

    
}
