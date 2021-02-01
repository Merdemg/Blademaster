using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text textBox;
    [SerializeField] float lifeTime = 1.5f;
    float timeCounter = 0;

    float riseSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; 
        pos.y += Time.deltaTime * riseSpeed;
        transform.position = pos;


        timeCounter += Time.deltaTime;

        if (timeCounter >= lifeTime) {
            Destroy(gameObject);
        }
    }

    public void SetText(string Text) {
        textBox.text = Text;
    }
}
