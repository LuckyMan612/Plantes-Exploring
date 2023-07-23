using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public Animator canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ZmienScene(int jaka)
    {
        SceneManager.LoadScene(jaka);
    }
    public void PrzyciskPlay()
    {
        canvas.Play("c");
    }
}
