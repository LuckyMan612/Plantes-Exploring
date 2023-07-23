using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kustomizacja : MonoBehaviour
{
    public Sprite komputer;
    public Sprite mlotek;
    public Sprite rakieta4;
    public Sprite rakieta3;
    public Sprite rakieta2;
    public Sprite rakieta1;
    public RawImage obecne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obecne.texture = StateNameController.ktoraStacja.texture;
    }
    public void Ustaw(string co)
    {
        switch (co)
        {
            case "komputer":
                StateNameController.ktoraStacja = komputer;
                break;
            case "mlotek":
                StateNameController.ktoraStacja = mlotek;
                break;
            case "rakieta4":
                StateNameController.ktoraStacja = rakieta4;
                break;
            case "rakieta3":
                StateNameController.ktoraStacja = rakieta3;
                break;
            case "rakieta2":
                StateNameController.ktoraStacja = rakieta2;
                break;
            case "rakieta1":
                StateNameController.ktoraStacja = rakieta1;
                break;

            default:
                StateNameController.ktoraStacja = rakieta1;
                break;
        }
    }
}
