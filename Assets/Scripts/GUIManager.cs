using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public Text EXPText;
	public Text LevelText;
	public Text CoinText;
	
	private Rigidbody2D mu;
	public bool isLeft;
	public bool isRight;
	public bool isJump;
	private float diff;
	private float posisiButtonLeftX;
	private float posisiButtonLeftY;
	private float posisiButtonRightX;
	private float posisiButtonRightY;
	private int counterJump;
	public float velocityjalan;
	private float velocityatas;
	private float pengurangan;
	public float batasvelocityjalan = 6;
	public float batasCounterJump = 40;
	
	private float posisixcamera;
	private float posisiycamera;
	private float posisizcamera;
	public bool triggerJumpDown = false;
	private bool flagCamera = false;
	
	public MuController mc;
	private GameObject gomc;
	public GameObject cameraFollow;
	
	public Texture2D buttonKiriText;
	public Texture2D buttonKananText;
	public GameObject menu;
	public GameObject kiriPressed;
	public GameObject kananPressed;
	public GameObject jumpPressed;
	
	private float calculateEXP;
	private float currentEXP;
	public float maxEXP = 80;
	public GameObject EXPBar;
	private int level;
	Rect ButtonKiri;
	Rect ButtonKanan;
	
	//dungeon tutorial
	public GameObject tutorial1;
	public GameObject tutorial2;
	public GameObject boxPointer1;
	public GameObject boxPointer2;
	public bool flagJumpTutorial = false;
	// Use this for initialization
	void Start () {
		level = 1;
		currentEXP = 0;
		maxEXP = 80;
		setEXP(0);
		if(Application.loadedLevelName == "main map"){
			flagCamera = true;
		}
		kiriPressed.SetActive(false);
		kananPressed.SetActive(false);
		jumpPressed.SetActive(false);
		menu.SetActive(true);
		mu = GameObject.Find("mu").GetComponent<Rigidbody2D>();
		gomc = GameObject.Find("mu");
		mc = gomc.GetComponent<MuController>();
		isLeft = false;
		isRight = false;
		isJump = false;
		velocityjalan = 0;
		velocityatas = -4f;
		counterJump = 0;
		posisiButtonLeftX = 35f;
		posisiButtonLeftY = 590.5f;
		posisiButtonRightX = 250f;
		posisiButtonRightY = 590.5f;
		posisixcamera = 8.2f;
		posisiycamera = -3.9f;
		posisizcamera = -28.85f;
		if(flagCamera == true)cameraFollow.transform.localPosition = new Vector3(posisixcamera,posisiycamera,posisizcamera);
	}
	public void setEXP(float point){
		currentEXP += point;
		if(currentEXP >= maxEXP){
			level += 1;
			LevelText.text = "Level "+level;
			currentEXP -= maxEXP;
			maxEXP = maxEXP * 2;
		}
		calculateEXP = currentEXP / maxEXP;
		EXPText.text = (int)(calculateEXP * 100)+"%";
		setEXPBar(calculateEXP);
	}
	public void setEXPBar(float point){
		EXPBar.transform.localScale = new Vector3(point,EXPBar.transform.localScale.y,EXPBar.transform.localScale.z);
	}
	public void Go(){
		if(mc.getIsFreePlay() == true){
			
		}else if(mc.getIsStorage() == true){
			
		}else if(mc.getIsShop() == true){
			
		}else if(mc.getIsUpgrade() == true){
			
		}else if(mc.getIsGate() == true){
			menu.SetActive(false);
			mc.goToNextSceneDungeon();
			mc.setIsEnter(true);
		}
	}
	public void GoJump(){
		if(Application.loadedLevelName == "dungeon tutorial"){
			boxPointer2.SetActive(false);
			Invoke("setActiveFalseDialog2",1f);
		}
		jumpPressed.SetActive(true);
		if(isJump == false){
			triggerJumpDown = false;
			counterJump = 0;
			velocityatas = 12;
			isJump = true;
		}
	}
	public void ReleaseJump(){
		jumpPressed.SetActive(false);
	}
	public void setActiveFalseDialog1(){
		tutorial1.SetActive(false);
	}
	public void setActiveFalseDialog2(){
		tutorial2.SetActive(false);
	}
	public void GoLeft(){
		if(Application.loadedLevelName == "dungeon tutorial"){
			boxPointer1.SetActive(false);
			Invoke("setActiveFalseDialog1",1f);
			mc.muAnim.SetTrigger("isMuWalkLeft");
		}
		mc.muAnim.SetTrigger("isMuWalkLeft");
		isLeft = true;
		isRight = false;
		kiriPressed.SetActive(true);
		//mu.velocity = new Vector3(-7,mu.velocity.y,0);
	}
	public void GoRight(){
		if(Application.loadedLevelName == "dungeon tutorial"){
			boxPointer1.SetActive(false);
			Invoke("setActiveFalseDialog1",1f);
			mc.muAnim.SetTrigger("isMuWalkRight");
		}
		mc.muAnim.SetTrigger("isMuWalkRight");
		isRight = true;
		isLeft = false;
		kananPressed.SetActive(true);
		//mu.velocity = new Vector3(7,mu.velocity.y,0);
	}
	public void ReleaseLeft(){
		mc.muAnim.SetTrigger("isIdle");
		velocityjalan = 0;
		isLeft = false;
		kiriPressed.SetActive(false);
		//mu.velocity = new Vector3(0,mu.velocity.y,0);
	}
	public void ReleaseRight(){
		mc.muAnim.SetTrigger("isIdle");
		velocityjalan = 0;
		isRight = false;
		kananPressed.SetActive(false);
		//mu.velocity = new Vector3(0,mu.velocity.y,0);
	}
	public void setIsJump(bool isJump2){
		this.isJump = isJump2;
	}
	public bool getIsJump(){
		return this.isJump;
	}
	public void setCounterJump(int counterJump2){
		this.counterJump = counterJump2;
	}
	public int getCounterJump(){
		return this.counterJump;
	}
	// Update is called once per frame
	void Update () {
		//diff = (Screen.width / 12.8f) / 100;
		if(mc.getIsEnter() == false){
			if(isLeft == true){
				if(velocityjalan > -batasvelocityjalan)velocityjalan--;
			}else if(isRight == true){
				if(velocityjalan < batasvelocityjalan)velocityjalan++;
			}
			if(isJump == true){
				if(counterJump < batasCounterJump){
					if(velocityatas > 4){
						velocityatas = velocityatas - 0.25f;
					}else{
						velocityatas = 2;
					}
				}else{
					if(triggerJumpDown == false){
						triggerJumpDown = true;
						velocityatas = -1f;
					}
					if(velocityatas > -10)velocityatas = velocityatas - 0.075f;
				}
				counterJump++;
			}else{
				velocityatas = -1f;
			}
		}
		if(flagJumpTutorial == true){
			flagJumpTutorial = false;
			tutorial2.SetActive(true);
			boxPointer2.SetActive(true);
		}
		if(flagCamera == true){
			if(gomc.transform.localPosition.x < 60f && gomc.transform.localPosition.x > -58){
				posisixcamera = gomc.transform.localPosition.x;
			}
		}
		mu.velocity = new Vector3(velocityjalan,velocityatas,0);
		if(flagCamera == true)
			cameraFollow.transform.localPosition = new Vector3(posisixcamera,posisiycamera,posisizcamera);
		
	}
	void OnGUI(){
		/*ButtonKiri = new Rect(posisiButtonLeftX * diff, posisiButtonLeftY * diff, 150 * diff, 200 * diff);
		ButtonKanan = new Rect(posisiButtonRightX * diff, posisiButtonRightY * diff, 150 * diff, 200 * diff);
		GUI.DrawTexture(ButtonKiri, buttonKiriText);
		GUI.DrawTexture(ButtonKanan, buttonKananText);
		if(Input.GetMouseButton(0)){
			if(ButtonKiri.Contains(Event.current.mousePosition)){
				isLeft = true;
				isRight = false;
			}else if(ButtonKanan.Contains(Event.current.mousePosition)){
				isRight = true;
				isLeft = false;
			}
		}else{
			isRight = false;
			isLeft = false;
		}*/
	}
}
