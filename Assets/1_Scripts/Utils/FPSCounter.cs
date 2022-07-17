using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;

    private int fps = 0;
    private float time = 0f;

    void Update()
    {
        if(time < 1)
        {
            time += Time.deltaTime;
            fps += 1;
        }
        else
        {
            fpsText.text = fps.ToString();
            fps = 0;
            time = 0f;
        }
    }
}
