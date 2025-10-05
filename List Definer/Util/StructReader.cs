using BepInEx;
using List_Definer.Helpers.NodeHelpers;
using List_Definer.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace List_Definer.Util
{
    public class StructReader
    {
        public static List<MiddleSetData> ReadCardStruct()
        {
            List<MiddleSetData> sets =  new List<MiddleSetData>();
            
            string path = ListDefinerBase.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";

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
                List<MiddleCardData> cards = new List<MiddleCardData>();

                // Delve into the Set
                foreach (string subItem in setInformationNodes)
                {
                    // Each of these are going to be roughly the same but these check the item and set the item to the tree path at value 0 from the GetNodes
                    if (subItem == "Description")
                    {
                        SetDescription = GetNodesClass.GetNodes(Tree,  $"Sets/{item}/{subItem}")[0];
                    }
                    if (subItem == "CardsList")
                    {
                        // Delve into the Card Nodes
                        string[] CardsList = GetNodesClass.GetNodes(Tree,  $"Sets/{item}/{subItem}");
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
                                                baseStats.Add(int.Parse(modifiedNode));
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
                            
                            MiddleCardData card = new MiddleCardData(
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
                MiddleSetData set = new MiddleSetData(SetName, SetDescription, cards);
                sets.Add(set);
            }
            
            return sets;
        }
    }
}