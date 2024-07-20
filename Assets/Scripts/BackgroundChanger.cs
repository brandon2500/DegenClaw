using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{

    public SpriteRenderer backgroundRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public float changeInterval = .2f;

    void Start()
    {
        InvokeRepeating("ChangeBackground", 0f, changeInterval);
    }

    private void ChangeBackground()
    {
        if (backgroundRenderer.sprite == sprite1)
        {
            backgroundRenderer.sprite = sprite2;
        }
        else
        {
            backgroundRenderer.sprite = sprite1;
        }
    }
}
