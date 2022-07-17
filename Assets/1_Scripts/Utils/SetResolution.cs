using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    [SerializeField] private Resolution resolution;

    private void Start()
    {
        int height = Screen.height;
        int width = Screen.width;

        if(width > height)
        {
            float aspectRatio = (float)width / (float)height;
            height = (int)resolution;
            width = (int)(height * aspectRatio);

            Screen.SetResolution(width, height, FullScreenMode.ExclusiveFullScreen);
        }
        else
        {
            float aspectRatio = (float)height / (float)width;
            width = (int)resolution;
            height = (int)(width * aspectRatio);

            Screen.SetResolution(width, height, FullScreenMode.ExclusiveFullScreen);
        }
    }
}

public enum Resolution
{
    _540 = 540,
    _720p = 720,
    _1080p = 1080,
    _1440p = 1440
}
