using UnityEngine;
using System.Collections;

public class SongTrigger : MonoBehaviour {

    // Use this for initialization
    public AudioSource song;
    private bool isPlayed = false;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.name == "ColliderJarum1" || coll.name == "ColliderJarum2") {
            if (!isPlayed) {
                isPlayed = true;
                song.gameObject.transform.Translate(0, 550, 550);
                song.Play();
            }
        }
    }
}
