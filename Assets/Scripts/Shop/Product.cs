using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public int productId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int costGem;
    public int isPurchased;
    
    
    [SerializeField] private Image purchaseTick;
    
    [SerializeField] private GameObject coinCard;
    [SerializeField] private List<Sprite> moneyImages = new List<Sprite>();
    [SerializeField] private Image coinCardImage;
    [SerializeField] private Text coinCardTitleText;
    [SerializeField] private Button moneyCardPurchaseButton;
    
    [SerializeField] private GameObject monsterCard;
    [SerializeField] private Button monsterCardPurchaseButton;
    [SerializeField] private List<Sprite> monsterImages = new List<Sprite>();
    [SerializeField] private Image monsterCardImage;
    [SerializeField] private Text monsterCardTitleText;
    [SerializeField] private Text monsterCardButtonText;
    [SerializeField] private GameObject lockCard;


    public Product(int productId, int type, int subType = 0, int num = 0, int costGold = 0, int costGem = 0,
        int isPurchased = -1)
    {
        this.productId = productId;
        this.type = type;
        this.subType = subType;
        this.num = num;
        this.costGem = costGem;
        this.costGold = costGold;
        this.isPurchased = isPurchased;
    }

    public void setProductInformations(int productId, int type, int subType, int num, int costGold, int costGem,
        int isPurchased)
    {
        this.productId = productId;
        this.type = type;
        this.subType = subType;
        this.num = num;
        this.costGem = costGem;
        this.costGold = costGold;
        this.isPurchased = isPurchased;

        
        if (this.type == 1)
        {
            coinCard.SetActive(true);
            coinCardImage.sprite = moneyImages[0];
            coinCardTitleText.text = "Coin";
        }
        else if (this.type == 2)
        {
            coinCard.SetActive(true);
            coinCardImage.sprite = moneyImages[1];
            coinCardTitleText.text = "Gem";
        }
        else if (this.type == 3)
        {
            Dictionary<int, int> monsterIndex = new Dictionary<int, int>() {{7, 0}, {13, 1}, {18, 2}, {20, 3}};
            monsterCard.SetActive(true);
            monsterCardImage.sprite = monsterImages[monsterIndex[this.subType]];
            monsterCardTitleText.text = "Monster" + this.subType;
            monsterCardButtonText.text = this.costGold.ToString();
        }
        else
        {
            lockCard.SetActive(true);
        }
    }
    
    public void CardButtonClicked()
    {
        monsterCardPurchaseButton.gameObject.SetActive(false);
        moneyCardPurchaseButton.gameObject.SetActive(false);
        purchaseTick.gameObject.SetActive(true);
    }
}


