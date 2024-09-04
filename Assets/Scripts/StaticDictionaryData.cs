using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDictionaryData
{
    public static class RewardImageManagerErc20
    {
        public static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>
        {
            {"1000.0", "1000ticketsPrize-export"},
            {"2500.0", "2500ticketsPrize-export"},
            {"3333.0", "3333ticketsPrize-export"},
            {"5000.0", "5000ticketsPrize-export"},
            {"10000.0", "10000ticketsPrize-export"},
            {"20000.0", "20000ticketsPrize-export"},
            {"33333.0", "33333ticketsPrize-export"},
            {"50000.0", "50000ticketsPrize-export"},
            {"75000.0", "75000ticketsPrize-export"},
            {"100000.0", "100000ticketsPrize-export"},
            {"250000.0", "250000ticketsPrize-export"},
            {"1000000.0", "1000000ticketsPrize-export"}
        };
    }

    public static class RewardImageManagerErc1155
    {
        public static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>
        {
            {"1", "OGtokenPrize-export"},
            {"0", "WLtokenPrize-export"}
        };
    }

    public static class RewardImageManagerErc721
    {
        public static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>
        {
            {"775", "efrog775"},
            {"9370", "efroglet9370"},
            {"3330", "efroglet3330"},
            {"3331", "efroglet3331"},
            {"3332", "efroglet3332"},
            {"3509", "efroglet3509"}

        };
    }
}
