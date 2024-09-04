using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class ShareManager : MonoBehaviour
{
    public Button shareButton;

    public String tweetMessage;
   

    public void StartCoroutine()
    {
        StartCoroutine(Share());
    }

    System.Collections.IEnumerator Share()
    {
        yield return new WaitForEndOfFrame();

        string tweetText = Uri.EscapeDataString(tweetMessage);

        string tweetUrl = $"https://x.com/intent/tweet?text={tweetText}";
        Application.OpenURL(tweetUrl);
    }
}
