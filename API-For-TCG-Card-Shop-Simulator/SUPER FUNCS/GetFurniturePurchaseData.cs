using System;
using System.Collections.Generic;
using System.Linq;
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
            return m_ObjectData_SO.m_FurniturePurchaseDataList.FirstOrDefault(x => x.objectType == objType);

        }
    }
}
