using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;
using UnityEngine.PlayerLoop;

public class LoadJsonFile: MonoBehaviour
{
    private string path;
    private string jsonString;
    private int numOfProduct;
    private int numOfLock;
    private int dailyProductCountDown;

    public List<Product> ReadJson()
    {
        List<Product> listProducts = new List<Product>(); 
        path = Application.dataPath + "/Resources/JSON/data.json";
        jsonString = File.ReadAllText(path);
        JSONNode data = JSON.Parse(jsonString);
        foreach (JSONNode record in data["dailyProduct"])
        {
            Product product = new Product(record["productId"].AsInt, record["type"].AsInt,
            record["subType"].AsInt, record["num"].AsInt, record["costGold"].AsInt,
            record["costGem"].AsInt,record["isPurchased"].AsInt);
            listProducts.Add(product);
        }
        dailyProductCountDown = data["dailyProductCountDown"];
        int numOfList = listProducts.Count;
        if (numOfList % 3 != 0)
        {
            numOfProduct = 3 * (numOfList / 3 + 1);
            numOfLock = numOfProduct - numOfList;
        }

        for (int loclCount = 0; loclCount < numOfLock; loclCount++)
        {
            Product lockProduct = new Product(++numOfList, 8);
            listProducts.Add(lockProduct);
        }
        return listProducts;
    }

    public int GetProductCountDown()
    {
        return dailyProductCountDown;
    }
}

