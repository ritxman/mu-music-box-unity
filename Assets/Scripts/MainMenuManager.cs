using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public GameObject buttonPlay;
	public GameObject buttonOption;
	public GameObject buttonCredits;
	public GameObject buttonBack;
	public Animator creditsAnimator;
	public Animator blackBox;
	public GameObject musicBoxLogo;
	public Animator muMusicBoxLogo;
	public GameObject homeBackground;
	public GameObject muSitWhite;
	public GameObject nowLoading;
	private bool flagPressed = false;
	private int counterAnimator = 0;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 1;
		StartCoroutine(animasiHomeScreen());
	}
	IEnumerator animasiHomeScreen(){
		while(true){
			if(counterAnimator < 20 && flagPressed == false)counterAnimator++;
			//Debug.Log(""+counterAnimator);
			if(counterAnimator == 5){
				musicBoxLogo.SetActive(true);
			}else if(counterAnimator == 7){
				muMusicBoxLogo.SetTrigger("isLogoMove");
			}else if(counterAnimator == 10){
				homeBackground.SetActive(true);
			}else if(counterAnimator == 13){
				muSitWhite.SetActive(true);
			}else if(counterAnimator == 17){
				setActiveButton(true);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
	public void nowLoadingAnimation(){
		nowLoading.SetActive(true);
	}
	public void play(){
		setActiveButton(false);
		blackBox.SetTrigger("isBlackBoxAppeared");
		Invoke("nowLoadingAnimation",1.5f);
		Invoke("nextScene",3f);
	}
	public void nextScene(){
		Application.LoadLevel("main story");
	}
	public void credits(){
		buttonBack.SetActive(true);
		setActiveButton(false);
		creditsAnimator.SetTrigger("isCreditsAppearedAnim");
	}
	public void backToMainMenu(){
		buttonBack.SetActive(false);
		creditsAnimator.SetTrigger("isCreditsDisappearedAnim");
		Invoke("back",0.6f);
	}
	public void back(){
		setActiveButton(true);
	}
	public void setActiveButton(bool flag){
		buttonPlay.SetActive(flag);
		buttonOption.SetActive(flag);
		buttonCredits.SetActive(flag);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(flagPressed == false){
				flagPressed = true;
				counterAnimator = 14;
				musicBoxLogo.SetActive(true);
				muMusicBoxLogo.SetTrigger("isLogoMove");
				homeBackground.SetActive(true);
				muSitWhite.SetActive(true);
				setActiveButton(true);
			}
		}
	}
}
