using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    public Button button;
    public Image image;
    public Sprite xSprite;
    public Sprite oSprite;

    //private bool isX = false;

    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(Switch(true));
    }


    public void Switch(bool turn)
    {
        if (image.sprite == null)
        {
            image.sprite = turn ? xSprite : oSprite;
        }
    }

    internal Sprite GetCurrentSprite()
    {
        return image.sprite;
    }
}
