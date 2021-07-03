using UnityEngine;
using System.Collections;

public class DungeonSelectManager : MonoBehaviour {

    private RaycastHit2D hit;
    private Animator maincamera;
    private Animator whitebox;
    // Use this for initialization
    void Start () {
        maincamera = GameObject.Find("Main Camera").GetComponent<Animator>();
        whitebox = GameObject.Find("white").GetComponent<Animator>();
	}
    private void nextSceneDarkForest() {
        Application.LoadLevel("dark forest");
    }
    private void nextSceneMainIsland() {
        Application.LoadLevel("main map");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.name == "leftarrow") {
                    maincamera.SetTrigger("isCameraToMainIsland");
                } else if (hit.collider.name == "rightarrow") {
                    maincamera.SetTrigger("isCameraToDarkForest");
                } else if (hit.collider.name == "DarkForest") {
                    whitebox.SetTrigger("isWhiteBoxAppeared");
                    Invoke("nextSceneDarkForest", 3f);
                } else if (hit.collider.name == "mainIsland") {
                    whitebox.SetTrigger("isWhiteBoxAppeared");
                    Invoke("nextSceneMainIsland", 3f);
                }
            }
        }
	}
}
