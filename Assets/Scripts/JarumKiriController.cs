using UnityEngine;
using System.Collections;

public class JarumKiriController : MonoBehaviour {

    private GameObject[] layer = new GameObject[1000];
    public int maxlayer;
    private int indexlayer;
    private bool flagrespawn = false;
    // Use this for initialization
    void Start () {
        indexlayer = 2;
        for (int i = indexlayer; i <= maxlayer; i+=2)
        {
            layer[i] = GameObject.Find("Layer (" + i + ")");
            layer[i].SetActive(false);
        }
    }
    void setFlagRespawn() {
        flagrespawn = false;
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "RespawnerLayerKanan" && flagrespawn == false)
        {
            flagrespawn = true;
            layer[indexlayer].SetActive(true);
            if (indexlayer + 2 <= maxlayer)
            {
				if (indexlayer > 4)
                {
                    layer[indexlayer - 4].SetActive(false);
                }
                indexlayer = indexlayer + 2;
            }
            Invoke("setFlagRespawn", 1f);
        }
    }
}
