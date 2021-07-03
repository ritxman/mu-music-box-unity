using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopUIScript : MonoBehaviour {

	public GameObject shopUI;
	public GameObject potionTabSelected;
	public GameObject skillTabSelected;
	public GameObject weaponTabSelected;
	public GameObject clothTabSelected;
	public GameObject [] buttonPage = new GameObject[5];
	public GameObject [] imageSlotChoosed = new GameObject[10];
	public GameObject [] itemKategoriPotion = new GameObject[100];
	public GameObject [] itemKategoriSkill = new GameObject[100];
	public GameObject [] itemKategoriWeapon = new GameObject[100];
	public GameObject [] itemKategoriClothes = new GameObject[100];
	public int [] priceSlot1 = new int[100];
	public Text descriptionPotion;
	public int totalItem;
	
	// Use this for initialization
	void Start () {
		itemKategoriPotion = GameObject.FindGameObjectsWithTag("Potion");
		itemKategoriSkill = GameObject.FindGameObjectsWithTag("Skill");
		itemKategoriWeapon = GameObject.FindGameObjectsWithTag("Weapon");
		itemKategoriClothes = GameObject.FindGameObjectsWithTag("Clothes");
		potionTab();
	}
	
	//untuk reset tabSelected
	public void resetTabSelected(){
		potionTabSelected.SetActive(false);
		skillTabSelected.SetActive(false);
		weaponTabSelected.SetActive(false);
		clothTabSelected.SetActive(false);
	}
	
	//untuk reset slot yang dichoose
	public void resetImageSlotChoosed(){
		for(int i=0; i<9; i++){
			imageSlotChoosed[i].SetActive(false);
		}
	}
	
	//untuk close shop
	public void closeShop(){
		shopUI.SetActive(false);
	}
	//untuk set button button yang aktif
	public void setButtonPageTrue(int totalItem){
		for(int i=0; i<4; i++){
			buttonPage[i].SetActive(false);
		}
		for(int i=0, index=0; i<totalItem; i+=9){
			buttonPage[index].SetActive(true);
			index++;
		}
	}
	
	//untuk pemilihan tab
	public void potionTab(){
		totalItem = 2;
		setButtonPageTrue(totalItem);
		resetTabSelected();
		potionTabSelected.SetActive(true);
	}
	public void skillTab(){
		totalItem = 0;
		setButtonPageTrue(totalItem);
		resetTabSelected();
		skillTabSelected.SetActive(true);
	}
	public void weaponTab(){
		totalItem = 0;
		setButtonPageTrue(totalItem);
		resetTabSelected();
		weaponTabSelected.SetActive(true);
	}
	public void clothTab(){
		totalItem = 0;
		setButtonPageTrue(totalItem);
		resetTabSelected();
		clothTabSelected.SetActive(true);
	}
	
	//untuk mencetak harga item
	public string getDescription(int index){
		if(index < 0){
			return "";
		}
		return ""+itemKategoriPotion[index].GetComponent<ShopItem>().description;
	}
	//untuk pemilihan slot shop
	public void slot1(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-1);
		resetImageSlotChoosed();
		imageSlotChoosed[0].SetActive(true);
		
	}
	public void slot2(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-2);
		resetImageSlotChoosed();
		imageSlotChoosed[1].SetActive(true);
	}
	public void slot3(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-3);
		resetImageSlotChoosed();
		imageSlotChoosed[2].SetActive(true);
	}
	public void slot4(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-4);
		resetImageSlotChoosed();
		imageSlotChoosed[3].SetActive(true);
	}
	public void slot5(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-5);
		resetImageSlotChoosed();
		imageSlotChoosed[4].SetActive(true);
	}
	public void slot6(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-6);
		resetImageSlotChoosed();
		imageSlotChoosed[5].SetActive(true);
	}
	public void slot7(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-7);
		resetImageSlotChoosed();
		imageSlotChoosed[6].SetActive(true);
	}
	public void slot8(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-8);
		resetImageSlotChoosed();
		imageSlotChoosed[7].SetActive(true);
	}
	public void slot9(){
		descriptionPotion.text = ""+getDescription(itemKategoriPotion.Length-9);
		resetImageSlotChoosed();
		imageSlotChoosed[8].SetActive(true);
	}
	
}
