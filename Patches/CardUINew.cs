using API_For_TCG_Card_Shop_Simulator.Helpers.APIObj_s;
using API_For_TCG_Card_Shop_Simulator.Helpers.ENUM_CONVERSIONS;
using I2.Loc;
using UnityEngine;
using HarmonyLib;

namespace API_For_TCG_Card_Shop_Simulator.Patches
{
  public class CardUINew : CardUI
  {
    public ModdedCardData m_ModdedCardData;
    public TetramonCards m_TetramonData;
    public MegabotCards m_MegabotData;
    public FantasyRPGCards m_FantasyRPGData;
    public CatJobCards m_CatJobData;

    public void SetAncientArtifactCardUI(MonsterType.EMonsterTypeLocal ancientCardType)
    {
      this.m_NormalGrp.SetActive(false);
      this.m_FullArtGrp.SetActive(false);
      this.m_AncientArtifactImage.gameObject.SetActive(true);
      this.m_AncientArtifactImage.sprite = InventoryBasePatches.DataHandlers.GetAncientArtifactSpriteTetra(ancientCardType);
    }

    public void SetGhostCardUI(TetramonCards data, bool isBlackGhost)
    {
      this.m_GhostCard.m_MonsterNameText.text = data.GetName();
      this.m_GhostCard.m_Stat1Text.text = data.BaseStats.Strength.ToString();
      this.m_GhostCard.m_Stat2Text.text = data.BaseStats.Vitality.ToString();
      this.m_GhostCard.m_Stat3Text.text = data.BaseStats.Spirit.ToString();
      this.m_GhostCard.m_Stat4Text.text = data.BaseStats.Magic.ToString();
      this.m_GhostCard.m_FameText.text = GetMonsterDataRelatedPatches.GetCardFameAmount(this.m_ModdedCardData).ToString();
      this.m_GhostCard.m_MonsterImage.sprite = data.GetIcon(ECardExpansionType.Ghost);
      this.m_GhostCard.m_MonsterMaskImage.sprite = this.m_GhostCard.m_MonsterImage.sprite;
      this.m_GhostCard.m_FoilGrp.SetActive(this.m_IsFoil);
      this.m_GhostCard.ShowFoilList(this.m_IsFoil);
      this.m_GhostCard.ShowFoilBlendedList(this.m_IsFoil);
      this.m_NormalGrp.SetActive(false);
      this.m_FullArtGrp.SetActive(false);
      this.m_SpecialCardGrp.SetActive(false);
      this.m_GhostCard.gameObject.SetActive(true);
      this.m_AncientArtifactImage.gameObject.SetActive(false);
      if (isBlackGhost)
      {
        this.m_GhostCard.m_NormalGrp.SetActive(false);
        this.m_GhostCard.m_FullArtGrp.SetActive(true);
      }
      else
      {
        this.m_GhostCard.m_NormalGrp.SetActive(true);
        this.m_GhostCard.m_FullArtGrp.SetActive(false);
      }
    }
    public void LoadStreamTextureCompleted(CEventPlayer_LoadStreamTextureCompleted evt)
    {
      if (!(evt.m_FileName == this.m_ModdedCardData.expansionType.ToString() + "_" + this.m_ModdedCardData.tetramonType.ToString()))
        CEventManager.RemoveListener<CEventPlayer_LoadStreamTextureCompleted>(new CEventManager.EventDelegate<CEventPlayer_LoadStreamTextureCompleted>(this.LoadStreamTextureCompleted));
      if (!evt.m_IsSuccess)
        if (this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.Tetramon.ToString() || this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.Ghost.ToString() || this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.Destiny.ToString())
        {
          this.m_MonsterImage.sprite = this.m_TetramonData.GetIcon(this.m_CardData.expansionType);
        }
      if (this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.Megabot.ToString())
      {
        this.m_MonsterImage.sprite = this.m_MegabotData.GetIcon(this.m_CardData.expansionType);
      }
      if (this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.FantasyRPG.ToString())
      {
        this.m_MonsterImage.sprite = this.m_FantasyRPGData.GetIcon(this.m_CardData.expansionType);
      }
      if (this.m_ModdedCardData.expansionType.ToString() == ECardExpansionType.CatJob.ToString())
      {
        this.m_MonsterImage.sprite = this.m_CatJobData.GetIcon(this.m_CardData.expansionType);
      }
    }

