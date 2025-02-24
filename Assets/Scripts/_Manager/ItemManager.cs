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
            item.itemData = new string[4][];
            itemNode = xmlData.SelectSingleNode($"/Items/Item[@id='{item.ItemKey}']");

            item.itemData[0] = new string[] {
                itemNode.SelectSingleNode("Name[@language='kr']")?.InnerText ?? "",
                itemNode.SelectSingleNode("Name[@language='en']")?.InnerText ?? ""};
            item.itemData[1] = new string[] {
                itemNode.SelectSingleNode("Subtitle[@language='kr']")?.InnerText ?? "",
                itemNode.SelectSingleNode("Subtitle[@language='en']")?.InnerText ?? ""};
            item.itemData[2] = new string[] {
                itemNode.SelectSingleNode("Description[@language='kr']")?.InnerText ?? "",
                itemNode.SelectSingleNode("Description[@language='en']")?.InnerText ?? ""};
            item.itemData[3] = new string[] {
                itemNode.SelectSingleNode("Effect[@language='kr']")?.InnerText ?? "",
                itemNode.SelectSingleNode("Effect[@language='en']")?.InnerText ?? ""};

            /*print(string.Format("Name: {0} || {1}\n Desc.: {2} || {3}\n Effect: {4} || {5}",
                item.itemData[0][0], item.itemData[0][1],
                item.itemData[1][0], item.itemData[1][1],
                item.itemData[2][0], item.itemData[2][1])
            );*/
        }
    }
}   