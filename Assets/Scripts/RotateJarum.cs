using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotateJarum : MonoBehaviour {

    private GameObject core1, core2;
    private bool isRotate = false;
	private bool isRespawnJudge = false;
	private bool goRespawnJudge = false;
	private bool isFadeOutJudge = false;
	private int counterFadeOut;
	private int indexJudge;
	public GameObject judgePerfect;
	public GameObject judgeGreat;
	public GameObject judgeBad;
	public GameObject judgeMiss;
	private bool isPerfect = false;
	private bool isGreat = false;
	private bool isBad = false;
	private bool isMiss = false;
    public float speed;
	private float scaleX = 0f;
	private float scaleY = 0f;
	private float scaleZ = 0;
	
	private float muHP = 100f;
	private float currentMuHP = 0f;
	private float monsterHP = 520f;
	private float currentMonsterHP = 0f;
	private float feverGaugePoint = 100f;
	private float currentFeverGaugePoint = 0f;
	public int totalPerfect;
	public int totalGreat;
	public int totalBad;
	public int totalMiss;
	private int score = 0;
	private int combo = 0;
	private int multiplier = 0;
	private float batasDangerMuHP;
	private float calculatehealthMu;
	private float calculatehealthMonster;
	private float calculateFever;
	private bool triggerAnimasiDanger1 = false, triggerAnimasiDanger2 = true;
	private bool triggerMuAttack = false;
	private bool triggerMuDamaged = false;
	private bool triggerNextMonster = false;
	private bool isFever = false;
	private bool triggerFever = false;
	private bool triggerPenahanNextMonster = false;
	public Animator backgroundDanger;
	private int counterMuAttack = 0, counterMuDamaged = 0;
	private int indexmonster = 0;
	public int maxmonster;
	private bool triggerAnimationTextExtraPoints = false;
	public int maxCombo;
	
	public GameObject HPMu;
	public GameObject HPMonster;
	public GameObject feverGauge;
	public GameObject barFeverMax;
	public GameObject textComboGameObject;
	public GameObject textNilaiComboGameObject;
	public GameObject muDamaged;
	public GameObject muAttack1, muAttack2;
	public GameObject [] monster = new GameObject[10];
	public GameObject iconFever;
	public GameObject whiteCircle;
	public GameObject x2;
	public GameObject boxPointer;
	public Text damagePointMonsterText;
	public Text damagePointMuText;
	public Text scoreText;
	public Text comboText;
	public Text comboText2;
	public Text HPMuPointText;
	public Text extraPointText;
	public GameObject textAllPerfect;
	public GameObject upArrow;
	public GameObject downArrow;
	public GameObject canvasGameplay;
	public Animator blackBox;
	public Animator whiteBoxUI;
	
	Color color; //untuk judge
	Color color2;
	public GameObject HPMuPunya;
	public GameObject HPMonsterPunya;
	public GameObject DamagePoint;
	public GameObject DamagePointMu;
	public Animator musicBoxAnimasi;
	public Animator feverGaugeAnimasi;
	public GameObject baloonText;
	private bool triggerStartTutorial = false;
	private bool isFlag = false;
	private int indexDialog = 0;
	public Text tutorialText;
	private float jedaNextTextTutorial = 2f;
	private int counterNextTextTutorial = 0;
	public bool triggerTutorialAttack = false;
	private bool isFeverTutorial = false;
	public GameObject textReady;
	public GameObject textSongTitle;
	private string[] txtDialog = {
		"Welcome to the battle of the music!",
		"In this part, you will play with the rhythm.",
		"Music box is the tool which has two black circle with rotated scanline.",
		"Now let's look at the first note.",
		"This is normal note.",
		"Touch this note when the scanline is overlap.",
		"Now, go to the second one.",
		"This is drag note.",
		"Drag this note and follow its path.",
		"And the last one is hold note.",
		"Hold that note until the scanline reach the end of the meter.",
		"Good, now let's look at the battle system.",
		"Each Stage has monsters.",
		"Your task is to defeat the monsters as much as you can to earn exp points.",
		"You can deal damage to monster by responding the notes correctly.",
		"But if you fail to respond the notes correctly, you will get damage.",
		"If mu's HP reach 0, you will not gain EXP point.",
		"Make sure to respond the note correctly.",
		"Next, I will tell you about fever system.",
		"I will show you the fever bar.",
		"The benefit of fever mode is you will gain more score and more damage to monster.",
		"The meter will be increasing when you respond the note correctly.",
		"If the bar is full, tap this button.",
		"You are in fever mode!",
		"The last one, I will tell you about skill slot.",
		"You have 3 slots skill that can be used to help your battle.",
		"You can gain each skill from quest reward.",
		"That's all about the music battle. Now let's have a try",
		"Good Luck!"
	};
	public GameObject imageNowLoading;
	public GameObject textFullCombo;
	//308
	
	// Use this for initialization
	void Start () {
		totalPerfect = 0;
		totalGreat = 0;
		totalBad = 0;
		totalMiss = 0;
		//set judges
		judgePerfect.transform.localScale = new Vector3(0,0,1);
		judgeGreat.transform.localScale = new Vector3(0,0,1);
		judgeBad.transform.localScale = new Vector3(0,0,1);
		judgeMiss.transform.localScale = new Vector3(0,0,1);
		
		//set all numbers
		currentMuHP = muHP;
		currentMonsterHP = monsterHP;
		batasDangerMuHP = currentMuHP / 4;
		textComboGameObject.SetActive(false);
		textNilaiComboGameObject.SetActive(false);
		extraPointText.transform.localPosition = new Vector3(600f,0f,0f);
		indexJudge = 0;
		counterFadeOut = 0;
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 1;
        core1 = GameObject.Find("Core1");
        core2 = GameObject.Find("Core2");
		color = judgePerfect.GetComponent<Renderer>().material.color;
		damagePointMonsterText.text = "0";
		damagePointMonsterText.fontSize = 2;
		damagePointMuText.fontSize = 2;
		damagePointMuText.text = "0";
        //speed = (60 * 90 / 84 * 7.275555f) * Time.fixedDeltaTime;
        Invoke("StartRotate",2f);
		StartCoroutine(feverMode());
		StartCoroutine(animateTextExtraPoints());
		if(Application.loadedLevelName == "tutorial"){
			baloonText.SetActive(false);
			HPMuPunya.SetActive(false);
			HPMonsterPunya.SetActive(false);
			DamagePoint.SetActive(false);
			feverGauge.SetActive(false);
			Invoke("AnimasiTutorialMusicBoxPertama",6f);
			Invoke("StartTutorial",6.55f);
		}
		Invoke("discardReadyAndSongTitle",4f);
    }
	public void discardReadyAndSongTitle(){
		textReady.SetActive(false);
		textSongTitle.SetActive(false);
	}
    void StartRotate() {
        isRotate = true;
    }
	IEnumerator counterTutorial(){
		while(true){
			yield return new WaitForSeconds(0.35f);
			if(isFeverTutorial == false)counterNextTextTutorial++;
			//Debug.Log(""+counterNextTextTutorial);
			if(counterNextTextTutorial == 53 || counterNextTextTutorial == 108 || counterNextTextTutorial == 159){
				isRotate = false;
			}
			if(counterNextTextTutorial == 73 || counterNextTextTutorial == 125 || counterNextTextTutorial == 177){
				baloonText.SetActive(false);
				isRotate = true;
			}
			if(counterNextTextTutorial == 100 || counterNextTextTutorial == 150 || counterNextTextTutorial == 207 || 
			counterNextTextTutorial == 224 || counterNextTextTutorial == 308 || counterNextTextTutorial == 358 || counterNextTextTutorial == 443
			|| counterNextTextTutorial == 514 || counterNextTextTutorial == 555){
				tutorialText.text = "";
				baloonText.SetActive(true);
			}
			if(counterNextTextTutorial == 216 || counterNextTextTutorial == 545){
				baloonText.SetActive(false);
				musicBoxAnimasi.SetTrigger("isMusicBoxMoveDown");
				baloonText.transform.localPosition = new Vector3(baloonText.transform.localPosition.x, -182f, baloonText.transform.localPosition.z);
				if(counterNextTextTutorial == 545){
					HPMonsterPunya.SetActive(true);
					HPMuPunya.SetActive(true);
				}
			}
			if(counterNextTextTutorial == 225){
				HPMonsterPunya.SetActive(true);
				HPMuPunya.SetActive(true);
				triggerTutorialAttack = true;
				DamagePoint.SetActive(true);
			}
			//-182
			if(counterNextTextTutorial == 270 || counterNextTextTutorial == 335 || counterNextTextTutorial == 491 || counterNextTextTutorial == 625){
				baloonText.SetActive(false);
				musicBoxAnimasi.SetTrigger("isMusicBoxGoKiri");
			}
			if(counterNextTextTutorial == 306 || counterNextTextTutorial == 356){
				upArrow.SetActive(false);
				musicBoxAnimasi.SetTrigger("isMusicBoxGoKanan");
			}
			if(counterNextTextTutorial == 320){
				upArrow.SetActive(true);
			}
			if(counterNextTextTutorial == 424){
				baloonText.SetActive(false);
				feverGaugeAnimasi.SetTrigger("isBlinkAnimation");
				feverGauge.SetActive(true);
			}
			if(counterNextTextTutorial == 512){
				baloonText.transform.localPosition = new Vector3(baloonText.transform.localPosition.x, 179.2f, baloonText.transform.localPosition.z);
				musicBoxAnimasi.SetTrigger("isMusicBoxTutorialRespawn");
				HPMonsterPunya.SetActive(false);
				HPMuPunya.SetActive(false);
			}
			if(counterNextTextTutorial == 518){
				downArrow.SetActive(true);
				isFeverTutorial = true;
			}
			if(counterNextTextTutorial == 520){
				downArrow.SetActive(false);
			}
			//585
			if(counterNextTextTutorial == 561){
				boxPointer.SetActive(true);
			}
			if(counterNextTextTutorial == 570){
				boxPointer.SetActive(false);
			}
			if(counterNextTextTutorial == 627){
				nextScene();
			}
			//-14.9, -3.5
			if((indexDialog == 0 && counterNextTextTutorial == 10) || 
			(indexDialog == 1 && counterNextTextTutorial == 25) || 
			(indexDialog == 2 && counterNextTextTutorial == 45) ||
			(indexDialog == 3 && counterNextTextTutorial == 55) ||
			(indexDialog == 4 && counterNextTextTutorial == 63) ||
			(indexDialog == 5 && counterNextTextTutorial == 100) ||
			(indexDialog == 6 && counterNextTextTutorial == 107) ||
			(indexDialog == 7 && counterNextTextTutorial == 115) ||
			(indexDialog == 8 && counterNextTextTutorial == 150) ||
			(indexDialog == 9 && counterNextTextTutorial == 164) ||
			(indexDialog == 10 && counterNextTextTutorial == 207) ||
			(indexDialog == 11 && counterNextTextTutorial == 225) ||
			(indexDialog == 12 && counterNextTextTutorial == 240) || //your task is to...
			(indexDialog == 13 && counterNextTextTutorial == 255) || //you can deal damage..
			(indexDialog == 14 && counterNextTextTutorial == 308) ||
			(indexDialog == 15 && counterNextTextTutorial == 358) ||
			(indexDialog == 16 && counterNextTextTutorial == 372) ||
			(indexDialog == 17 && counterNextTextTutorial == 390) ||
			(indexDialog == 18 && counterNextTextTutorial == 412) ||
			(indexDialog == 19 && counterNextTextTutorial == 443) ||
			(indexDialog == 20 && counterNextTextTutorial == 470) ||
			(indexDialog == 21 && counterNextTextTutorial == 514) ||
			(indexDialog == 22 && counterNextTextTutorial == 520) ||
			(indexDialog == 23 && counterNextTextTutorial == 530) || //550
			(indexDialog == 24 && counterNextTextTutorial == 555) || //575
			(indexDialog == 25 && counterNextTextTutorial == 570) || //590
			(indexDialog == 26 && counterNextTextTutorial == 600) || //620
			(indexDialog == 27 && counterNextTextTutorial == 615) //635
			//645 finish
			){
				isFlag = true;
				indexDialog++;
			}
		}
	}
	public void feverTutorial(){
		if(isFeverTutorial == true){
			activatingFeverMode();
			isFeverTutorial = false;
		}
	}
	public void nextScene(){
		canvasGameplay.SetActive(false);
		blackBox.SetTrigger("isBlackBoxAppeared");
		Invoke("nowLoading",2.5f);
		Invoke("loadScene",5f);
	}
	public void nowLoading(){
		imageNowLoading.SetActive(true);
	}
	public void loadScene(){
		Application.LoadLevel("tutorial2");
	}
	IEnumerator animationTutorial(){
		while(true){
			if(isFlag){
				isFlag = false;
				tutorialText.text = "";
					for(int i=0; i<txtDialog[indexDialog].Length; i++){
						tutorialText.text += txtDialog[indexDialog][i];
						if(txtDialog[indexDialog][i] == ','){
							yield return new WaitForSeconds(0.5f);
						}else if(txtDialog[indexDialog][i] == '.'){
							yield return new WaitForSeconds(1.1f);
						}else{
							yield return new WaitForSeconds(0.005f);
						}
						if(isFlag){
							isFlag = false;
							tutorialText.text = txtDialog[indexDialog];
							break;
						}
					}
			}
			yield return new WaitForSeconds(0f);
		}
	}
	public void AnimasiTutorialMusicBoxPertama(){
		musicBoxAnimasi.SetTrigger("isMusicBoxTutorialRespawn");
	}
	public void StartTutorial(){
		triggerStartTutorial = true;
		baloonText.SetActive(true);
		StartCoroutine(animationTutorial());
		isFlag = true;
		StartCoroutine(counterTutorial());
	}
	public void setIsRespawnJudge(bool isRespawnJudge2){
		this.isRespawnJudge = isRespawnJudge2;
	}
	public bool getIsRespawnJudge(){
		return this.isRespawnJudge;
	}
	public void setGoRespawnJudge(bool goRespawnJudge2){
		this.goRespawnJudge = goRespawnJudge2;
	}
	public bool getGoRespawnJudge(){
		return this.goRespawnJudge;
	}
	public void setIndexJudge(int indexJudge2){
		this.indexJudge = indexJudge2;
	}
	public int getIndexJudge(){
		return this.indexJudge;
	}
	public void setCombo(int combo2){
		this.combo = combo2;
		if(this.combo == 0){
			multiplier = 0;
		}
		if(this.combo % 10 == 0 && this.combo != 0){
			multiplier+=5;
		}
		if(this.combo > 5){
			textComboGameObject.SetActive(true);
			textNilaiComboGameObject.SetActive(true);
		}else{
			textComboGameObject.SetActive(false);
			textNilaiComboGameObject.SetActive(false);
		}
		comboText.text = ""+this.combo;
	}
	public int getCombo(){
		return this.combo;
	}
	public void setScore(int score2){
		this.score = score2 + multiplier;
		if(isFever){
			this.score+=100;
		}
		scoreText.text = ""+this.score;
	}
	public int getScore(){
		return this.score;
	}
	public bool getIsFever(){
		return this.isFever;
	}
	public void decreaseHPMu(float point){
		currentMuHP -= point;
		damagePointMuText.text = ""+point;
		calculatehealthMu = currentMuHP / muHP;
		setHPMuBar(calculatehealthMu);
		HPMuPointText.text = currentMuHP+" / "+muHP;
	}
	public void setHPMuBar(float myHealth){
		HPMu.transform.localScale = new Vector3(myHealth,HPMu.transform.localScale.y,HPMu.transform.localScale.z);
		if(myHealth < 0f){
			HPMu.transform.localScale = new Vector3(0,HPMu.transform.localScale.y,HPMu.transform.localScale.z);
		}
	}
	public void decreaseHPMonster(float point){
		if(isFever){
			point+=5;
		}
		damagePointMonsterText.text = ""+point;
		currentMonsterHP -= point;
		if(currentMonsterHP < 0){
			currentMonsterHP = 0;
		}
		calculatehealthMonster = currentMonsterHP / monsterHP;
		setHPMonsterBar(calculatehealthMonster);
	}
	public void setHPMonsterBar(float monsterHealth){
		HPMonster.transform.localScale = new Vector3(monsterHealth,HPMonster.transform.localScale.y,HPMonster.transform.localScale.z);
		if(monsterHealth < 0f){
			HPMonster.transform.localScale = new Vector3(0,HPMonster.transform.localScale.y,HPMonster.transform.localScale.z);
		}
	}
	public void increaseFeverGauge(float point, bool flagFever){
		if(flagFever == true){
			currentFeverGaugePoint += point;
			if(currentFeverGaugePoint >= 100){
				currentFeverGaugePoint = 100;
				barFeverMax.SetActive(true);
			}else{
				barFeverMax.SetActive(false);
			}
		}
		else {
			currentFeverGaugePoint -= point;
		}
		calculateFever = currentFeverGaugePoint / feverGaugePoint;
		setFeverGauge(calculateFever);
	}
	public void setFeverGauge(float myGauge){
		feverGauge.transform.localScale = new Vector3(feverGauge.transform.localScale.x,myGauge,feverGauge.transform.localScale.z);
		barFeverMax.transform.localScale = new Vector3(barFeverMax.transform.localScale.x,myGauge,barFeverMax.transform.localScale.z);
		if(myGauge > 1f){
			feverGauge.transform.localScale = new Vector3(feverGauge.transform.localScale.x,1,feverGauge.transform.localScale.z);
			barFeverMax.transform.localScale = new Vector3(barFeverMax.transform.localScale.x,1,barFeverMax.transform.localScale.z);
		}
	}
	public void setActiveIconFever(){
		iconFever.SetActive(true);
	}
	public void setDeactiveIconFever(){
		iconFever.SetActive(false);
	}
	public void setMuDamaged(int damagepoint){
		triggerMuDamaged = true;
		counterMuDamaged = 0;
		decreaseHPMu(damagepoint);
	}
	private void setActiveMuDamaged(){
		muDamaged.SetActive(true);
	}
	private void setDeactiveMuDamaged(){
		muDamaged.SetActive(false);
		triggerMuDamaged = false;
	}
	
	//mu menyerang musuh
	public void setMuAttack(){
		triggerMuAttack = true;
		counterMuAttack = 0;
	}
	//animasi mu attack
	private void setActiveMuAttack(){
		muAttack2.SetActive(true);
		muAttack1.SetActive(false);
	}
	private void setDeactiveMuAttack(){
		muAttack2.SetActive(false);
		muAttack1.SetActive(true);
		triggerMuAttack = false;
	}
	//mengaktifkan fever
	public void activatingFeverMode(){
		if(triggerFever == false){
			whiteCircle.SetActive(true);
			triggerFever = true;
			isFever = true;
		}
	}
	public void result(){
		if(combo == maxCombo){
			if(totalPerfect == maxCombo)textAllPerfect.SetActive(true);
			else textFullCombo.SetActive(true);
		}
		Invoke("whiteBoxUIRespawn",5f);
	}
	public void whiteBoxUIRespawn(){
		whiteBoxUI.gameObject.SetActive(true);
		whiteBoxUI.SetTrigger("isWhiteBoxUIAppeared");
	}
	//timer yang digunakan untuk fever
	IEnumerator feverMode(){
		while(true){
			if(isFever){
				x2.SetActive(true);
				increaseFeverGauge(1,false);
				iconFever.SetActive(false);
				if(currentFeverGaugePoint <= 0){
					isFever = false;
					triggerFever = false;
					whiteCircle.SetActive(false);
					x2.SetActive(false);
				}
			}
			yield return new WaitForSeconds(0.115f);
		}
	}
	
	//animasi text extra point setelah berhasil kill monster
	IEnumerator animateTextExtraPoints(){
		while(true){
			if(triggerAnimationTextExtraPoints){
				if(extraPointText.transform.localPosition.y < 135){
					extraPointText.transform.localPosition = new Vector3(299,extraPointText.transform.localPosition.y+2,0);
				}else{
					triggerAnimationTextExtraPoints = false;
					extraPointText.transform.localPosition = new Vector3(600,0,0);
				}
			}
			yield return new WaitForSeconds(0.15f);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		color2 = monster[indexmonster].GetComponent<Renderer>().material.color;
		//bersiap respawn text judge beserta damage point
		if(goRespawnJudge == true){
			comboText.transform.localPosition = new Vector3(2.3f,-6.9f,0f);
			comboText2.transform.localPosition = new Vector3(1f,31.49f,0f);
			counterFadeOut = 0;
			goRespawnJudge = false;
			isFadeOutJudge = false;
			color.a = 1;
			scaleX = 1.3f;
			scaleY = 1.3f;
			scaleZ = 1;
			if(indexJudge == 1 || indexJudge == 2)damagePointMonsterText.fontSize = 75;
			if(indexJudge == 3 || indexJudge == 4)damagePointMuText.fontSize = 75;
		}
		//ketika hp monster mencapai 0, monster berikutnya muncul
		if(currentMonsterHP <= 0){
			if(color2.a>0)color2.a-=0.1f;
			monster[indexmonster].GetComponent<Renderer>().material.color = color2;
			if(color2.a <= 0){
				triggerNextMonster = true;
				monster[indexmonster].transform.localPosition = new Vector3(0.50f,monster[indexmonster].transform.localPosition.y,monster[indexmonster].transform.localPosition.z);
				if(indexmonster<maxmonster-1){
					indexmonster++;
				}else{
					indexmonster = 0;
				}
				currentMonsterHP = monsterHP;
				setHPMonsterBar(1);
				color2.a = 1;
				setScore(getScore()+1000);
				extraPointText.transform.localPosition = new Vector3(299,119,0);
				triggerAnimationTextExtraPoints = true;
			}
		}
		if(triggerMuDamaged == true){
			setActiveMuDamaged();
			counterMuDamaged+=1;
			if(counterMuDamaged>=6){
				setDeactiveMuDamaged();
			}
		}
		if(currentFeverGaugePoint>=100){
			iconFever.SetActive(true);
		}else{
			iconFever.SetActive(false);
		}
		if(triggerNextMonster){
			monster[indexmonster].transform.localPosition = new Vector3(monster[indexmonster].transform.localPosition.x-0.15f, monster[indexmonster].transform.localPosition.y, monster[indexmonster].transform.localPosition.z);
			if(monster[indexmonster].transform.localPosition.x <= -3.19f){
				triggerNextMonster = false;
			}
		}
		if(triggerMuAttack == true){
			setActiveMuAttack();
			counterMuAttack+=1;
			if(color2.a >= 0.5f && counterMuAttack < 6 && currentMonsterHP > 0){
				color2.a-=0.15f;
			}
			if(counterMuAttack>=6 && currentMonsterHP > 0){
				color2.a = 1f;
				setDeactiveMuAttack();
			}
			monster[indexmonster].GetComponent<Renderer>().material.color = color2;
		}
		if(currentMuHP <= batasDangerMuHP){
			triggerAnimasiDanger2 = false;
			if(triggerAnimasiDanger1 == false){
				triggerAnimasiDanger1 = true;
				backgroundDanger.SetTrigger("isDangerAnim");
			}
		}else{
			triggerAnimasiDanger1 = false;
			if(triggerAnimasiDanger2 == false){
				triggerAnimasiDanger2 = true;
				backgroundDanger.SetTrigger("isIdle");
			}
		}
		//respawn damage point
		if(isRespawnJudge == true){
			if(scaleX>1f){
				comboText.transform.localPosition = new Vector3(comboText.transform.localPosition.x,comboText.transform.localPosition.y+1f,comboText.transform.localPosition.z);
				comboText2.transform.localPosition = new Vector3(comboText2.transform.localPosition.x,comboText2.transform.localPosition.y+1f,comboText2.transform.localPosition.z);
				scaleX-=0.05f;
				scaleY-=0.05f;
				if(indexJudge == 1 || indexJudge == 2)damagePointMonsterText.fontSize-=4;
				if(indexJudge == 3 || indexJudge == 4)damagePointMuText.fontSize-=4;
			}
			if(counterFadeOut<30)counterFadeOut++;
			if(counterFadeOut >= 20){
				isFadeOutJudge = true;
			}
			if(isFadeOutJudge == true){
				color.a = color.a - 0.1f;
				if(indexJudge == 1 || indexJudge == 2)damagePointMonsterText.fontSize = 2;
				if(indexJudge == 3 || indexJudge == 4)damagePointMuText.fontSize = 2;
				if(color.a <= 0){
					isRespawnJudge = false;
				}
			}
		}
		if(textAllPerfect!=null){
			if(textAllPerfect.active == true){
				if(textAllPerfect.transform.localScale.x >= 0.6f){
					textAllPerfect.transform.localScale = new Vector3(textAllPerfect.transform.localScale.x-0.1f,textAllPerfect.transform.localScale.y-0.1f,textAllPerfect.transform.localScale.z);
				}
			}
		}
		if(textFullCombo!=null){
			if(textFullCombo.active == true){
				if(textFullCombo.transform.localScale.x >= 0.6f){
					textFullCombo.transform.localScale = new Vector3(textFullCombo.transform.localScale.x-0.1f,textFullCombo.transform.localScale.y-0.1f,textFullCombo.transform.localScale.z);
				}
			}
		}
        if (isRotate == true) {
            core1.transform.Rotate(0, 0, -speed * Time.fixedDeltaTime);
            core2.transform.Rotate(0, 0, -speed * Time.fixedDeltaTime);
        }
		if(indexJudge == 1){ //perfect
			judgePerfect.transform.localScale = new Vector3(scaleX,scaleY,scaleZ);
			judgePerfect.GetComponent<Renderer>().material.color = color;
			judgeGreat.transform.localScale = new Vector3(0,0,0);
			judgeBad.transform.localScale = new Vector3(0,0,0);
			judgeMiss.transform.localScale = new Vector3(0,0,0);
		}else if(indexJudge == 2){ //great
			judgeGreat.transform.localScale = new Vector3(scaleX,scaleY,scaleZ);
			judgeGreat.GetComponent<Renderer>().material.color = color;
			judgePerfect.transform.localScale = new Vector3(0,0,0);
			judgeBad.transform.localScale = new Vector3(0,0,0);
			judgeMiss.transform.localScale = new Vector3(0,0,0);
		}else if(indexJudge == 3){ //bad
			judgeBad.transform.localScale = new Vector3(scaleX,scaleY,scaleZ);
			judgeBad.GetComponent<Renderer>().material.color = color;
			judgePerfect.transform.localScale = new Vector3(0,0,0);
			judgeGreat.transform.localScale = new Vector3(0,0,0);
			judgeMiss.transform.localScale = new Vector3(0,0,0);
		}else if(indexJudge == 4){ //miss
			judgeMiss.transform.localScale = new Vector3(scaleX,scaleY,scaleZ);
			judgeMiss.GetComponent<Renderer>().material.color = color;
			judgePerfect.transform.localScale = new Vector3(0,0,0);
			judgeGreat.transform.localScale = new Vector3(0,0,0);
			judgeBad.transform.localScale = new Vector3(0,0,0);
		}
    }
	
}