    public void SetCardUI(ModdedCardData cardData)
    {
      this.m_ModdedCardData = cardData;
      if (this.m_ModdedCardData.monsterType <= EMonsterType.EarlyPlayer)
      {
        this.m_SpecialCardImage.sprite = InventoryBasePatches.DataHandlers.GetSpecialCardImageTetra(this.m_ModdedCardData.tetramonType);
        this.m_SpecialCardGlowImage.sprite = this.m_SpecialCardImage.sprite;
        this.m_SpecialCardGrp.SetActive(true);
        this.m_NormalGrp.SetActive(false);
        this.m_FullArtGrp.SetActive(false);
        this.m_GhostCard.gameObject.SetActive(false);
        this.m_AncientArtifactImage.gameObject.SetActive(false);
        this.m_FoilGrp.SetActive(true);
        this.ShowFoilList(true);
        this.ShowFoilBlendedList(true);
      }
      else
      {
        this.m_TetramonData = InventoryBasePatches.DataHandlers.GetTetramonData(cardData.tetramonType);
        this.m_CardUISetting = InventoryBase.GetCardUISetting(this.m_CardData.expansionType);
        this.m_MonsterImage.sprite = this.m_TetramonData.GetIcon(this.m_CardData.expansionType);
        if ((Object)this.m_MonsterImage.sprite == (Object)null)
        {
          this.m_MonsterImage.sprite = CSingleton<LoadStreamTexture>.Instance.m_LoadingSprite;
          CEventManager.AddListener<CEventPlayer_LoadStreamTextureCompleted>(new CEventManager.EventDelegate<CEventPlayer_LoadStreamTextureCompleted>(this.LoadStreamTextureCompleted));
        }
        this.m_CardBackImage.sprite = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBackSprite(this.m_CardData.expansionType);
        if (!this.m_IsNestedFullArt)
          this.m_CardFoilMaskImage.sprite = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFoilMaskSprite(this.m_CardData.expansionType);
        this.m_CardBorderType = this.m_CardData.GetCardBorderType();
        this.m_IsDimensionCard = this.m_CardData.isDestiny;
        this.m_IsFoil = this.m_CardData.isFoil;
        this.m_FoilGrp.SetActive(this.m_IsFoil);
        this.ShowFoilList(this.m_IsFoil);
        this.ShowFoilBlendedList(this.m_IsFoil);
        if ((bool)(Object)this.m_ExtraFoil)
        {
          if (this.m_CardBorderType == ECardBorderType.Base || this.m_CardBorderType == ECardBorderType.FirstEdition)
            this.m_ExtraFoil.gameObject.SetActive(false);
          else
            this.m_ExtraFoil.gameObject.SetActive(true);
        }
        this.m_IsChampionCard = this.m_CardData.isChampionCard;
        if (this.m_CardData.expansionType == ECardExpansionType.Destiny)
          this.m_CardBGImage.sprite = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFrontSprite(EElementIndex.Destiny);
        else if (this.m_IsChampionCard)
        {
          this.m_CardBGImage.sprite = CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFrontSprite(EElementIndex.Champion);
          this.m_CardBorderType = ECardBorderType.FullArt;
        }
        else
          this.m_CardBGImage.sprite = this.m_CardData.expansionType != ECardExpansionType.Ghost
            ? CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFrontSprite(this.m_TetramonData.ElementIndex)
            : (!this.m_CardData.isDestiny ? CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFrontSprite(EElementIndex.GhostWhite) : CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardFrontSprite(EElementIndex.GhostBlack));
        this.m_CardBorderImage.sprite = this.m_CardBorderSpriteList[(int)this.m_CardBorderType];
        this.m_RarityImage.sprite = this.m_CardRaritySpriteList[(int)this.m_TetramonData.Rarity];
        this.m_MonsterNameText.text = this.m_TetramonData.GetName();
        int num = (int)((int)(this.m_TetramonData.MonsterType - 1) * CPlayerData.GetCardAmountPerMonsterType(this.m_CardData.expansionType) + this.m_CardBorderType + 1);
        if (this.m_IsFoil)
          num += 6;
        this.m_NumberText.text = num >= 10 ? (num >= 100 ? num.ToString() : "0" + num.ToString()) : "00" + num.ToString();
        if (this.m_IsChampionCard)
        {
          this.m_FameText.gameObject.SetActive(false);
          this.m_DescriptionText.gameObject.SetActive(false);
          this.m_ArtistText.gameObject.SetActive(false);
          this.m_ChampionText.enabled = true;
        }
        else
        {
          this.m_DescriptionText.text = this.m_TetramonData.GetDescription();
          this.m_DescriptionText.gameObject.SetActive(true);
          this.m_ArtistText.text = this.m_TetramonData.GetArtistName();
          this.m_ArtistText.gameObject.SetActive(true);
          if (this.m_TetramonData.PreviousEvolution == MonsterType.EMonsterTypeLocal.None)
          {
            this.m_EvoBasicGrp.SetActive(true);
            this.m_EvoPreviousStageIcon.gameObject.SetActive(false);
            this.m_EvoPreviousStageNameText.gameObject.SetActive(false);
          }
          else
          {
            this.m_EvoBasicGrp.SetActive(false);
            TetramonCards monsterData = InventoryBasePatches.DataHandlers.GetTetramonData(this.m_TetramonData.PreviousEvolution);
            this.m_EvoPreviousStageIcon.sprite = monsterData.GetIcon(this.m_CardData.expansionType);
            this.m_EvoPreviousStageNameText.text = monsterData.GetName();
            this.m_EvoPreviousStageNameText.gameObject.SetActive(true);
            this.m_EvoPreviousStageIcon.gameObject.SetActive(true);
          }
          this.m_ChampionText.enabled = false;
        }
        for (int index = 0; index < this.m_ChampionCardEnableObjectList.Count; ++index)
          this.m_ChampionCardEnableObjectList[index].SetActive(this.m_IsChampionCard);
        this.m_RarityText.text = this.m_TetramonData.GetRarityName();
        this.m_Stat1Text.text = this.m_TetramonData.BaseStats.Strength.ToString();
        this.m_Stat2Text.text = this.m_TetramonData.BaseStats.Vitality.ToString();
        this.m_Stat3Text.text = this.m_TetramonData.BaseStats.Spirit.ToString();
        this.m_Stat4Text.text = this.m_TetramonData.BaseStats.Magic.ToString();
        this.EvaluateCardUISetting();
        if (this.m_IsNestedFullArt)
          return;
        if (this.m_CardBorderType == ECardBorderType.Base || this.m_CardBorderType == ECardBorderType.FullArt)
        {
          this.m_FirstEditionText.enabled = false;
        }
        else
        {
          if (this.m_CardBorderType == ECardBorderType.FirstEdition)
            this.m_FirstEditionText.text = LocalizationManager.GetTranslation("1st Edition");
          else if (this.m_CardBorderType == ECardBorderType.Silver)
            this.m_FirstEditionText.text = LocalizationManager.GetTranslation("Silver Edition");
          else if (this.m_CardBorderType == ECardBorderType.Gold)
            this.m_FirstEditionText.text = LocalizationManager.GetTranslation("Gold Edition");
          else if (this.m_CardBorderType == ECardBorderType.EX)
            this.m_FirstEditionText.text = "EX";
          this.m_FirstEditionText.enabled = true;
        }
        if (this.m_CardData.expansionType == ECardExpansionType.Ghost && this.m_CardBorderType == ECardBorderType.FullArt)
          this.SetGhostCardUI(this.m_TetramonData, this.m_CardData.isDestiny);
        else if (this.m_CardBorderType == ECardBorderType.FullArt && (bool)(Object)this.m_FullArtCard)
        {
          this.m_FullArtCard.MarkAsNestedFullArt(true);
          this.m_FullArtCard.SetCardUI(this.m_CardData);
          this.m_FullArtCard.m_MonsterMaskImage.sprite = this.m_FullArtCard.m_MonsterImage.sprite;
          this.m_FullArtBGImage.sprite = this.m_CardData.expansionType != ECardExpansionType.Destiny
            ? (!this.m_IsChampionCard
              ? (this.m_CardData.expansionType != ECardExpansionType.Ghost ? CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBGSprite(this.m_MonsterData.ElementIndex) : (!this.m_CardData.isDestiny ? CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBGSprite(EElementIndex.GhostWhite) : CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBGSprite(EElementIndex.GhostBlack)))
              : CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBGSprite(EElementIndex.Champion))
            : CSingleton<InventoryBase>.Instance.m_MonsterData_SO.GetCardBGSprite(EElementIndex.Destiny);
          this.m_FullArtCard.m_FoilGrp.SetActive(this.m_IsFoil);
          this.m_FullArtCard.ShowFoilList(this.m_IsFoil);
          this.m_FullArtCard.ShowFoilBlendedList(this.m_IsFoil);
          this.m_FullArtCard.m_FameText.text = this.m_FameText.text;
          this.m_FullArtCard.m_DescriptionText.text = this.m_DescriptionText.text;
          this.m_FullArtCard.m_ArtistText.text = this.m_ArtistText.text;
          this.m_FullArtCard.m_ArtistText.gameObject.SetActive(this.m_ArtistText.gameObject.activeSelf);
          if (this.m_TetramonData.PreviousEvolution == MonsterType.EMonsterTypeLocal.None)
          {
            this.m_FullArtCard.m_EvoBasicGrp.SetActive(true);
            this.m_FullArtCard.m_EvoPreviousStageNameText.gameObject.SetActive(false);
            this.m_FullArtCard.m_EvoPreviousStageIcon.gameObject.SetActive(false);
          }
          else
          {
            this.m_FullArtCard.m_EvoBasicGrp.SetActive(false);
            TetramonCards monsterData = InventoryBasePatches.DataHandlers.GetTetramonData(this.m_TetramonData.PreviousEvolution);
            this.m_FullArtCard.m_EvoPreviousStageIcon.sprite = monsterData.GetIcon(this.m_CardData.expansionType);
            this.m_FullArtCard.m_EvoPreviousStageNameText.text = monsterData.GetName();
            this.m_FullArtCard.m_EvoPreviousStageNameText.gameObject.SetActive(true);
            this.m_FullArtCard.m_EvoPreviousStageIcon.gameObject.SetActive(true);
          }
          this.m_NormalGrp.SetActive(false);
          this.m_FullArtGrp.SetActive(true);
          this.m_SpecialCardGrp.SetActive(false);
          this.m_GhostCard.gameObject.SetActive(false);
          this.m_AncientArtifactImage.gameObject.SetActive(false);
        }
        else
        {
          this.m_NormalGrp.SetActive(true);
          this.m_FullArtGrp.SetActive(false);
          this.m_SpecialCardGrp.SetActive(false);
          this.m_GhostCard.gameObject.SetActive(false);
          this.m_AncientArtifactImage.gameObject.SetActive(false);
        }
      }
    }

