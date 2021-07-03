using UnityEngine;
using System.Collections;

public class HandRespawnerScript : MonoBehaviour {

	public GameObject hand;
	private bool flagHand = false;
	public Animator traceHand;
	public RotateJarum rj;
	private GameObject rjgo;
	// Use this for initialization
	void Start () {
		rjgo = GameObject.Find("GameManager");
		rj = rjgo.GetComponent<RotateJarum>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		if((coll.gameObject.name == "ColliderJarum1" || coll.gameObject.name == "ColliderJarum2")){
			if(this.gameObject.tag == "TouchHand" || this.gameObject.tag == "HoldHand"){
				hand.SetActive(true);
				flagHand = true;
				Invoke("upHand",0.15f);
			}else if(this.gameObject.tag == "TraceHand"){
				hand.SetActive(true);
				flagHand = true;
				Invoke("upHand",0.15f);
				if(this.gameObject.name == "handRespawn (3)"){
					Invoke("setTriggerHand1",0.2f);
				}else if(this.gameObject.name == "handRespawn (4)"){
					Invoke("setTriggerHand2",0.2f);
				}else if(this.gameObject.name == "handRespawn (21)"){
					Invoke("setTriggerHand3",0.2f);
				}
			}
		}
	}
	//535
	void upHand(){
		hand.transform.localPosition = new Vector3(hand.transform.localPosition.x, hand.transform.localPosition.y + 0.35f, hand.transform.localPosition.z);
		if(this.gameObject.tag == "TouchHand")Invoke("discardHand",0.35f);
		else if(this.gameObject.tag == "TraceHand")Invoke("discardHand",1.5f);
		else if(this.gameObject.tag == "HoldHand")Invoke("discardHand",1.8f);
	}
	void downHand(){
		hand.transform.localPosition = new Vector3(hand.transform.localPosition.x, hand.transform.localPosition.y - 0.35f, hand.transform.localPosition.z);
		Invoke("discardHand",0.35f);
	}
	void discardHand(){
		hand.SetActive(false);
		Destroy(this.gameObject);
	}
	void setTriggerHand1(){
		traceHand.SetTrigger("isTrace1Clip");
	}
	void setTriggerHand2(){
		traceHand.SetTrigger("isTrace2Clip");
	}
	void setTriggerHand3(){
		traceHand.SetTrigger("isTrace3Clip");
	}
}
//10.53, -10.2
//10.53, -9.9