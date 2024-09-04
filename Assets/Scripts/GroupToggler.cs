using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupToggler : MonoBehaviour
{
    public GameObject[] groupsToToggle;
    public GameObject uiGroup;
    public GameObject backgroundGroup;
    public GameObject youWinGroup;
    public GameObject connectWalletGroup;
    public GameObject oddsCanvas;


    public void ToggleGroupVisibility()
    {
        foreach (GameObject group in groupsToToggle)
        {
            group.SetActive(!group.activeSelf);
        }
    }

    public void ResetScreen()
    {
        uiGroup.SetActive(false);
        backgroundGroup.SetActive(true);
        youWinGroup.SetActive(false);
        connectWalletGroup.SetActive(true);
    }
}
