using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardImageManager : MonoBehaviour
{
    [System.Serializable]
    public struct RewardImage
    {
        public string tokenAmount;
        public string imagePath;
    }

    public RewardImage[] rewardImages;

    private Dictionary<string, string> rewardImageMap;

    void Awake()
    {
        rewardImageMap = StaticDictionaryData.RewardImageManagerErc20.Dictionary;

        //rewardImageMap = new Dictionary<string, string>();
        foreach (var rewardImage in rewardImages)
        {
            rewardImageMap[rewardImage.tokenAmount] = rewardImage.imagePath;
        }
    }

    public string GetImagePathForReward(string tokenAmount)
    {
        if (rewardImageMap.TryGetValue(tokenAmount, out string imagePath))
        {
            return imagePath;
        }
        return null;
    }

    
}
