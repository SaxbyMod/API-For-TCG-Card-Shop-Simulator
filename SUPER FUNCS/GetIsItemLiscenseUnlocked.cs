using System;
using System.Collections.Generic;
using System.Text;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS
{
    internal class GetIsItemLiscenseUnlocked
    {
        public static List<bool> m_IsItemLicenseUnlocked = new List<bool>();
        public static bool GetIsItemLicenseUnlockedFunc(int index)
        {
            return m_IsItemLicenseUnlocked[index];
        }
    }
}