    public void EvaluateCardUISetting()
    {
      if ((bool)(Object)this.m_MonsterNameText)
      {
        if (this.m_IsNestedFullArt)
          this.m_MonsterNameText.enabled = this.m_CardUISetting.showNameFullArt;
        else
          this.m_MonsterNameText.enabled = this.m_CardUISetting.showName;
      }
      this.m_Stat1Text.enabled = this.m_CardUISetting.showStat1;
      this.m_Stat2Text.enabled = this.m_CardUISetting.showStat2;
      this.m_Stat3Text.enabled = this.m_CardUISetting.showStat3;
      this.m_Stat4Text.enabled = this.m_CardUISetting.showStat4;
      this.m_Stat1Text.transform.localPosition = this.m_CardUISetting.stat1PosOffset;
      this.m_Stat1Text.transform.localScale = Vector3.one + this.m_CardUISetting.stat1ScaleOffset;
      if (this.m_ArtworkImageLocalPos != Vector3.zero)
        this.m_MonsterImage.transform.localPosition = this.m_ArtworkImageLocalPos;
      this.m_ArtworkImageLocalPos = this.m_MonsterImage.transform.localPosition;
      if (!this.m_IsNestedFullArt)
      {
        if (!this.m_CardUISetting.showEdition && this.m_FirstEditionText.enabled)
          this.m_FirstEditionText.enabled = false;
        this.m_RarityImage.enabled = this.m_CardUISetting.showRarity;
        this.m_RarityText.enabled = this.m_CardUISetting.showRarity;
        this.m_NumberText.enabled = this.m_CardUISetting.showNumber;
        this.m_NumberText.transform.localPosition = this.m_CardUISetting.numberPosOffset;
        this.m_FirstEditionText.transform.localPosition = this.m_CardUISetting.editionPosOffset;
        this.m_MonsterMask.transform.localPosition = this.m_CardUISetting.monsterImagePosOffset;
        this.m_MonsterMask.transform.localScale = Vector3.one + this.m_CardUISetting.monsterImageScaleOffset;
        this.m_MonsterImage.transform.localPosition = this.m_ArtworkImageLocalPos + this.m_CardUISetting.artworkImagePosOffset;
        this.m_MonsterImage.transform.localScale = Vector3.one + -this.m_CardUISetting.monsterImageScaleOffset;
        this.m_MonsterMaskImage.transform.localPosition = this.m_MonsterImage.transform.localPosition;
        this.m_MonsterMaskImage.transform.localScale = this.m_MonsterImage.transform.localScale;
        this.m_MonsterGlowMask.transform.localPosition = this.m_CardUISetting.monsterImagePosOffset;
        this.m_MonsterGlowMask.transform.localScale = this.m_MonsterMask.transform.localScale;
        this.m_FameText.transform.localPosition = this.m_CardUISetting.famePosOffset;
        this.m_FameText.transform.localScale = Vector3.one + this.m_CardUISetting.fameScaleOffset;
        this.m_MonsterNameText.transform.localPosition = this.m_CardUISetting.namePosOffset;
      }
      else
      {
        this.m_Stat1Text.enabled = this.m_CardUISetting.fullArtShowStat1;
        this.m_MonsterMask.transform.localPosition = this.m_CardUISetting.fullArtMonsterImagePosOffset;
        this.m_MonsterMask.transform.localScale = Vector3.one + this.m_CardUISetting.fullArtMonsterImageScaleOffset;
        this.m_MonsterGlowMask.transform.localPosition = this.m_CardUISetting.fullArtMonsterImagePosOffset;
        this.m_MonsterGlowMask.transform.localScale = this.m_MonsterMask.transform.localScale;
        this.m_FullArtBGImageMask.transform.localScale = this.m_MonsterMask.transform.localScale;
        this.m_FullArtBGImageMask.transform.localScale = this.m_MonsterMask.transform.localScale + this.m_CardUISetting.fullArtBGMaskScaleOffset;
        this.m_MonsterMask.sprite = this.m_CardBGImage.sprite;
        this.m_MonsterImage.transform.localPosition = this.m_ArtworkImageLocalPos + this.m_CardUISetting.fullArtArtworkImagePosOffset;
        this.m_MonsterMaskImage.transform.localPosition = this.m_MonsterImage.transform.localPosition;
        this.m_MonsterMaskImage.transform.localScale = this.m_MonsterImage.transform.localScale;
        this.m_CardFoilMaskImage.sprite = this.m_CardBGImage.sprite;
        this.m_FullArtBGImageMask.sprite = this.m_CardBGImage.sprite;
        this.m_MonsterGlowMask.sprite = this.m_CardBGImage.sprite;
        this.m_FameText.transform.localPosition = this.m_CardUISetting.fullArtFamePosOffset;
        this.m_FameText.transform.localScale = Vector3.one + this.m_CardUISetting.fullArtFameScaleOffset;
        this.m_MonsterNameText.transform.localPosition = this.m_CardUISetting.fullArtNamePosOffset;
      }
    }

    public ModdedCardData GetCardData() => this.m_ModdedCardData;
  }
}