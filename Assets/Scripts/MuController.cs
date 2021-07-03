using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MuController : MonoBehaviour {

    private Rigidbody2D mu;
    public Animator muAnim;
    public Animator whitebox;
	public GUIManager gm;
	public GameObject gogm;

    public Animator gate, shop, upgrade, freeplay, storage;
    public Animator blackbox;
    private RaycastHit2D hit2;
    private bool isGate = false;
    private bool isFreePlay = false;
    private bool isShop = false;
    private bool isUpgrade = false;
    private bool isStorage = false;
    private bool isEnter = false; //triger character bergerak atau tidak
    private bool isTalk = false;
	
	public Animator textFreeplay;
	public Animator textStorage;
	public Animator textShop;
	public Animator textUpgrade;
	public Animator textDungeon;
	
	public GameObject buttonGo;
	public GameObject uimainmenu;
	
	public DungeonTutorialManager dtm;
	private GameObject godtm;
	
	public LayerMask touchInputMask;
	
	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	RaycastHit hit;
	
    // Use this for initialization
    void Start() {
		if(Application.loadedLevelName == "dungeon tutorial"){
			godtm = GameObject.Find("DungeonTutorialManager");
			dtm = godtm.GetComponent<DungeonTutorialManager>();
		}
		//textFreeplay.SetActive(false);
		//textDungeon.SetActive(false);
		//textUpgrade.SetActive(false);
		//textShop.SetActive(false);
		//textStorage.SetActive(false);
		//buttonGo.SetActive(false);
        mu = GameObject.Find("mu").GetComponent<Rigidbody2D>();
		//gogm = GameObject.Find("Canvas");
		//gm = gogm.GetComponent<GUIManager>();
        //muAnim = GameObject.Find("mu").GetComponent<Animator>();
        //freeplay = GameObject.Find("freeplay1").GetComponent<Animator>();
        //gate = GameObject.Find("dungeon").GetComponent<Animator>();
        //shop = GameObject.Find("shop").GetComponent<Animator>();
        //upgrade = GameObject.Find("upgrade1").GetComponent<Animator>();
        //storage = GameObject.Find("storage1").GetComponent<Animator>();

        //whitebox = GameObject.Find("white").GetComponent<Animator>();
        //blackbox = GameObject.Find("black").GetComponent<Animator>();
        blackbox.SetTrigger("isBlackBoxHilang");
    }
    public bool getIsGate() {
        return isGate;
    }
    public void setIsGate(bool isGate2) {
        this.isGate = isGate2;
    }
    public bool getIsFreePlay() {
        return isFreePlay;
    }
    public void setIsFreePlay(bool isFreePlay2) {
        this.isFreePlay = isFreePlay2;
    }
    public bool getIsShop()
    {
        return isShop;
    }
    public void setIsShop(bool isShop2)
    {
        this.isShop = isShop2;
    }
    public bool getIsTalk()
    {
        return isTalk;
    }
    public void setIsTalk(bool isTalk2)
    {
        this.isTalk = isTalk2;
    }
    public void setIsEnter(bool isEnter2) {
        this.isEnter = isEnter2;
    }
    public bool getIsEnter() {
        return isEnter;
    }
	public void setIsUpgrade(bool isUpgrade2){
		this.isUpgrade = isUpgrade2;
	}
	public bool getIsUpgrade(){
		return this.isUpgrade;
	}
	public void setIsStorage(bool isStorage2){
		this.isStorage = isStorage2;
	}
	public bool getIsStorage(){
		return this.isStorage;
	}

    void nextScene() {
        Application.LoadLevel("Dungeon");
    }
	void battleboss1(){
		Application.LoadLevel("bad apple");
	}
    public void goToNextSceneDungeon() {
        whitebox.SetTrigger("isWhiteBoxAppeared");
        isEnter = true;
        Invoke("nextScene", 3f);
    }
	public void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "daratan"){
			gm.setCounterJump(50);
		}
	}
	public void encounterboss1(){
		isEnter = true;
		uimainmenu.SetActive(false);
		whitebox.SetTrigger("isWhiteBoxAppeared");
		Invoke("battleboss1",3f);
	}
	// Update is called once per frame
	void Update () {
		
        /*if (Input.GetMouseButtonDown(0))
        {
            hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
            if (hit2.collider != null)
            {
                if (hit2.collider.gameObject.name == "freeplayCollider" && isFreePlay)
                {
                    //whitebox.SetTrigger("isWhiteBoxAppeared");
                    isEnter = true;
                }
                else if (hit2.collider.gameObject.name == "dungeonCollider" && isGate)
                {
                    goToNextSceneDungeon();
                }
                else if (hit2.collider.gameObject.name == "upgradeCollider" && isUpgrade)
                {
                    isEnter = true;
                }
                else if (hit2.collider.gameObject.name == "shopCollider" && isShop)
                {
                    isEnter = true;
                }
                else if (hit2.collider.gameObject.name == "storageCollider" && isStorage)
                {
                    isEnter = true;
                }
            }
        }*/
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.name == "freeplayCollider")
        {
			if(!isFreePlay){
				buttonGo.SetActive(true);
				isFreePlay = true;
				textFreeplay.SetTrigger("isRespawnTextFreeplay");
				//textFreeplay.SetActive(true);
				freeplay.SetTrigger("isFreeplayAnim");
			}
        }
        else if (coll.name == "dungeonCollider")
        {
			if(!isGate){
				buttonGo.SetActive(true);
				isGate = true;
				textDungeon.SetTrigger("isRespawnTextDungeon");
				//textDungeon.SetActive(true);
				gate.SetTrigger("isDungeonAnim");
			}
        }
        else if (coll.name == "upgradeCollider")
        {
			if(!isUpgrade){
				buttonGo.SetActive(true);
				isUpgrade = true;
				textUpgrade.SetTrigger("isRespawnTextUpgrade");
				//textUpgrade.SetActive(true);
				upgrade.SetTrigger("isUpgradeAnim");
			}
        }
        else if (coll.name == "shopCollider")
        {
			if(!isShop){
				buttonGo.SetActive(true);
				isShop = true;
				textShop.SetTrigger("isRespawnTextShop");
				//textShop.SetActive(true);
				shop.SetTrigger("isShopAnim");
			}
        }
        else if (coll.name == "storageCollider")
        {
			if(!isStorage){
				buttonGo.SetActive(true);
				isStorage = true;
				textStorage.SetTrigger("isRespawnTextStorage");
				//textStorage.SetActive(true);
				storage.SetTrigger("isStorageAnim");
			}
        }
		else if(coll.name == "boss1"){
			encounterboss1();
		}else if(coll.name == "ColliderPerintahJump"){
			coll.gameObject.SetActive(false);
			gm.flagJumpTutorial = true;
		}else if(coll.name == "boroTutorial"){
			gm.isLeft = false;
			gm.isRight = false;
			gm.isJump = false;
			gm.velocityjalan = 0;
			dtm.buttonKiri.SetActive(false);
			dtm.buttonKanan.SetActive(false);
			dtm.buttonJump.SetActive(false);
			dtm.imageKiri1.SetActive(false);
			dtm.imageKiri2.SetActive(false);
			dtm.imageKanan1.SetActive(false);
			dtm.imageKanan2.SetActive(false);
			dtm.imageJump1.SetActive(false);
			dtm.imageJump2.SetActive(false);
			dtm.flagCounterDungeonTutorial = true;
		}
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "freeplayCollider")
        {
			if(isFreePlay){
				buttonGo.SetActive(false);
				isFreePlay = false;
				textFreeplay.SetTrigger("isHideTextFreeplay");
				//textFreeplay.SetActive(false);
				freeplay.SetTrigger("isIdle");
			}
        }
        else if (coll.name == "dungeonCollider")
        {
			if(isGate){
				buttonGo.SetActive(false);
				isGate = false;
				textDungeon.SetTrigger("isHideTextDungeon");
				//textDungeon.SetActive(false);
				gate.SetTrigger("isIdle");
			}
        }
        else if (coll.name == "upgradeCollider")
        {
			if(isUpgrade){
				buttonGo.SetActive(false);
				isUpgrade = false;
				textUpgrade.SetTrigger("isHideTextUpgrade");
				//textUpgrade.SetActive(false);
				upgrade.SetTrigger("isIdle");
			}
        }
        else if (coll.name == "shopCollider")
        {
			if(isShop){
				buttonGo.SetActive(false);
				isShop = false;
				textShop.SetTrigger("isHideTextShop");
				//textShop.SetActive(false);
				shop.SetTrigger("isIdle");
			}
        }
        else if (coll.name == "storageCollider")
        {
			if(isStorage){
				buttonGo.SetActive(false);
				isStorage = false;
				textStorage.SetTrigger("isHideTextStorage");
				//textStorage.SetActive(false);
				storage.SetTrigger("isIdle");
			}
        }
    }
}
