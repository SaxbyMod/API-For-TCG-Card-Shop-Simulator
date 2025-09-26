using List_Definer.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace List_Definer.Util
{
    public class StructReader
    {
        public static List<MiddleSetData> ReadCardStruct()
        {
            List<MiddleSetData> Sets = new List<MiddleSetData>();
            string path = ListDefinerBase.DLLPath + "..\\..\\..\\config\\ListDefiner\\Sets.apidat";

            if (!File.Exists(path))
                return Sets;

            List<string> Lines = File.ReadLines(path).ToList();
            int counter = 1;
            while (!Lines[counter].Trim().Equals("]"))
            {
                // Refactor later to allow custom set object types
                // Start of Set
                string rawline = Lines[counter];
                string SetName = "";
                string SetDescription = "";
                List<MiddleCardData> cards = new List<MiddleCardData>();
                if (rawline.TrimStart().StartsWith("\"") && !rawline.Split("\"")[1].Contains('|') && rawline.EndsWith("["))
                {
                    SetName = rawline.Split("\"")[1];
                    SetDescription = Lines[counter + 2].Trim();
                    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.WriteLine($"Found Set called; {SetName}");
                    Console.WriteLine($"    {SetDescription}");
                    Console.WriteLine($"    Contains Cards;");
                    counter += 4;
                    // Start of CardList
                    while (!Lines[counter].Trim().Equals("]"))
                    {
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
                        counter++;
                        if (Lines[counter].TrimStart().StartsWith("\"") && Lines[counter].EndsWith("["))
                        {
                            CardName = Lines[counter].Split('"')[1].Split('|')[1];
                            counter++;

                            while (!Lines[counter].Trim().Equals("]"))
                            {
                                string line = Lines[counter].Trim();

                                if (line == "Roles [")
                                {
                                    counter++;
                                    while (!Lines[counter].Trim().Equals("]"))
                                    {
                                        roles.Add(Enum.Parse<EMonsterRole>(Lines[counter].Trim()));
                                        counter++;
                                    }
                                    counter++;
                                }
                                else if (line == "Skills [")
                                {
                                    counter++;
                                    while (!Lines[counter].Trim().Equals("]"))
                                    {
                                        skills.Add(Enum.Parse<ESkill>(Lines[counter].Trim()));
                                        counter++;
                                    }
                                    counter++;
                                }
                                else if (line == "Artist [")
                                {
                                    artist = Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else if (line == "Description [")
                                {
                                    description = Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else if (line == "EffectAmount [")
                                {
                                    effectAmount.x = int.Parse(Lines[counter + 1].Trim());
                                    effectAmount.y = int.Parse(Lines[counter + 2].Trim());
                                    effectAmount.z = int.Parse(Lines[counter + 3].Trim());
                                    counter += 5;
                                }
                                else if (line == "Element [")
                                {
                                    element = Enum.Parse<EElementIndex>(Lines[counter + 1].Trim());
                                    counter += 3;
                                }
                                else if (line == "Rarity [")
                                {
                                    rarity = Enum.Parse<ERarity>(Lines[counter + 1].Trim());
                                    counter += 3;
                                }
                                else if (line == "NextForm [")
                                {
                                    nextForm = string.IsNullOrWhiteSpace(Lines[counter + 1].Trim()) ? "None" : Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else if (line == "PreviousForm [")
                                {
                                    previousForm = string.IsNullOrWhiteSpace(Lines[counter + 1].Trim()) ? "None" : Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else if (line == "Stats [")
                                {
                                    counter++;
                                    while (!Lines[counter].Trim().Equals("]"))
                                    {
                                        if (Lines[counter].Trim() == "BaseStats [")
                                        {
                                            counter++;
                                            while (!Lines[counter].Trim().Equals("]"))
                                            {
                                                baseStats.Add(int.Parse(Lines[counter].Trim()));
                                                counter++;
                                            }
                                            counter++;
                                        }
                                        else if (Lines[counter].Trim() == "ModifiedStats [")
                                        {
                                            counter++;
                                            while (!Lines[counter].Trim().Equals("]"))
                                            {
                                                modifierStats.Add(int.Parse(Lines[counter].Trim()));
                                                counter++;
                                            }
                                            counter++;
                                        }
                                        else
                                        {
                                            counter++;
                                        }
                                    }
                                    counter++;
                                }
                                else if (line == "IconPath [")
                                {
                                    IconPath = string.IsNullOrWhiteSpace(Lines[counter + 1].Trim()) ? "None" : Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else if (line == "GhostIconPath [")
                                {
                                    GhostIconPath = string.IsNullOrWhiteSpace(Lines[counter + 1].Trim()) ? "None" : Lines[counter + 1].Trim();
                                    counter += 3;
                                }
                                else
                                {
                                    counter++;
                                }
                            }

                            counter++;

                            if (!string.IsNullOrEmpty(CardName))
                            {
                                var card = new MiddleCardData(CardName, artist, description, rarity, element, effectAmount, nextForm, previousForm, roles, skills, baseStats, modifierStats, IconPath, GhostIconPath);

                                cards.Add(card);
                                Console.WriteLine($"        Found Card; {CardName}");
                                Console.WriteLine($"            {description.Replace("XXX", effectAmount.x.ToString()).Replace("YYY", effectAmount.y.ToString()).Replace("ZZZ", effectAmount.z.ToString())}");
                                Console.WriteLine($"            Artist(s): {artist}");
                                Console.WriteLine($"            Next Form: {nextForm}");
                                Console.WriteLine($"            Previous Form: {previousForm}");
                                Console.WriteLine($"            Rarity: {rarity.ToString()}");
                                Console.WriteLine($"            Element: {element.ToString()}");
                                Console.WriteLine($"            With Roles of;");
                                foreach (EMonsterRole item in roles)
                                {
                                    Console.WriteLine($"                {item.ToString()}");
                                }
                                Console.WriteLine($"            With Skills of;");
                                foreach (ESkill item in skills)
                                {
                                    Console.WriteLine($"                {item.ToString()}");
                                }
                                Console.WriteLine($"            IconPath: {IconPath}");
                                Console.WriteLine($"            GhostIconPath: {GhostIconPath}");
                            }
                        }
                        counter++;
                    }
                }
                MiddleSetData set = new MiddleSetData(SetName, SetDescription, cards);
                Sets.Add(set);
                counter++;
            }
            return Sets;
        }
    }
}