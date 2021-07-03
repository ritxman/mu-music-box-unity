using UnityEngine;
using System.Collections;

public class NoteController : MonoBehaviour {

    private Animator note;
    private GameObject judge;
    private bool autoplay = false;
	private int damageMonster;
    private float sizex;
    private float sizey;
    private AudioSource soundeffect;
	public RotateJarum rj;
	private GameObject rjgo;
	public GameObject parentHold;
	private GameObject great, perfect;
	private bool flagPerfect = false, flagGreat = false, flagBad = false, flagMiss = false;
	private string judgeText;
	public void setJudgeText(string judgeText2){
		this.judgeText = judgeText2;
	}
	public string getJudgeText(){
		return this.judgeText;
	}
	// Use this for initialization
	void Start () {
		if(this.gameObject.tag != "Hold" && this.gameObject.tag != "akhirPathHold"){
			judgeText = "bad";
		}else{
			judgeText = "miss";
		}
		note = GameObject.Find("" + this.transform.parent.name).GetComponent<Animator>();
		//Debug.Log(""+note);
        //soundeffect = GameObject.Find("Tick").GetComponent<AudioSource>();
		rjgo = GameObject.Find("GameManager");
		rj = rjgo.GetComponent<RotateJarum>();
    }
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	void judgeNote(){
		if(judgeText == "perfect"){
			judgePerfect();
		}else if(judgeText == "great"){
			judgeGreat();
		}else if(judgeText == "bad"){
			judgeBad();
		}
		if(this.gameObject.tag == "TouchAkhir" || this.gameObject.tag == "TraceAkhir" || this.gameObject.tag == "akhirPathHoldAkhir"){
			rj.result();
		}
	}
	public void judgePerfect(){
		rj.totalPerfect++;
		flagPerfect = true;
		if(flagGreat == true || flagBad == true || flagMiss == true){
			return;
		}
		judge = GameObject.Find("perfect");
		if(note.gameObject.tag == "Touch"){
			note.SetTrigger("isNoteHitTouch");
		}else if(note.gameObject.tag == "ParentSlide"){
			note.SetTrigger("isNoteSlideTouch");
		}else if(note.gameObject.tag == "Trace"){
			note.SetTrigger("isNoteAnakSlideTouch");
		}else if(note.gameObject.tag == "Hold"){
			note.SetTrigger("isNoteHit");
		}
		if(rj.HPMonsterPunya.active == true){
			damageMonster = (int)Random.Range(10,20);
			rj.decreaseHPMonster(damageMonster);
			rj.setMuAttack();
		}
		rj.setIndexJudge(1);
		rj.setIsRespawnJudge(true);
		rj.setGoRespawnJudge(true);
		if(Application.loadedLevelName == "tutorial"){
			if(rj.getIsFever() == false && rj.feverGauge.active == true)
				rj.increaseFeverGauge(20,true);
		}else{
			if(rj.getIsFever() == false && rj.feverGauge.active == true)
				rj.increaseFeverGauge(2,true);
		}
		rj.setCombo(rj.getCombo()+1);
		rj.setScore(rj.getScore()+100);
		
		if(this.gameObject.tag == "Touch" || this.gameObject.tag == "Trace" || this.gameObject.tag == "Hold"
		|| this.gameObject.tag == "TouchAkhir" || this.gameObject.tag == "TraceAkhir"){
			Destroy(this.gameObject);
		}else{
			if(this.gameObject.tag == "akhirPathHold"){
				
				parentHold.SetActive(false);
			}
		}
	}
	public void judgeGreat(){
		rj.totalGreat++;
		flagGreat = true;
		if(flagPerfect == true || flagBad == true || flagMiss == true){
			return;
		}
		judge = GameObject.Find("great");
		if(note.gameObject.tag == "Touch"){
			note.SetTrigger("isNoteHitTouchGreat");
		}else if(note.gameObject.tag == "ParentSlide"){
			note.SetTrigger("isNoteSlideTouchGreat");
		}else if(note.gameObject.tag == "Trace"){
			note.SetTrigger("isNoteAnakSlideTouchGreat");
		}else if(note.gameObject.tag == "Hold" || note.gameObject.tag == "akhirPathHold"){
			note.SetTrigger("isNoteHit");
		}
		if(rj.HPMonsterPunya.active == true){
			damageMonster = (int)Random.Range(5,10);
			rj.decreaseHPMonster(damageMonster);
			rj.setMuAttack();
		}
		rj.setIndexJudge(2);
		rj.setIsRespawnJudge(true);
		rj.setGoRespawnJudge(true);
		if(rj.getIsFever() == false && rj.feverGauge.active == true)
			rj.increaseFeverGauge(2,true);
		rj.setCombo(rj.getCombo()+1);
		rj.setScore(rj.getScore()+50);
		if(this.gameObject.tag == "Touch" || this.gameObject.tag == "Trace" || this.gameObject.tag == "Hold"
		|| this.gameObject.tag == "TouchAkhir" || this.gameObject.tag == "TraceAkhir"){
			Destroy(this.gameObject);
		}else{
			if(this.gameObject.tag == "akhirPathHold"){
				parentHold.SetActive(false);
			}
		}
	}
	public void judgeBad(){
		rj.totalBad++;
		flagBad = true;
		if(flagPerfect == true || flagGreat == true || flagMiss == true){
			return;
		}
		judge = GameObject.Find("bad");
		if(this.gameObject.tag == "akhirPathHold" || this.gameObject.tag == "Hold"){
			parentHold.SetActive(false);
		}
		rj.setIndexJudge(3);
		rj.setCombo(0);
		rj.setIsRespawnJudge(true);
		rj.setGoRespawnJudge(true);
		note.gameObject.SetActive(false);
	}
	public void judgeMiss(){
		rj.totalMiss++;
		flagMiss = true;
		if(flagPerfect == true || flagGreat == true || flagBad == true){
			return;
		}
		judge = GameObject.Find("miss");
		if(this.gameObject.tag == "akhirPathHold" || this.gameObject.tag == "Hold"){
			parentHold.SetActive(false);
		}
		rj.setIndexJudge(4);
		rj.setCombo(0);
		rj.setIsRespawnJudge(true);
		rj.setGoRespawnJudge(true);
		note.gameObject.SetActive(false);
		if(this.gameObject.tag == "TouchAkhir" || this.gameObject.tag == "TraceAkhir" || this.gameObject.tag == "akhirPathHoldAkhir"){
			rj.result();
		}
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "NoteRespawner1" || coll.name == "NoteRespawner2") {
            note.SetTrigger("isFadeIn");
        }
		if(coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2"){
			if(Application.loadedLevelName == "tutorial"){
				if(this.gameObject.tag == "Failed"){
					judgeMiss();
					rj.setMuDamaged(20);
					rj.setCombo(0);
				}else{
					judgePerfect();
					if(this.gameObject.tag == "Untagged"){
						Destroy(this.gameObject);
					}else{
						if(this.gameObject.tag == "akhirPathHold"){
							parentHold.SetActive(false);
						}
					}
				}			
			}
		}
        /*if (autoplay == true) {
            if (coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2") {
					//untuk keperluan testing
				
					judge = GameObject.Find("perfect");
					rj.setIsRespawnJudge(true);
					rj.setGoRespawnJudge(true);
					damageMonster = (int)Random.Range(10,20);
					rj.decreaseHPMonster(damageMonster);
					rj.setMuAttack();
					rj.setIndexJudge(1);
					if(rj.getIsFever() == false && rj.feverGauge.active == true)
							rj.increaseFeverGauge(2,true);
					rj.setCombo(rj.getCombo()+1);
					rj.setScore(rj.getScore()+100);
						//soundeffect.Play();
						//judge.AddComponent<JudgeDestroyer>();
						//Instantiate(judge, new Vector3(0f, 3.7f, 0f), Quaternion.identity);
					note.SetTrigger("isNoteHit");
					if(this.gameObject.tag == "Untagged"){
						Destroy(this.gameObject);
					}else{
						if(this.gameObject.tag == "akhirPathHold"){
							parentHold.SetActive(false);
						}
					}
            }
        }else{
			
		}*/
    }
}
