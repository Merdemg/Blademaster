using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    static PlayerCanvas instance;

    public static PlayerCanvas Instance {
        get { if (instance == null) instance = FindObjectOfType<PlayerCanvas>(); return instance; }
    }

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;



    public void SetImage(Sprite Sprite) {
        image.sprite = Sprite;
        image.fillAmount = 1f;
        canvas.enabled = true;
    }

    public void SetImagePerc(float Perc) {
        image.fillAmount = Perc;
    }

    public void DisableImage() {
        canvas.enabled = false;
    }
}
