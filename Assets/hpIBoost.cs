using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hpIBoost : MonoBehaviour
{
    [Header("HP")]
    public int hp = 200;
    public Slider hpSlider;
    [Header("Boost")]
    public KeyCode boostKey = KeyCode.Space;
    public bool boostEnabled = true;
    public int speedOnBoost = 12;
    public Slider boostSlider;

    public float staraWartosc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hp;
        if (hp == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wGracza"))
        {
            hp -= 50;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wGracza"))
        {
            hp -= 50;
            
        }
    }
}
