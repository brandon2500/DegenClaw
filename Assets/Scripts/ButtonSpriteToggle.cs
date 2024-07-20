using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteToggle : MonoBehaviour
{
    public Image targetSprite;
    public Sprite sprite1;
    public Sprite sprite2;
    private bool isSprite1 = true; //sprite1 = music on

    public void ToggleSprite()
    {
        if (isSprite1)
        {
            targetSprite.sprite = sprite2;
            Music.Instance.ToggleMusic();
        }
        else
        {
            targetSprite.sprite = sprite1;
            Music.Instance.ToggleMusic();
        }
        isSprite1 = !isSprite1;
    }
}
