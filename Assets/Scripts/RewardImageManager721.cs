using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardImageManager721 : MonoBehaviour
{
    [System.Serializable]
    public struct RewardImage721
    {
        public string tokenId;
        public string imagePath;
    }

    public RewardImage721[] rewardImages;

    private Dictionary<string, string> rewardImageMap;

    void Awake()
    {
        rewardImageMap = StaticDictionaryData.RewardImageManagerErc721.Dictionary;
        
        //rewardImageMap = new Dictionary<string, string>();
        foreach (var rewardImage in rewardImages)
        {
            rewardImageMap[rewardImage.tokenId] = rewardImage.imagePath;
        }
    }

    public string GetImagePathForReward721(string tokenId)
    {
        if (rewardImageMap.TryGetValue(tokenId, out string imagePath))
        {
            return imagePath;
        }
        return null;
    }
}
