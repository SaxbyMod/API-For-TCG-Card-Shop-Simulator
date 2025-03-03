using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS
{
    internal class GetRestockDataIndex
    {
        public static StockItemDataModded m_StockItemData_SO;
        public static MonsterDataModded m_MonsterData_SO;
        public static ShelfData_ScriptableObjectModded m_ObjectData_SO;
        public static TextModded m_TextSO;
        public static InventoryBase m_Instance;

        public static int GetRestockDataIndexFunc(string itemType)
        {
            for (int i = 0; i < m_StockItemData_SO.m_RestockDataList.Count; i++)
            {
                if (m_StockItemData_SO.m_RestockDataList[i].itemType == itemType)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
