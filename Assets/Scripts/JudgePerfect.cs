using UnityEngine;
using System.Collections;

public class JudgePerfect : MonoBehaviour {

	public NoteController nc;
	public bool flagIsMiss = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2"){
			nc.setJudgeText("perfect");
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if(coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2"){
			if(this.transform.parent.tag == "Hold" || this.transform.parent.tag == "akhirPathHold"){
				Invoke("JudgeMiss",0.04f);
			}else{
				nc.setJudgeText("great");
				flagIsMiss = true;
			}
		}
	}
	public void JudgeMiss(){
		nc.judgeMiss();
	}
}
