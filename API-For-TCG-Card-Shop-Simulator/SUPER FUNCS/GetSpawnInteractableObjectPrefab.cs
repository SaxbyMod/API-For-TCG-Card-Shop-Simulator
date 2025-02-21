using System;
using System.Collections.Generic;
using System.Text;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS
{
    internal class GetSpawnInteractableObjectPrefab
    {
        public static ShelfData_ScriptableObjectModded m_ObjectData_SO;

        public static InteractableObjectModded GetSpawnInteractableObjectPrefabFunc(string objType)
        {
            for (int i = 0; i < CSingleton<InventoryBase>.Instance.m_ObjectData_SO.m_ObjectDataList.Count; i++)
            {
                if (m_ObjectData_SO.m_ObjectDataList[i].objectType == objType)
                {
                    return m_ObjectData_SO.m_ObjectDataList[i].spawnPrefab;
                }
            }
            return null;
        }
    }
}