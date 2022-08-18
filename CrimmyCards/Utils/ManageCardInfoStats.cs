using System;
using System.Collections.Generic;
using System.Text;

namespace CrimmyCards.Utils
{
    public static class ManageCardInfoStats
    {
        public static CardInfoStat BuildCardInfoStat(string statName, bool positive, float? value = null, string explicitValue = "", string signOverride = null)
        {
            if (value == null)
                return new CardInfoStat
                {
                    positive = positive,
                    stat = statName,
                    amount = explicitValue,
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                };

            var isValuePositive = value > 1;
            var valueSign = isValuePositive ? "+" : "-";
            var percentage = (isValuePositive ? value - 1 : 1 - value) * 100;

            if (signOverride != null) valueSign = signOverride;

            return new CardInfoStat
            {
                positive = positive,
                stat = statName,
                amount = $"{valueSign}{percentage:F1}%",
                simepleAmount = CardInfoStat.SimpleAmount.notAssigned
            };
        }
    }
}