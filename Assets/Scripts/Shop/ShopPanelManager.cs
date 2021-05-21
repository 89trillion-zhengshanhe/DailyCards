using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Text refeshText;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardField;
    [SerializeField] private LoadJsonFile loadJsonFile;

    private float timeRemaining;
    private float saveTimeRemaining;

    private GameObject newCard;

    public void CreateCard()
    {
        List<Product> productList = loadJsonFile.ReadJson();
        foreach (Product product in productList)
        {
            newCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), cardPrefab.transform.rotation);
            newCard.transform.SetParent(cardField.transform, false);
            Product cardInfo = newCard.GetComponent<Product>();
            cardInfo.setProductInformations(product.productId, product.type, product.subType, product.num,
                product.costGold, product.costGem, product.isPurchased);
        }
    }

    public void DestroyCard()
    {
        for (int childIndex = 0; childIndex < cardField.transform.childCount; childIndex++)
        {
            Destroy(cardField.transform.GetChild(childIndex).gameObject);
        }
    }
    
    public void StartGame()
    {
        transform.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        CreateCard();
        timeRemaining = loadJsonFile.GetProductCountDown();
        if (saveTimeRemaining != timeRemaining)
        {
            timeRemaining = saveTimeRemaining;
        }
        StartCoroutine(CountDown());
    }

    public void CloseGameView()
    {
        transform.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        saveTimeRemaining = timeRemaining;
    }

    IEnumerator CountDown()
    {
        while (timeRemaining > 0)
        {
            refeshText.text = "Refesh Time: " + timeRemaining;
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        if (timeRemaining == 0)
        {
            timeRemaining = loadJsonFile.GetProductCountDown();
            StartCoroutine(CountDown());
            DestroyCard();
            CreateCard();
        }
    }
}
