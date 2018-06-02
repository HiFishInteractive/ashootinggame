using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemTracker : MonoBehaviour {
	
	ItemStats itemInCart; //Invokes the component, creates a variable here of its class
	private float itemCostTotal; //tracks the total value of what's in the shopping cart.
	ItemStats cartedItem;
	private int i;
	private int u;
	public Text shoppingListText; //to hold reference to our shopping list UI element.
	public string theItems;
    List<GameObject> itemsInCart = new List<GameObject>();
    shoppingListObjectives basketList;//invoking script and saving it to this variable
	putMeBack itemToKeep;


	

	void Start()
	{
        theItems = "";
        basketList = this.GetComponent<shoppingListObjectives>();//making variable equal
	}

	void OnTriggerEnter(Collider other) //when another rigidbody enters the trigger:
	{
		if (other.gameObject.tag == "Product") //ensures that only "products" are tracked.
		{
			itemInCart = other.gameObject.GetComponent<ItemStats> (); //gets component of other game object in trigger, assigns to variable
			itemCostTotal += itemInCart.itemPrice;
			itemsInCart.Add (other.gameObject);
            basketList.itemsInBasket.Add(other.gameObject);
			
			itemToKeep = other.gameObject.GetComponent<putMeBack>();
			itemToKeep.dontMove = true;

            basketList.UpdateList();

			

		}
        basketList.UpdateCost();
	}

	void OnTriggerExit(Collider other) //when another rigidbody exits the trigger:
	{
		itemInCart = other.gameObject.GetComponent<ItemStats>(); //gets component of other game object in trigger, assigns to variable
		//itemCostTotal -= itemInCart.itemPrice;
        basketList.itemsInBasket.Remove(other.gameObject);
		itemToKeep = other.gameObject.GetComponent<putMeBack>();
		itemToKeep.dontMove = false;
        basketList.UpdateList();
        basketList.UpdateCost();
	}

}

