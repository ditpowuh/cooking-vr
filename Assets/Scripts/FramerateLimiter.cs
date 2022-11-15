using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {

    private static GameObject instance;

    public int framerate = 120;

    void Start() {
      if (instance != null) {
        Destroy(this.gameObject);
      }
      else {
        instance = this.gameObject;
        DontDestroyOnLoad(this.gameObject);
      }
    }

    void Update() {
      Application.targetFrameRate = framerate;
    }

}
