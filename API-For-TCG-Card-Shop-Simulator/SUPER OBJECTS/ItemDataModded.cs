using I2.Loc;
using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS
{
    internal class ItemDataModded
    {
        public string name;
        public string category;
        public Sprite icon;
        public float iconScale;
        public float baseCost;
        public float marketPriceMinPercent;
        public float marketPriceMaxPercent;
        public string boxFollowItemPrice;
        public bool isNotBoosterPack;
        public bool isTallItem;
        public bool isHideItemUntilUnlocked;
        public float posYOffsetInBox;
        public float scaleOffsetInBox;
        public Vector3 itemDimension;
        public Vector3 colliderPosOffset;
        public Vector3 colliderScale;
        public List<Dictionary<string, int>> affectedPriceChangeType;

        public string GetName()
        {
            return LocalizationManager.GetTranslation(name);
        }

        public float GetItemVolume()
        {
            if (isTallItem)
            {
                return itemDimension.x * itemDimension.y * itemDimension.z * 2f;
            }

            return itemDimension.x * itemDimension.y * itemDimension.z;
        }
    }
}
