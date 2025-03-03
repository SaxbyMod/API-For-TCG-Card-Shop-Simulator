using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS
{
    internal class GetRestockDataUsingItemType
    {
        public static StockItemDataModded m_StockItemData_SO;
        public static MonsterDataModded m_MonsterData_SO;
        public static ShelfData_ScriptableObjectModded m_ObjectData_SO;
        public static TextModded m_TextSO;
        public static InventoryBase m_Instance;

        public static List<RestockDataModded> GetRestockDataUsingItemTypeFunch(string itemType)
        {
            return m_StockItemData_SO.m_RestockDataList
                .Where(x => x.itemType == itemType)
                .ToList();
        }
    }
}
