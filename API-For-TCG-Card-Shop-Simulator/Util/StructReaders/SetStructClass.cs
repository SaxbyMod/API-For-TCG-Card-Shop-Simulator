using BepInEx;
using API.Helpers.NodeHelpers;
using API.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Util.StructReaders
{
    public static class SetStructClass
    {
        public static List<FinalSetData> ReadCardStruct()
        {
            List<FinalSetData> sets = new List<FinalSetData>();

            string path = API.Plugin.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";

            if (!File.Exists(path))
                return sets;

            string[] file = File.ReadAllLines(path);

            // This will parse the apidat file for the tree.
            List<Node> Tree = ParseClass.Parse(file);

            // Delve into Sets Nodes
            string[] setNodes = GetNodesClass.GetNodes(Tree, "Sets");

            foreach (string item in setNodes)
            {
                // Delve into the unique Set Nodes
                string[] setInformationNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}");

                // Create the base Set Information
                string SetName = item.Replace("\"", "");
                string SetDescription = "";
                List<FinalCardData> cards = new List<FinalCardData>();

                // Delve into the Set
                foreach (string subItem in setInformationNodes)
                {
                    // Each of these are going to be roughly the same but these check the item and set the item to the tree path at value 0 from the GetNodes
                    if (subItem == "Description")
                    {
                        SetDescription = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}")[0];
                    }
                    if (subItem == "CardsList")
                    {
                        // Delve into the Card Nodes
                        string[] CardsList = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}");
                        foreach (string cardItem in CardsList)
                        {
                            // Create the base Card Information
                            List<string> roles = new List<string>();
                            List<string> skills = new List<string>();
                            string CardName = "";
                            string artist = "";
                            string description = "";
                            List<int> effectAmount = new List<int>();
                            string element = "None";
                            string rarity = "None";
                            string nextForm = "";
                            string previousForm = "";
                            List<int> baseStats = new List<int>();
                            List<int> modifierStats = new List<int>();
                            string IconPath = "";
                            string GhostIconPath = "";

                            // Delve into the unique Card Nodes
                            string[] cardInformationNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}");
                            CardName = cardItem.Replace("\"", "").Split('|')[1];
                            foreach (string subCard in cardInformationNodes)
                            {
                                if (subCard == "Roles")
                                {
                                    // Delve into the Role Nodes
                                    string[] roleNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string roleNode in roleNodes)
                                    {
                                        roles.Add(roleNode);
                                    }
                                }

                                if (subCard == "Skills")
                                {
                                    // Delve into the Skill Nodes
                                    string[] skillNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string skillNode in skillNodes)
                                    {
                                        skills.Add(skillNode);
                                    }
                                }

                                if (subCard == "Artist")
                                {
                                    artist = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "Description")
                                {
                                    description = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "EffectAmount")
                                {
                                    string[] effectNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    effectAmount.Add(int.Parse(effectNodes[0]));
                                    effectAmount.Add(int.Parse(effectNodes[1]));
                                    effectAmount.Add(int.Parse(effectNodes[2]));
                                }

                                if (subCard == "Element")
                                {
                                    element = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "Rarity")
                                {
                                    rarity = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "NextForm")
                                {
                                    nextForm = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0].IsNullOrWhiteSpace() ? "None" : GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "PreviousForm")
                                {
                                    previousForm = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0].IsNullOrWhiteSpace() ? "None" : GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "Stats")
                                {
                                    // Delve into the Stat Nodes
                                    string[] statNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string statType in statNodes)
                                    {
                                        if (statType == "BaseStats")
                                        {
                                            // Delve into the Base Stat Nodes
                                            string[] baseNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}/{statType}");
                                            foreach (string baseNode in baseNodes)
                                            {
                                                baseStats.Add(int.Parse(baseNode));
                                            }
                                        }
                                        if (statType == "ModifiedStats")
                                        {
                                            // Delve into the Modified Stat  Nodes
                                            string[] modifiedNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}/{statType}");
                                            foreach (string modifiedNode in modifiedNodes)
                                            {
                                                modifierStats.Add(int.Parse(modifiedNode));
                                            }
                                        }
                                    }
                                }

                                if (subCard == "IconPath")
                                {
                                    IconPath = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }

                                if (subCard == "GhostIconPath")
                                {
                                    GhostIconPath = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }
                            }

                            FinalCardData card = new FinalCardData(
                                CardName,
                                artist,
                                description,
                                rarity,
                                element,
                                effectAmount,
                                nextForm,
                                previousForm,
                                roles,
                                skills,
                                baseStats,
                                modifierStats,
                                IconPath,
                                GhostIconPath
                            );
                            cards.Add(card);
                        }
                    }
                }
                FinalSetData set = new FinalSetData(SetName, SetDescription, cards);
                sets.Add(set);
            }

            // Verbose Logger
            foreach (FinalSetData set in sets)
            {
                Console.WriteLine($"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"Found set called; {set.SetName}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- CONTENT -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"{set.SetDescription}");
                Console.WriteLine($"CardList");
                Console.WriteLine("|");
                foreach (FinalCardData card in set.Cards)
                {
                    Console.WriteLine($"|--> {card.CardName}");
                    Console.WriteLine($"     ");
                    Console.WriteLine($"|-------> Card Description: {card.Description.Replace("XXX", card.EffectAmount[0].ToString()).Replace("YYY", card.EffectAmount[1].ToString()).Replace("ZZZ", card.EffectAmount[2].ToString())}");
                    Console.WriteLine($"|-------> Card Artist: {card.ArtistName}");
                    Console.WriteLine($"|-------> Card Element: {card.Element}");
                    Console.WriteLine($"|-------> Card Rarity: {card.Rarity}");
                    Console.WriteLine($"|-------> Card's Next Form: {card.Next}");
                    Console.WriteLine($"|-------> Card's Previous Form: {card.Previous}");
                    Console.WriteLine($"|-------> Card Roles:");
                    foreach (EMonsterRole role in card.Roles)
                    {
                        Console.WriteLine($"|------------> {role}");
                    }
                    Console.WriteLine("|-------> Card Skills:");
                    foreach (ESkill skill in card.Skills)
                    {
                        Console.WriteLine($"|------------> {skill}");
                    }
                    Console.WriteLine("|-------> Card Stats:");
                    Console.WriteLine($"|------------> HP; {card.CardStats.HP.ToString()}");
                    Console.WriteLine($"|------------> HP: Modifier; {card.CardStats.HP_LevelAdd.ToString()}");
                    Console.WriteLine($"|------------> Strength; {card.CardStats.Strength.ToString()}");
                    Console.WriteLine($"|------------> Strength: Modifier; {card.CardStats.Strength_LevelAdd.ToString()}");
                    Console.WriteLine($"|------------> Magic; {card.CardStats.Magic.ToString()}");
                    Console.WriteLine($"|------------> Magic: Modifier; {card.CardStats.Magic_LevelAdd.ToString()}");
                    Console.WriteLine($"|------------> Vitality; {card.CardStats.Vitality.ToString()}");
                    Console.WriteLine($"|------------> Vitality: Modifier; {card.CardStats.Vitality_LevelAdd.ToString()}");
                    Console.WriteLine($"|------------> Spirit; {card.CardStats.Spirit.ToString()}");
                    Console.WriteLine($"|------------> Spirit: Modifier; {card.CardStats.Spirit_LevelAdd.ToString()}");
                    Console.WriteLine($"|------------> Speed; {card.CardStats.Speed.ToString()}");
                    Console.WriteLine($"|------------> Speed: Modifier; {card.CardStats.Speed_LevelAdd.ToString()}");
                    Console.WriteLine($"|-------> Card's Icon Path: {card.IconPath}");
                    Console.WriteLine($"|-------> Card's Ghost Icon Path: {card.GhostIconPath}");
                }
            }

            return sets;
        }
    }
}