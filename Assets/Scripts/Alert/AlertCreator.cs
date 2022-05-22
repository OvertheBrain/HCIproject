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
    public GameObject UI;

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
        if (GameManager.instance.isAlerting) return;

        GameObject Alert = Instantiate(UI, new Vector3(0, 0, 0), Quaternion.identity);
        Alert.transform.SetParent(canvas.transform, false);
        Alert.GetComponent<AlerController>().time = time;
        Alert.GetComponent<AlerController>().hotness = hotness;

        GameManager.instance.isAlerting = true;
    }

    public void EditTime()
    {
        time = float.Parse(inputTime.text);
    }

    public void EditHotness()
    {
        hotness = int.Parse(inputHotness.text);
    }
}
