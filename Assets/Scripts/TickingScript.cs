using UnityEngine;
using System.Collections;

// The code example shows how to implement a metronome that procedurally 
//generates the click sounds via the OnAudioFilterRead callback.
// While the game is paused or the suspended, this time will not be 
//updated and sounds playing will be paused. 
//Therefore developers of music scheduling routines do not have to do 
//any rescheduling after the app is unpaused 

[RequireComponent(typeof(AudioSource))]
public class TickingScript : MonoBehaviour
{
    private GameObject note;
    private GameObject jarumjam1;
    private GameObject jarumjam2;
    private bool flag = false;
    private GameObject line1, line2, line3, line4, line5, line6;
    public bool togglerespawnnote = false;
    private float sizex;
    private float sizey;
    private GameObject[] g = new GameObject[100];

    public double bpm = 175.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;
    private double nextTick = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int accent;
    private bool running = false;
    private AudioSource song;
    void Start()
    {
        for (int i=0; i<3; i++) {
            g[i] = GameObject.Find("note ("+(i+1)+")");
        }
        note = GameObject.Find("1");
        jarumjam1 = GameObject.Find("JarumJam1");
        jarumjam2 = GameObject.Find("JarumJam2");
        line1 = GameObject.Find("line1");
        line2 = GameObject.Find("line2");
        line3 = GameObject.Find("line3");
        line4 = GameObject.Find("line4");
        line5 = GameObject.Find("line5");
        line6 = GameObject.Find("line6");
        accent = signatureHi;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick * sampleRate;
        running = true;
    }
    
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!running)
            return;

        double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        double sample = AudioSettings.dspTime * sampleRate;
        int dataLen = data.Length / channels;
        int n = 0;
        while (n < dataLen)
        {
            float x = gain * amp * Mathf.Sin(phase);
            int i = 0;
            while (i < channels)
            {
                data[n * channels + i] += x;
                i++;
            }
            while (sample + n >= nextTick)
            {
                nextTick += samplesPerTick;
                amp = 1.0F;
                if (++accent > signatureHi)
                {
                    accent = 1;
                    amp *= 2.0F;

                }
                //Debug.Log("Tick: " + accent + "/" + signatureHi);
                
            }
            phase += amp * 0.3F;
            amp *= 0.993F;
            n++;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (togglerespawnnote == false) {
                togglerespawnnote = true;
            }
            else {
                togglerespawnnote = false;
            }
        }

        if (accent % 2 == 1) {
            if (flag == false) {
                /*for (int i=0; i<3; i++) {
                    g[i].gameObject.transform.localScale = new Vector3(0.4f,0.4f,0f);
                    Debug.Log("1: "+g[i].transform.localScale);
                }*/
                flag = true;
                if (togglerespawnnote == true) {
                    Instantiate(note, new Vector3(line1.transform.position.x, line1.transform.position.y, line1.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line2.transform.position.x, line2.transform.position.y, line2.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line3.transform.position.x, line3.transform.position.y, line3.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line4.transform.position.x, line4.transform.position.y, line4.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line5.transform.position.x, line5.transform.position.y, line5.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line6.transform.position.x, line6.transform.position.y, line6.transform.position.z), Quaternion.identity);
                }
            }
        } else if (accent % 2 == 0) {
            if (flag == true) {
                flag = false;
                /*for (int i = 0; i < 3; i++)
                {
                    g[i].gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
                    Debug.Log("2: " + g[i].transform.localScale);
                }*/
                if (togglerespawnnote == true)
                {
                    Instantiate(note, new Vector3(line1.transform.position.x, line1.transform.position.y, line1.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line2.transform.position.x, line2.transform.position.y, line2.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line3.transform.position.x, line3.transform.position.y, line3.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line4.transform.position.x, line4.transform.position.y, line4.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line5.transform.position.x, line5.transform.position.y, line5.transform.position.z), Quaternion.identity);
                    Instantiate(note, new Vector3(line6.transform.position.x, line6.transform.position.y, line6.transform.position.z), Quaternion.identity);
                }
            }
        }
    }
}