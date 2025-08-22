using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour
{
    List<Resolution> _resolutions = new List<Resolution>();
    bool _fullScreen = true;
    // Start is called before the first frame update
    void Start()
    {
        _resolutions.Add(new Resolution { width = 1920, height = 1080 });
        _resolutions.Add(new Resolution { width = 1280, height = 720 });
        _resolutions.Add(new Resolution { width = 3840, height = 2160 });
        _resolutions.Add(new Resolution { width = 2560, height = 1440 });
    }

    public void SetResoution(int res)
    {
        Screen.SetResolution(_resolutions[res].width, _resolutions[res].height, _fullScreen);
    }
    
    public void SetWindow(bool isWindow)
    {
        _fullScreen = isWindow;
        Screen.fullScreen = isWindow;
    }
}
