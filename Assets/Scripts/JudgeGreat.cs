using UnityEngine;
using System.Collections;

public class JudgeGreat : MonoBehaviour {

	public NoteController nc;
	public JudgePerfect jp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2"){
			nc.setJudgeText("great");
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if(coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2"){
			nc.setJudgeText("bad");
			if(jp.flagIsMiss == true){
				Invoke("JudgeMiss",0.04f);
			}
		}
	}
	public void JudgeMiss(){
		nc.judgeMiss();
	}
}
