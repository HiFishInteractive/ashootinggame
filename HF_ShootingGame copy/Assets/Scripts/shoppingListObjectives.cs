using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class shoppingListObjectives : MonoBehaviour
{

    public List<GameObject> Products = new List<GameObject>(); //list of all products available
    public List<GameObject> targetItems = new List<GameObject>(); //will be generated list of need products
    public List<Text> targetItemText = new List<Text>();    //list of text for the targeted items, displayed
    public List<GameObject> itemsInBasket = new List<GameObject>(); //generated list of items currently in shopping cart
    public List<bool> gotIt = new List<bool>();  //list of bools that are to be checked off when the required product is obtained
    public Text shoppingListText; //Just says "Shopping List" I think
    public Text totalCostText; //updated text of total cost of products in cart
    public Text budgetText; //generated budget based on target items
    public Text cashOnHandText; //updated amount of $$ left after cost subtracted from budget
    ItemStats itemNameList; //referring to the scrip on products.
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
    public float collectThemAll;
    public Animator animFadeOut;
    public Animator animSphereShopping;
    public GameObject toyGun;
    public FPScontroller playerControls;
    public GameObject PlayerAvatar;
    public GameObject endingText;

    void Start()
    {
        endingText.SetActive(false);
        playerControls = PlayerAvatar.GetComponent<FPScontroller>();
        GenerateShoppingList();
        totalCost = 0;
        totalCostText.text = totalCost.ToString();
        cashOnHand = budget;
        cashOnHandText.text = cashOnHand.ToString();
        animSphereShopping = animSphereShopping.GetComponent<Animator>();
    }

    void Update()
    {
        
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
        collectThemAll = 0;

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
                    gotIt[j] = true;
                    //return; <<-- supposedly ends the actions of the function. May be good alternative to using "nowGreen"
                }
                 else if (nowGreen == false)
                 {
                      targetItemText[j].color = targetItemColor;
                      gotIt[j] = false;
                 }
                 
            }
        }

        collectThemAll = 0;

        for(int k = 0; k < gotIt.Count; k++)
        {
            if (gotIt[k] == true)
            {
                collectThemAll++;
            }
        }

        Debug.Log(collectThemAll);
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
            budget += Mathf.Ceil(getItemCost.itemPrice * budgetMultiplier);
        }

        budgetText.text = budget.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckOutTrigger") && collectThemAll == 8)
        {
            Debug.Log ("you win!");
            StartCoroutine(GunRemoval());
        }
    }

    IEnumerator GunRemoval() //ending cinematic for when the player beats the game
    {
        playerControls.enabled = !playerControls.enabled; //flips the player controls off
        animSphereShopping.SetTrigger("GunGun"); //activates sphere animation to hide gun removal
        yield return new WaitForSeconds(1);
		toyGun.SetActive(false);    //deactivates the gun stuck on the players arm--hidden by the sphere animation

        yield return new WaitForSeconds(.7f);
        animFadeOut.SetTrigger("FadeOutShopperLevel"); //activates the fade out animation on canvas

        yield return new WaitForSeconds(.5f);
        endingText.SetActive(true); //activates "thanks for playing" text
    }

}