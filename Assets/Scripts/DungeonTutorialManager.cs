using UnityEngine;
using System.Collections;

public class DungeonTutorialManager : MonoBehaviour {

	private int counterDungeonTutorial = 0;
	public GameObject [] conversation = new GameObject[20];
	public GameObject mainCamera;
	public GameObject canvasTutorial;
	private bool flagConversation = false;
	public bool flagCounterDungeonTutorial = true;
	public bool flagBattle = false;
	private int indexConversation = 0;
	public Animator blackBox;
	public GameObject nowLoading;
	public GameObject buttonKiri;
	public GameObject buttonKanan;
	public GameObject buttonJump;
	public GameObject imageKiri1, imageKiri2;
	public GameObject imageKanan1, imageKanan2;
	public GameObject imageJump1, imageJump2;
	
	// Use this for initialization
	void Start () {
		blackBox.SetTrigger("isBlackBoxHilang");
		canvasTutorial.SetActive(false);
		StartCoroutine(dungeonTutorial());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			//Debug.Log(indexConversation+"");
			if(flagConversation == true){
				if(indexConversation < 6 || (indexConversation > 6 && indexConversation < 9)){
					indexConversation++;
					conversation[indexConversation-1].SetActive(false);
					conversation[indexConversation].SetActive(true);
				}else{
					flagConversation = false;
					flagCounterDungeonTutorial = true;
					conversation[indexConversation].SetActive(false);
					if(indexConversation > 7){
						indexConversation++;
					}
				}
			}
			if(indexConversation == 10){
				blackBox.SetTrigger("isBlackBoxAppeared");
				Invoke("nowLoadingActive",1f);
			}
		}
	}
	public void nowLoadingActive(){
		nowLoading.SetActive(true);
		Invoke("nextScene",2f);
	}
	public void nextScene(){
		Application.LoadLevel("tutorial");
	}
	IEnumerator dungeonTutorial(){
		while(true){
			//Debug.Log(""+counterDungeonTutorial);
			if(flagCounterDungeonTutorial)counterDungeonTutorial++;
			if(counterDungeonTutorial == 5){
				conversation[indexConversation].SetActive(true);
				flagConversation = true;
				flagCounterDungeonTutorial = false;
			}else if(counterDungeonTutorial == 8){
				flagConversation = false;
				flagCounterDungeonTutorial = false;
				canvasTutorial.SetActive(true);
			}else if(counterDungeonTutorial == 11){
				indexConversation++;
				flagConversation = true;
				conversation[indexConversation].SetActive(true);
			}else if(counterDungeonTutorial == 12){
				flagCounterDungeonTutorial = false;
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
