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
    public GameObject Circles;
    public Text Warning;
    public Text TimeNumber;

    private float currentTime = 0;
    private AudioSource FeverSound;
    private bool isPlayed = false;

    // Start is called before the first frame update
    
    void Start()
    {
        currentTime = 0;
        FeverSound = GetComponent<AudioSource>();
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
        if(GameManager.instance.currentHotness >= hotness)
        {
            FeverAlert();
            if (!isPlayed)
                playFeverSound();
        }

        if (GameManager.instance.isHiting)
        {
            HitTap();       
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
        HotenessBar.GetComponent<Slider>().value = ((float)GameManager.instance.currentHotness) / ((float)hotness);
    }

    public void HitTap()
    {
        Animator anim = Circles.GetComponent<Animator>();
        anim.SetTrigger("Hit");
        GameManager.instance.currentHotness += 5;
        GameManager.instance.isHiting = false;
    }

    void EndWithFever()
    {
        if(GameManager.instance.currentHotness < hotness) {
            GameManager.instance.Alert2Normal();
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
        else
        {
            this.gameObject.SetActive(false);
            GameManager.instance.LaunchFever();
            FeverSound.Stop();
            isPlayed = false;
            Destroy(this.gameObject, 3.5f);
        }
    }

    void FeverAlert()
    {
        Warning.gameObject.SetActive(true);
    }

    private void playFeverSound()
    {
        FeverSound.Play();
        isPlayed = true;
    }
}
