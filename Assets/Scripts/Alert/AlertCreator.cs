using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertCreator : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 0;
    private int hotness = 0;

    public InputField inputTime;
    public InputField inputHotness;
    public InputField inputDuration;
    public Dropdown Mode;

    public GameObject UI;
    public GameObject UI2;

    public GameObject canvas;
    void Start()
    {
        time = 5;
        hotness = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAlert()
    {
        int mode = Mode.GetComponent<Dropdown>().value;

        if (mode == 0 && !GameManager.instance.isJumping) {
            if (GameManager.instance.isAlerting) return;

            GameObject Alert = Instantiate(UI, new Vector3(0, 0, 0), Quaternion.identity);
            Alert.transform.SetParent(canvas.transform, false);
            Alert.GetComponent<AlerController>().time = time;
            Alert.GetComponent<AlerController>().hotness = hotness;

            GameManager.instance.isAlerting = true; 
        }
        else if(mode == 1 && !GameManager.instance.isAlerting)
        {
            if (GameManager.instance.isJumping) return;

            GameObject JumpAlert = Instantiate(UI2, new Vector3(0, 0, 0), Quaternion.identity);
            JumpAlert.transform.SetParent(canvas.transform, false);
            JumpAlert.GetComponent<JumpController>().time = time;
            GameManager.instance.jumpBoundary = hotness;

            GameManager.instance.isJumping = true;
        }
    }

    public void EditTime()
    {
        time = float.Parse(inputTime.text);
    }

    public void EditHotness()
    {
        hotness = int.Parse(inputHotness.text);
    }

    public void EditDuration()
    {
        GameManager.instance.FeverDuration = float.Parse(inputDuration.text);
    }
}
