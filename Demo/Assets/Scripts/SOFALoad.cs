using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;

public class SOFALoad : MonoBehaviour {

    private Button openSOFA;
    public int sofaID;

    private string path;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(OnClick_selectSOFA);
        Transform child = transform.Find("Open");
        openSOFA = child.GetComponent<Button>();
        openSOFA.onClick.AddListener(OnClick_openSOFA);
    }

    void OnClick_openSOFA()
    {
        ExtensionFilter[] extensions = new[] {
                new ExtensionFilter("SOFA Files", "sofa"),
                new ExtensionFilter("All Files", "*" ),
            };

        path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
        sofaID = iHRTF.iHRTF_loadSOFA(path);
        Debug.Log("Opening: " + path);
    }

    void OnClick_selectSOFA()
    {
        iHRTF.iHRTF_selectSOFA(sofaID);
        Debug.Log("Loading: " + sofaID);

        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("SOFA Selector"))
        {
            if (Obj.name == this.name )
                Obj.GetComponent<Image>().color = Color.yellow;
            else
                Obj.GetComponent<Image>().color = Color.white;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    
    public string WriteResult(string[] paths)
    {
        string str = "";
        if (paths.Length == 0)
        {
            return str;
        }
        else
            str += paths[0];

        //foreach (var p in paths)
        //{
        //    str += p + "\n";
        //}
        return str;
    }

    public string WriteResult(string path)
    {
        return path;
    }
}
