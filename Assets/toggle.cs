using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    public bool roboty = true;
    public Texture yes;
    public Texture no;
    public kustomizacja kustomizacja;

    // Start is called before the first frame update
    void Start()
    {
        ZapiszWPlayerPrefs(true);
        StateNameController.ktoraStacja = kustomizacja.rakieta1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Zmien()
    {
        if (roboty)
        {
            GetComponent<RawImage>().texture = no;
            roboty = false;
            ZapiszWPlayerPrefs(roboty);
        }

        else 
        {
            GetComponent<RawImage>().texture = yes;
            roboty = true;
            ZapiszWPlayerPrefs(roboty);
        }

    }
    void ZapiszWPlayerPrefs(bool czy)
    {
        StateNameController.roboty = czy;
        Debug.Log(czy.ToString());
    }
}
