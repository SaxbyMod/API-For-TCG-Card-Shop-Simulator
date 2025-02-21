using System;
using System.Collections.Generic;
using System.Text;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Functions
{
    internal class GetFurniturePurchaseData
    {
        public static ShelfData_ScriptableObjectModded m_ObjectData_SO;

        public static FurniturePurchaseDataModded GetFurniturePurchaseDataIndex(int index)
        {
            return m_ObjectData_SO.m_FurniturePurchaseDataList[index];
        }

        public static FurniturePurchaseDataModded GetFurniturePurchaseDataObjectType(string objType)
        {
            for (int i = 0; i < m_ObjectData_SO.m_ObjectDataList.Count; i++)
            {
                if (m_ObjectData_SO.m_FurniturePurchaseDataList[i].objectType == objType)
                {
                    return m_ObjectData_SO.m_FurniturePurchaseDataList[i];
                }
            }
            return null;
        }
    }
}
