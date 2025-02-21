using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS
{
    internal class TextModded : ScriptableObject
    {
        public List<string> m_RandomName1;
        public List<string> m_RandomName2;
        public List<string> m_RandomName3;
        public List<string> m_CardExpansionNameList;
        public List<Material> m_CurrencyMaterialList;
        public List<PriceChangeTypeTextModded> m_PriceChangeTypeTextList;
        public List<CustomerReviewTextDataTableModded> m_CustomerReviewTextDataTableList;
        public List<Sprite> m_GamepadCtrlBtnSpriteList;
        public List<Sprite> m_XBoxCtrlBtnSpriteList;
        public List<Sprite> m_PSCtrlBtnSpriteList;
        public Sprite m_KeyboardBtnImage;
        public Sprite m_LeftMouseClickImage;
        public Sprite m_RightMouseClickImage;
        public Sprite m_LeftMouseHoldImage;
        public Sprite m_RightMouseHoldImage;
        public Sprite m_MiddleMouseScrollImage;
        public Sprite m_EnterImage;
        public Sprite m_SpacebarImage;
        public Sprite m_TabImage;
        public Sprite m_ShiftImage;
        public Sprite m_QuestionMarkImage;

        public string GetRandomName()
        {
            int num = Mathf.Clamp(UnityEngine.Random.Range(-4, 4), 1, 3);
            int num2 = UnityEngine.Random.Range(0, 100);
            int num3 = UnityEngine.Random.Range(0, 100);
            List<string> RandomName = m_RandomName1;
            List<string> list = new();
            List<string> list2 = new();
            List<string> list3 = new();
            string text = "";
            string text2 = "";
            if (num >= 1)
            {
                list = (UnityEngine.Random.Range(0, 2) != 0) ? m_RandomName3 : m_RandomName2;
            }

            if (num >= 2)
            {
                list2 = (UnityEngine.Random.Range(0, 2) != 0) ? m_RandomName3 : m_RandomName2;
            }

            if (num >= 3)
            {
                list3 = (UnityEngine.Random.Range(0, 2) != 0) ? m_RandomName3 : m_RandomName2;
            }

            if (num2 < 15)
            {
                text = UnityEngine.Random.Range(0, 10000).ToString();
            }

            if (num3 < 15)
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    int index = UnityEngine.Random.Range(0, m_RandomName2.Count);
                    text2 = m_RandomName2[index];
                }
                else
                {
                    int index2 = UnityEngine.Random.Range(0, m_RandomName3.Count);
                    text2 = m_RandomName3[index2];
                }
            }

            int index3 = UnityEngine.Random.Range(0, RandomName.Count);
            int index4 = UnityEngine.Random.Range(0, list.Count);
            int index5 = UnityEngine.Random.Range(0, list2.Count);
            int index6 = UnityEngine.Random.Range(0, list3.Count);
            string text3 = text2;
            if (RandomName.Count > 0)
            {
                text3 += RandomName[index3];
            }

            if (list.Count > 0)
            {
                text3 += list[index4];
            }

            if (list2.Count > 0)
            {
                text3 += list2[index5];
            }

            if (list3.Count > 0)
            {
                text3 += list3[index6];
            }

            if (text != "")
            {
                text3 += text;
            }

            if (!char.IsUpper(text3[0]) && UnityEngine.Random.Range(0, 100) < 30)
            {
                text3 = char.ToUpper(text3[0]) + text3.Substring(1);
            }

            return text3;
        }
    }
}
