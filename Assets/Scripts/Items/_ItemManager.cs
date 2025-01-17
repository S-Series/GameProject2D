using System;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static List<Item> s_Items;
    public static Dictionary<Item, string> s_ItemDict;
    [SerializeField] public List<Item> testing;

    public void Awake()
    {
        s_Items = new List<Item>();
        s_ItemDict = new Dictionary<Item, string>();
         
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (type.IsSubclassOf(typeof(Item)) && !type.IsAbstract)
            {
                Item item = (Item)Activator.CreateInstance(type);
                s_Items.Add(item);
            }
        }
        s_Items.OrderBy(item => item.ItemID);

        TextAsset xmlFile;
        xmlFile = Resources.Load<TextAsset>("ItemData");

        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(xmlFile.text);

        XmlNode itemNode;
        foreach (Item item in s_Items)
        {
            item.itemData = new string[3][];
            itemNode = xmlData.SelectSingleNode($"/Items/Item[@id='{item.ItemKey}']");
            item.itemData[0] = new string[] {
                itemNode.SelectSingleNode("Name[@language='kr']")?.InnerText ?? "이름 없음",
                itemNode.SelectSingleNode("Name[@language='en']")?.InnerText ?? "No Name"};
            item.itemData[1] = new string[] {
                itemNode.SelectSingleNode("Description[@language='kr']")?.InnerText ?? "설명 없음",
                itemNode.SelectSingleNode("Description[@language='en']")?.InnerText ?? "No Desc."};
            item.itemData[2] = new string[] {
                itemNode.SelectSingleNode("Effect[@language='kr']")?.InnerText ?? "효과 없음",
                itemNode.SelectSingleNode("Effect[@language='en']")?.InnerText ?? "No Effect"};

            print(string.Format("Name: {0} || {1}\n Desc.: {2} || {3}\n Effect: {4} || {5}",
                item.itemData[0][0], item.itemData[0][1],
                item.itemData[1][0], item.itemData[1][1],
                item.itemData[2][0], item.itemData[2][1])
            );
        }
    }
}   