using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardImageManager1155 : MonoBehaviour
{
    [System.Serializable]
    public struct RewardImage1155
    {
        public string tokenId;
        public string imagePath;
    }

    public RewardImage1155[] rewardImages;

    private Dictionary<string, string> rewardImageMap;

    void Awake()
    {
        rewardImageMap = StaticDictionaryData.RewardImageManagerErc1155.Dictionary;

        //rewardImageMap = new Dictionary<string, string>();
        foreach (var rewardImage in rewardImages)
        {
            rewardImageMap[rewardImage.tokenId] = rewardImage.imagePath;
        }
    }

    public string GetImagePathForReward1155(string tokenId)
    {
        if (rewardImageMap.TryGetValue(tokenId, out string imagePath))
        {
            return imagePath;
        }
        return null;
    }

    
}
