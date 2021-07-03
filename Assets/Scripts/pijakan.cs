using UnityEngine;
using System.Collections;

public class pijakan : MonoBehaviour {

	public GUIManager gm;
	private GameObject gogm;
	// Use this for initialization
	void Start () {
		//gogm = GameObject.Find("Canvas");
		//gm = gogm.GetComponent<GUIManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//test
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "daratan"){
			gm.setIsJump(false);
			gm.setCounterJump(0);
		}
	}
}
