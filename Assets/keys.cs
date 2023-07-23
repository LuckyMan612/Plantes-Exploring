using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keys : MonoBehaviour
{
    public GameObject roboty;
    public GameObject gracz;
    // Start is called before the first frame update
    void Start()
    {
        roboty.SetActive(StateNameController.roboty);
        gracz.GetComponent<SpriteRenderer>().sprite = StateNameController.ktoraStacja;

        Debug.Log(StateNameController.roboty);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }   

    }
}
