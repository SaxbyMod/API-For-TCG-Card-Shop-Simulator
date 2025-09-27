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
                string SetName = setInformationNodes[0].Replace("\"", "");
                string SetDescription = "";
                List<MiddleCardData> cards = new List<MiddleCardData>();
                Console.WriteLine(item);

                // Delve into the Set
                foreach (string subItem in setInformationNodes)
                {
                    Console.WriteLine("|--" + subItem);
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
                            Console.WriteLine("|----" + cardItem);
                            List<EMonsterRole> roles = new List<EMonsterRole>();
                            List<ESkill> skills = new List<ESkill>();
                            string CardName = "";
                            string artist = "";
                            string description = "";
                            Vector3 effectAmount = new Vector3();
                            EElementIndex element = EElementIndex.None;
                            ERarity rarity = ERarity.None;
                            string nextForm = "";
                            string previousForm = "";
                            List<int> baseStats = new List<int>();
                            List<int> modifierStats = new List<int>();
                            string IconPath = "";
                            string GhostIconPath = "";
                            
                            // Delve into the unique Card Nodes
                            string[] cardInformationNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}");
                            CardName = cardInformationNodes[0].Replace("\"", "").Split('|')[1];
                            foreach (string subCard in cardInformationNodes)
                            {
                                Console.WriteLine("    |--" + subCard);

                                if (subCard == "Roles")
                                {
                                    // Delve into the Role Nodes
                                    string[] roleNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string roleNode in roleNodes)
                                    {
                                        Console.WriteLine("    |----" + roleNode);
                                        roles.Add(Enum.Parse<EMonsterRole>(roleNode));
                                    }
                                }
                                
                                if (subCard == "Skills")
                                {
                                    // Delve into the Skill Nodes
                                    string[] skillNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string skillNode in skillNodes)
                                    {
                                        Console.WriteLine("    |----" + skillNode);
                                        skills.Add(Enum.Parse<ESkill>(skillNode));
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
                                    effectAmount.x = int.Parse(effectNodes[0]);
                                    effectAmount.y = int.Parse(effectNodes[1]);
                                    effectAmount.z = int.Parse(effectNodes[2]);
                                }
                                
                                if (subCard == "Element")
                                {
                                    element = Enum.Parse<EElementIndex>(GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0]);
                                }
                                
                                if (subCard == "Rarity")
                                {
                                    rarity = Enum.Parse<ERarity>(GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0]);
                                }
                                
                                if (subCard == "NextForm")
                                {
                                    nextForm = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }
                                
                                if (subCard == "PreviousForm")
                                {
                                    previousForm = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}")[0];
                                }
                                
                                if (subCard == "Stats")
                                {
                                    // Delve into the Stat Nodes
                                    string[] statNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}");
                                    foreach (string statType in statNodes)
                                    {
                                        Console.WriteLine("    |----" + statType);
                                        if (statType == "BaseStats")
                                        {
                                            // Delve into the Base Stat Nodes
                                            string[] baseNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}/{statType}");
                                            foreach (string baseNode in baseNodes)
                                            {
                                                Console.WriteLine("    |------" + baseNode);
                                                baseStats.Add(int.Parse(baseNodes[0]));
                                            }
                                        }
                                        if (statType == "ModifiedStats")
                                        {
                                            // Delve into the Modified Stat  Nodes
                                            string[] modifiedNodes = GetNodesClass.GetNodes(Tree, $"Sets/{item}/{subItem}/{cardItem}/{subCard}/{statType}");
                                            foreach (string modifiedNode in modifiedNodes)
                                            {
                                                Console.WriteLine("    |------" + modifiedNode);
                                                baseStats.Add(int.Parse(modifiedNodes[0]));
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