using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlerController : MonoBehaviour
{
    public float time;
    public int hotness;

    private GameObject Player;

    public GameObject TimeBar;
    public GameObject HotenessBar;
    public Text Warning;
    public Text TimeNumber;

    private float currentTime = 0;
    public int currentHotness = 0;

    // Start is called before the first frame update
    
    void Start()
    {
        currentTime = 0;
        currentHotness = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
        HotnessUpdate();
        if(currentTime >= time)
        {
            EndWithFever();
        }
        if(currentHotness >= hotness)
        {
            FeverAlert();
        }
    }

    void TimeUpdate()
    {
        currentTime += Time.deltaTime;
        TimeBar.GetComponent<CircularProgressBar>().m_FillAmount = currentTime / time;
        TimeNumber.text = ((int)currentTime).ToString();
    }

    void HotnessUpdate()
    {
        HotenessBar.GetComponent<Slider>().value = ((float)currentHotness) / ((float)hotness);
    }

    void HitTap()
    {

    }

    void EndWithFever()
    {
        if(currentHotness < hotness) {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
        else
        {
            this.gameObject.SetActive(false);
            GameManager.instance.LaunchFever();
            Destroy(this.gameObject, 3.5f);
        }
    }

    void FeverAlert()
    {
        Warning.gameObject.SetActive(true);
    }
}
