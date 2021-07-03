using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touchScreen : MonoBehaviour {
	
	public GameObject note;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*Touch myTouch = Input.GetTouch(0);
		
		Touch[] myTouches = Input.touches;
		for(int i=0; i<Input.touchCount; i++){
			
			
		}*/
		#if UNITY_EDITOR
		if(Input.GetMouseButton(0)){
			//if (Input.touchCount > 0) {
				//foreach(Touch touch in Input.touches){
					RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
					if(hit.collider != null){
						GameObject recipient = hit.collider.gameObject;
						if(Input.GetMouseButtonDown(0)){
							if(recipient.tag == "Touch" || recipient.tag == "Trace" || recipient.tag == "Hold" || recipient.tag == "akhirPathHold" || recipient.tag == "TouchAkhir" || recipient.tag == "TraceAkhir" || recipient.tag == "akhirPathHoldAkhir"){
								recipient.SendMessage("judgeNote", hit.point, SendMessageOptions.DontRequireReceiver);
							}
						}
						
						if(Input.GetMouseButtonUp(0)){
							//recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
						}
						
						if(Input.GetMouseButton(0)){
							if(recipient.tag == "Trace" || recipient.tag == "Hold" || recipient.tag == "akhirPathHold" || recipient.tag == "TraceAkhir" || recipient.tag == "akhirPathHoldAkhir"){
								recipient.SendMessage("judgeNote", hit.point, SendMessageOptions.DontRequireReceiver);
							}
						}
					}
				//}
			//}
		}
		#endif
			if (Input.touchCount > 0) {
				foreach(Touch touch in Input.touches){
					RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
					
					if(hit.collider != null){
						GameObject recipient = hit.collider.gameObject;
						
						if(touch.phase == TouchPhase.Began){
							if(recipient.tag == "Touch" || recipient.tag == "Trace" || recipient.tag == "Hold" || recipient.tag == "akhirPathHold" || recipient.tag == "TouchAkhir" || recipient.tag == "TraceAkhir" || recipient.tag == "akhirPathHoldAkhir"){
								recipient.SendMessage("judgeNote", hit.point, SendMessageOptions.DontRequireReceiver);
							}
						}
						if((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)){
							if(recipient.tag == "Trace" || recipient.tag == "Hold" || recipient.tag == "akhirPathHold" || recipient.tag == "TraceAkhir" || recipient.tag == "akhirPathHoldAkhir"){
								recipient.SendMessage("judgeNote", hit.point, SendMessageOptions.DontRequireReceiver);
							}
						}
					}
				}
			}
	}
}
