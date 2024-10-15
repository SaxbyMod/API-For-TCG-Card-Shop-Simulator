using I2.Loc;
using System;
using UnityEngine; // For Mathf

[Serializable]
public struct ModdedStats
{
    public int HP;                     // Health Points
    public int Strength;               // Physical strength
    public int Magic;                  // Magical strength
    public int Vitality;               // Vitality points
    public int Spirit;                 // Spirit points
    public int Speed;                  // Speed points

    // Additional level up related properties
    public int HP_LevelAdd;            // HP added per level
    public int Strength_LevelAdd;      // Strength added per level
    public int Magic_LevelAdd;         // Magic added per level
    public int Vitality_LevelAdd;      // Vitality added per level
    public int Spirit_LevelAdd;        // Spirit added per level
    public int Speed_LevelAdd;         // Speed added per level

    // Constructor to initialize Stats with values
    public ModdedStats(int hp, int strength, int magic, int vitality, int spirit, int speed,
                 int hpLevelAdd, int strengthLevelAdd, int magicLevelAdd,
                 int vitalityLevelAdd, int spiritLevelAdd, int speedLevelAdd)
    {
        HP = hp;
        Strength = strength;
        Magic = magic;
        Vitality = vitality;
        Spirit = spirit;
        Speed = speed;

        HP_LevelAdd = hpLevelAdd;
        Strength_LevelAdd = strengthLevelAdd;
        Magic_LevelAdd = magicLevelAdd;
        Vitality_LevelAdd = vitalityLevelAdd;
        Spirit_LevelAdd = spiritLevelAdd;
        Speed_LevelAdd = speedLevelAdd;
    }

    // Method to create a deep copy of stats
    public void DeepCopy(ModdedStats stat)
    {
        this.HP = stat.HP;
        this.Strength = stat.Strength;
        this.Magic = stat.Magic;
        this.Vitality = stat.Vitality;
        this.Spirit = stat.Spirit;
        this.Speed = stat.Speed;
    }

    // Method to calculate the difference between two stats
    public void Difference(ModdedStats stat)
    {
        this.HP -= stat.HP;
        this.Strength -= stat.Strength;
        this.Magic -= stat.Magic;
        this.Vitality -= stat.Vitality;
        this.Spirit -= stat.Spirit;
        this.Speed -= stat.Speed;
    }

    // Method to multiply a stat by a factor (e.g., for level-up)
    public int GetStatMultiplied(int statAmount)
    {
        return Mathf.CeilToInt((float)statAmount * 1.1f);
    }

    // Method to update stats based on the character's level
    public void UpdateStatBasedOnLevel(int level)
    {
        if (level <= 1)
        {
            return;
        }
        for (int i = 0; i < level - 1; i++)
        {
            this.HP = this.GetStatMultiplied(this.HP) + Mathf.CeilToInt((float)this.HP * 0.01f);
            this.Strength = this.GetStatMultiplied(this.Strength);
            this.Magic = this.GetStatMultiplied(this.Magic);
            this.Vitality = this.GetStatMultiplied(this.Vitality);
            this.Spirit = this.GetStatMultiplied(this.Spirit);
            this.Speed = this.GetStatMultiplied(this.Speed);
        }
    }

    // Method to get the name of a stat based on its index
    public string GetStatName(int index)
    {
        string term = "";
        switch (index)
        {
            case 0:
                term = "HP";
                break;
            case 1:
                term = "Strength";
                break;
            case 2:
                term = "Magic";
                break;
            case 3:
                term = "Vitality";
                break;
            case 4:
                term = "Spirit";
                break;
            case 5:
                term = "Speed";
                break;
        }
        return LocalizationManager.GetTranslation(term, true, 0, true, false, null, null, true);
    }

    // Method to get the value of a stat based on its index
    public int GetStatAmount(int index)
    {
        int result = 0;
        switch (index)
        {
            case 0:
                result = this.HP;
                break;
            case 1:
                result = this.Strength;
                break;
            case 2:
                result = this.Magic;
                break;
            case 3:
                result = this.Vitality;
                break;
            case 4:
                result = this.Spirit;
                break;
            case 5:
                result = this.Speed;
                break;
        }
        return result;
    }
}