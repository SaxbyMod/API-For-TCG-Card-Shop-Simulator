using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS;
using API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects;
using HarmonyLib;
using I2.Loc;
using UnityEngine;

// Token: 0x0200003B RID: 59
namespace API_For_TCG_Card_Shop_Simulator.SUPER_FUNCS.Patches
{
    [HarmonyPatch]
    public class InventoryBase : CSingleton<InventoryBase>
    {
        public StockItemDataModded m_StockItemData_SO;
        public MonsterDataModded m_MonsterData_SO;
        public ShelfData_ScriptableObjectModded m_ObjectData_SO;
        public TextModded m_TextSO;
        public static InventoryBase m_Instance;

        // Token: 0x060002EA RID: 746 RVA: 0x0001C5E3 File Offset: 0x0001A7E3
        public static CardUISetting GetCardUISetting(ECardExpansionType expansionType)
        {
            return CSingleton<InventoryBase>.Instance.m_MonsterData_SO.m_CardUISettingList[(int)expansionType];
        }

        // Token: 0x060002EB RID: 747 RVA: 0x0001C5FC File Offset: 0x0001A7FC
        public static ECardExpansionType GetCardExpansionType(ECollectionPackType collectionPackType)
        {
            if (collectionPackType is ECollectionPackType.BasicCardPack or ECollectionPackType.RareCardPack or ECollectionPackType.EpicCardPack or ECollectionPackType.LegendaryCardPack)
            {
                return ECardExpansionType.Tetramon;
            }
            if (collectionPackType is ECollectionPackType.DestinyBasicCardPack or ECollectionPackType.DestinyRareCardPack or ECollectionPackType.DestinyEpicCardPack or ECollectionPackType.DestinyLegendaryCardPack)
            {
                return ECardExpansionType.Destiny;
            }
            if (collectionPackType == ECollectionPackType.GhostPack)
            {
                return ECardExpansionType.Ghost;
            }
            if (collectionPackType == ECollectionPackType.MegabotPack)
            {
                return ECardExpansionType.Megabot;
            }
            if (collectionPackType == ECollectionPackType.FantasyRPGPack)
            {
                return ECardExpansionType.FantasyRPG;
            }
            if (collectionPackType == ECollectionPackType.CatJobPack)
            {
                return ECardExpansionType.CatJob;
            }
            return ECardExpansionType.None;
        }

        // Token: 0x060002EC RID: 748 RVA: 0x0001C648 File Offset: 0x0001A848
        public static ECollectionPackType ItemTypeToCollectionPackType(EItemType itemType)
        {
            if (itemType is EItemType.BasicCardPack or EItemType.BasicCardBox)
            {
                return ECollectionPackType.BasicCardPack;
            }
            if (itemType is EItemType.RareCardPack or EItemType.RareCardBox)
            {
                return ECollectionPackType.RareCardPack;
            }
            if (itemType is EItemType.EpicCardPack or EItemType.EpicCardBox)
            {
                return ECollectionPackType.EpicCardPack;
            }
            if (itemType is EItemType.LegendaryCardPack or EItemType.LegendaryCardBox)
            {
                return ECollectionPackType.LegendaryCardPack;
            }
            if (itemType is EItemType.DestinyBasicCardPack or EItemType.DestinyBasicCardBox)
            {
                return ECollectionPackType.DestinyBasicCardPack;
            }
            if (itemType is EItemType.DestinyRareCardPack or EItemType.DestinyRareCardBox)
            {
                return ECollectionPackType.DestinyRareCardPack;
            }
            if (itemType is EItemType.DestinyEpicCardPack or EItemType.DestinyEpicCardBox)
            {
                return ECollectionPackType.DestinyEpicCardPack;
            }
            if (itemType is EItemType.DestinyLegendaryCardPack or EItemType.DestinyLegendaryCardBox)
            {
                return ECollectionPackType.DestinyLegendaryCardPack;
            }
            if (itemType == EItemType.GhostPack)
            {
                return ECollectionPackType.GhostPack;
            }
            if (itemType == EItemType.MegabotPack)
            {
                return ECollectionPackType.MegabotPack;
            }
            if (itemType == EItemType.FantasyRPGPack)
            {
                return ECollectionPackType.FantasyRPGPack;
            }
            if (itemType == EItemType.CatJobPack)
            {
                return ECollectionPackType.CatJobPack;
            }
            return ECollectionPackType.None;
        }

        // Token: 0x060002ED RID: 749 RVA: 0x0001C6CC File Offset: 0x0001A8CC
        public static string GetPriceChangeTypeText(EPriceChangeType priceChangeType, bool isIncrease)
        {
            for (int i = 0; i < CSingleton<InventoryBase>.Instance.m_TextSO.m_PriceChangeTypeTextList.Count; i++)
            {
                if (CSingleton<InventoryBase>.Instance.m_TextSO.m_PriceChangeTypeTextList[i].priceChangeType == priceChangeType)
                {
                    return CSingleton<InventoryBase>.Instance.m_TextSO.m_PriceChangeTypeTextList[i].GetName(isIncrease);
                }
            }
            return LocalizationManager.GetTranslation("No effect on card pack price.", true, 0, true, false, null, null, true);
        }

        // Token: 0x060002EE RID: 750 RVA: 0x0001C742 File Offset: 0x0001A942
        public static string GetCardExpansionName(ECardExpansionType cardExpansion)
        {
            return LocalizationManager.GetTranslation(CSingleton<InventoryBase>.Instance.m_TextSO.m_CardExpansionNameList[(int)cardExpansion], true, 0, true, false, null, null, true);
        }

        // Token: 0x060002EF RID: 751 RVA: 0x0001C765 File Offset: 0x0001A965
        public static Material GetCurrencyMaterial(EMoneyCurrencyType currencyType)
        {
            return CSingleton<InventoryBase>.Instance.m_TextSO.m_CurrencyMaterialList[(int)currencyType];
        }

        // Token: 0x060002F0 RID: 752 RVA: 0x0001C77C File Offset: 0x0001A97C
        public static Sprite GetQuestionMarkSprite()
        {
            return CSingleton<InventoryBase>.Instance.m_TextSO.m_QuestionMarkImage;
        }
    }
}