using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class shoppingListObjectives : MonoBehaviour
{

    public List<GameObject> Products = new List<GameObject>();
    public List<GameObject> targetItems = new List<GameObject>();
    public List<Text> targetItemText = new List<Text>();
    public List<GameObject> itemsInBasket = new List<GameObject>();
    public Text shoppingListText;
    public Text totalCostText;
    public Text budgetText;
    public Text cashOnHandText;
    ItemStats itemNameList;
    public Color targetItemColor;
    public Color targetItemCollectedColor;
    public Color overBudgetColor;
    public bool runListUpdate;
    ItemStats checkFor;
    ItemStats checkThis;
    ItemStats getItemCost;
    float totalCost;
    float budget;
    float cashOnHand;
    public float budgetMultiplier;



    void Start()
    {
        GenerateShoppingList();
        totalCost = 0;
        totalCostText.text = totalCost.ToString();
        cashOnHand = budget;
        cashOnHandText.text = cashOnHand.ToString();
    }

	public void UpdateCost()
	{
        int basketListLengthCost = itemsInBasket.Count;
        totalCost = 0;


        for (int i = 0; i < basketListLengthCost; i++)
        {
            getItemCost = itemsInBasket[i].GetComponent<ItemStats>();
            totalCost += getItemCost.itemPrice;
        }

        totalCostText.text = totalCost.ToString();

        cashOnHand = budget - totalCost;

        if(cashOnHand < 0)
        {
            cashOnHandText.color = overBudgetColor;
        }
        else{
            cashOnHandText.color = targetItemCollectedColor;
        }
        cashOnHandText.text = cashOnHand.ToString();


	}

    public void UpdateList()
    {
        int shoppingListLength = targetItems.Count; 
        int basketListLength = itemsInBasket.Count;

        if(basketListLength < 1)
        {
            foreach(Text items in targetItemText)
            {
                items.color = targetItemColor;
            }
        }

        for (int j = 0; j < shoppingListLength; j++)
        {
            bool nowGreen = false;
            checkFor = targetItems[j].GetComponent<ItemStats>();

            for (int i = 0; i < basketListLength; i++)
            {
                checkThis = itemsInBasket[i].GetComponent<ItemStats>();

                if (checkFor.itemSku == checkThis.itemSku)
                {
                    targetItemText[j].color = targetItemCollectedColor;
                    nowGreen = true;
                    //return; <<-- supposedly ends the actions of the function. May be good alternative to using "nowGreen"
                }
                 else if (nowGreen == false)
                 {
                      targetItemText[j].color = targetItemColor;
                 }
                 
            }
        }
    }

    void GenerateShoppingList()
    {
        shoppingListText.text = "Shopping List:";

        for (int i = 0; i < 8; i++)
        {
            int productsNewLength = Products.Count; //get the list length of Products and save as int
            int randomTargetItem = Random.Range(0, productsNewLength); //get random number between 0 and Products's length
            targetItems.Add(Products[randomTargetItem]);//add object to other list
            Products.Remove(Products[randomTargetItem]);//remove the above object from list
            itemNameList = targetItems[i].GetComponent<ItemStats>(); //get Name property from game object
            targetItemText[i].text = itemNameList.itemName; //make object's name property the text
            targetItemText[i].color = targetItemColor; //set the object's name property text color

        }

        int shoppingListLengthBudget = targetItems.Count;

        for (int i = 0; i < shoppingListLengthBudget; i++)
        {
            getItemCost = targetItems[i].GetComponent<ItemStats>();
            budget += getItemCost.itemPrice * budgetMultiplier;
        }

        budgetText.text = budget.ToString();
    }
}