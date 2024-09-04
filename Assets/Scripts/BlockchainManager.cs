using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thirdweb;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BlockchainManager : MonoBehaviour
{

    public string Address { get; private set; }

    public static BlockchainManager Instance { get; private set; }

    private Contract contract;
    private Marketplace marketplace;

    public GameObject openPackCanvas;
    public GameObject congratsCanvas;
    public GameObject uiCanvas;
    public GameObject bgCanvas;
    public GameObject cwCanvas;
    public GameObject clawCanvas;
    public GameObject confetti;

    public RewardImageManager rewardImageManager;
    public RewardImageManager1155 rewardImageManager1155;
    public RewardImageManager721 rewardImageManager721;
    public Image rewardDisplayImage;

    public AudioSource audioSource;
    public AudioClip[] erc20Sounds;

    public Button openButton;
    public Button openingButton;


    void Start()
    {
        var sdk = ThirdwebManager.Instance.SDK;

        openingButton.gameObject.SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public async Task BuyPack()
    {
        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x4a679ba8D23Da3eaa6F0E74851af25ba85dc3198");
            Marketplace marketplace = contract.Marketplace;

            string address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

            Debug.Log("Sending Tx");
            var buyResult = await marketplace.DirectListings.BuyFromListing("3", "1", address);
            Debug.Log("Tx Success");
            GameManager.Instance.ChangeToClosedClaw();
            GameManager.Instance.RaiseClaw();

            StartCoroutine(DisplayOpenCanvas());

        }
        catch (Exception e)
        {
            GameManager.Instance.RaiseClaw();
        }

    }

    public IEnumerator DisplayOpenCanvas()
    {
        yield return new WaitForSeconds(3);
        openPackCanvas.SetActive(true);
    }

    public async Task OpenPack()
    {
        try
        {
            Contract packContract = ThirdwebManager.Instance.SDK.GetContract("0x1A7a20A64f107268dad3C9Af279ACa39FC42853C");
            Pack pack = packContract.Pack;

            //Debug.Log("Opening Pack");
            var result = await pack.Open("2", "1");
            //Debug.Log("Pack Opened");
            Debug.Log(result);


            if (result.erc1155Rewards != null)
            {
                foreach (var reward in result.erc1155Rewards)
                {
                    string tokenId = reward.tokenId;
                    string imagePath = rewardImageManager1155.GetImagePathForReward1155(tokenId);

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        Sprite rewardSprite = Resources.Load<Sprite>(imagePath);
                        if (rewardSprite != null)
                        {
                            rewardDisplayImage.sprite = rewardSprite;
                        }
                        else
                        {
                            Debug.Log($"Failed to load image at path: {imagePath}");
                        }
                    }
                }
            }

            if (result.erc721Rewards != null)
            {
                foreach (var reward in result.erc721Rewards)
                {
                    string tokenId = reward.tokenId;
                    string imagePath = rewardImageManager721.GetImagePathForReward721(tokenId);

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        Sprite rewardSprite = Resources.Load<Sprite>(imagePath);
                        if (rewardSprite != null)
                        {
                            rewardDisplayImage.sprite = rewardSprite;
                        }
                        else
                        {
                            Debug.Log($"Failed to load image at path: {imagePath}");
                        }
                    }
                }
            }

            if (result.erc20Rewards != null)
            {
                foreach (var reward in result.erc20Rewards)
                {
                    string tokenAmount = reward.quantityPerReward;
                    string imagePath = rewardImageManager.GetImagePathForReward(tokenAmount);

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        Sprite rewardSprite = Resources.Load<Sprite>(imagePath);
                        if (rewardSprite != null)
                        {
                            rewardDisplayImage.sprite = rewardSprite;
                        }
                        else
                        {
                            Debug.Log($"Failed to load image at path: {imagePath}");
                        }
                    }
                    //Debug.Log(quantity);
                    //Debug.Log(contractAddress);
                }
            }


            StartCoroutine(DisplayCongratsCanvas());

            //var reward = result;
        }
        catch (Exception e)
        {
            openButton.gameObject.SetActive(true);
            openingButton.gameObject.SetActive(false);
        }
    }

    public IEnumerator DisplayCongratsCanvas()
    {
        yield return new WaitForSeconds(0);
        openButton.gameObject.SetActive(true);
        openingButton.gameObject.SetActive(false);
        openPackCanvas.SetActive(false);
        uiCanvas.SetActive(false);
        bgCanvas.SetActive(false);
        cwCanvas.SetActive(false);
        clawCanvas.SetActive(false);
        congratsCanvas.SetActive(true);
        confetti.SetActive(true);
       

        AudioClip randomSound = erc20Sounds[UnityEngine.Random.Range(0, erc20Sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    public void TurnOffConfetti()
    {
        confetti.SetActive(false);
    }

    public void ChangeOpenButton()
    {
        openButton.gameObject.SetActive(false);
        openingButton.gameObject.SetActive(true);
    }
    
    public void EnableWalletCanvas()
    {
        cwCanvas.SetActive(true);
    }
}