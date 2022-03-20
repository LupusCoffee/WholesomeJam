using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float time = 100;

    public TextMeshProUGUI visualTimer;

    void Update()
    {
        time -= Time.deltaTime;
        visualTimer.text = ((int)time).ToString();
        
        if(time <= 0)
        {
            print(" ");
        }
    }
}
