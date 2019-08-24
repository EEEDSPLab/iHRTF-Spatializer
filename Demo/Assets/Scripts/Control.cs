using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SFB;

public class Control : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip audioClip;

    public Button openFile;
    public Button play;
    public Button stop;
    public Button switchScene;

    private string path;

    public bool interpolation = true;
    public GameObject canvasFrontal;
    public GameObject canvas360;
    bool isFrontalActive = true;

    // Use this for initialization
    void Start() {
        openFile.onClick.AddListener(OnClick_openFile);
        play.onClick.AddListener(OnClick_play);
        stop.onClick.AddListener(OnClick_stop);
        switchScene.onClick.AddListener(OnClick_SwitchScene);

        canvas360.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        iHRTF.config(interpolation, 0);
    }

    void OnClick_openFile()
    {
        ExtensionFilter[] extensions = new[] {
                new ExtensionFilter("Sound Files", "wav"),
                new ExtensionFilter("All Files", "*" ),
            };

        path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
        StartCoroutine(GetAudioClip(path));
    }

    IEnumerator GetAudioClip(string path)
    {
        string url = "file://" + path;
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Loading Error " + url);
            }
            else
            {
                audioClip = DownloadHandlerAudioClip.GetContent(www);
                Debug.Log("Loading Done " + url);
            }
        }
        audioSource.clip = audioClip;
    }

    void OnClick_play()
    {
        audioSource.Play();
        Debug.Log("Playing Audio File");
    }
    void OnClick_stop()
    {
        audioSource.Stop();
        Debug.Log("Stopping");
    }

    void OnClick_SwitchScene()
    {
        isFrontalActive = !isFrontalActive;
        canvasFrontal.SetActive(isFrontalActive);
        canvas360.SetActive(!isFrontalActive);
    }

    public string WriteResult(string[] paths)
    {
        string str = "";
        if (paths.Length == 0)
        {
            return str;
        }
        
        foreach (var p in paths)
        {
            str += p + "\n";
        }
        return str;
    }

    public string WriteResult(string path)
    {
        return path;
    }
}
