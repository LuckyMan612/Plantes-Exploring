using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltDetector : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject[] coWlaczycJezeliJestSieNaTelefonie;

    private void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        foreach (GameObject i in coWlaczycJezeliJestSieNaTelefonie)
        {
            i.SetActive(true);
        }
#endif
    }
    void Update()
    {

#if UNITY_ANDROID || UNITY_IOS
        Vector3 tilt = Input.acceleration;

        if (tilt.x > 0.3)
            pm._prawo = true;
        else
            pm._prawo = false;

        if (tilt.x < -0.3)
            pm._lewo = true;
        else
            pm._lewo = false;

        if (tilt.z > 0.1)
            pm._dol = true;
        else
            pm._dol = false;

        if (tilt.z < -0.45)
            pm._gora = true;
        else
            pm._gora = false;
#endif
    }
}
