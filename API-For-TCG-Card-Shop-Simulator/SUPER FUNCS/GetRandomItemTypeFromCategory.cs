using API_For_TCG_Card_Shop_Simulator.Helpers;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS
{
    internal class GetRandomItemTypeFromCategory
    {
        public static StockItemDataModded m_StockItemData_SO;
        public static MonsterDataModded m_MonsterData_SO;
        public static ShelfData_ScriptableObjectModded m_ObjectData_SO;
        public static TextModded m_TextSO;
        public static InventoryBase m_Instance;

        public static string GetRandomItemTypeFromCategoryFunc(string category, bool unlockedOnly)
        {
            Dictionary<int,string> list = new();
            for (int i = 0; i < CSingleton<InventoryBase>.Instance.m_StockItemData_SO.m_ItemDataList.Count; i++)
            {
                if (m_StockItemData_SO.m_ItemDataList[i].category == category)
                {
                    if (unlockedOnly)
                    {
                        List<RestockDataModded> output = GetRestockDataUsingItemType.GetRestockDataUsingItemTypeFunch(category);
                        RestockDataModded newoutput = output[i];
                        if (GetIsItemLiscenseUnlocked.GetIsItemLicenseUnlockedFunc(EnumListScript.ItemType[newoutput.name]))
                        {
                            list.Add(i, newoutput.name);
                        }
                    }
                }
            }
            int count = 0;
            if (list.Any())
            {
                count = list.Count;
            }
            var newitem = UnityEngine.Random.RandomRange(0, count);
            return list[newitem];
        }
    }
}
