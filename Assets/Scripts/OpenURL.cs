using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour
{
    public string twitterUrl = "https://www.x.com/BlitzBotzLinea";
    public string discordUrl = "https://discord.gg/t4ZKRM7bRc";
    public string telegramUrl = "https://t.me/blitzbotz";


    public void OpenTwitter()
    {
        Application.OpenURL(twitterUrl);
    }

    public void OpenDiscord()
    {
        Application.OpenURL(discordUrl);
    }

    public void OpenTelegram()
    {
        Application.OpenURL(telegramUrl);
    }
}
