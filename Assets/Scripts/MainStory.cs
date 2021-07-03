using UnityEngine;
using System.Collections;

public class MainStory : MonoBehaviour {

	public GameObject [] story = new GameObject[20];
	public GameObject white;
	public Animator blackBox;
	private bool flagFinished = false;
	public GameObject nowLoading;
	int counterStory = 0;
	int indexStory = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine(addCounter());
	}
	IEnumerator addCounter(){
		while(true){
			//Debug.Log(""+counterStory);
			counterStory++;
			if(counterStory == 7 || counterStory == 15 || counterStory == 23 || counterStory == 27 ||counterStory == 31 || counterStory == 35 
			|| counterStory == 41 || counterStory == 44 || counterStory == 50 || counterStory == 55 || counterStory == 59 || counterStory == 65
			){
				indexStory++;
				if(indexStory < 13)story[indexStory].SetActive(true);
			}
			if(counterStory == 62){
				white.SetActive(true);
			}
			if(counterStory == 75){
				nowLoading.SetActive(true);
			}
			if(counterStory == 78){
				nextScene();
			}
			yield return new WaitForSeconds(1f);
		}
	}
	public void nextScene(){
		Application.LoadLevel("dungeon tutorial");
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(indexStory < 12){
				indexStory++;
				story[indexStory-1].SetActive(false);
				story[indexStory].SetActive(true);
				if(counterStory < 7)counterStory = 8;
				else if(counterStory < 15)counterStory = 16;
				else if(counterStory < 23)counterStory = 24;
				else if(counterStory < 27)counterStory = 28;
				else if(counterStory < 31)counterStory = 32;
				else if(counterStory < 35)counterStory = 36;
				else if(counterStory < 41)counterStory = 42;
				else if(counterStory < 44)counterStory = 45;
				else if(counterStory < 50)counterStory = 51;
				else if(counterStory < 55)counterStory = 56;
				else if(counterStory < 59)counterStory = 60;
				else if(counterStory < 70){
					white.SetActive(false);
					counterStory = 63;
				}
			}else{
				if(flagFinished == false){
					flagFinished = true;
					blackBox.SetTrigger("isBlackBoxAppeared");
					counterStory = 73;
				}
			}
		}
	}
}
//1.153096, 1.202352