using System.Collections.Generic;
using UnityEngine;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS
{
    internal class StockItemDataModded : ScriptableObject
    {
        public List<Dictionary<string, int>> m_ShownAllItemType;
        public List<Dictionary<string, int>> m_ShownItemType;
        public List<Dictionary<string, int>> m_ShownAccessoryItemType;
        public List<Dictionary<string, int>> m_ShownFigurineItemType;
        public List<Dictionary<string, int>> m_ShownBoardGameItemType;
        public List<Dictionary<string, int>> m_ShownCollectionPackType;
        public List<Dictionary<string, int>> m_ShownCardExpansionType;
        public List<ItemDataModded> m_ItemDataList;
        public List<ItemMeshData> m_ItemMeshDataList;
        public List<RestockDataModded> m_RestockDataList;
        public List<GameEventDataModded> m_GameEventDataList;
        public List<CollectionPackImageSpriteModded> m_CollectionPackImageSpriteList;
        public float m_ShelfUnlockCostMultiplier;
        public float m_ShelfUpgradeCostMultiplier;
        public List<Dictionary<string, int>> m_IdealQuestSequenceList;
        public List<Sprite> m_AncientArtifactSpriteList;
    }
}
