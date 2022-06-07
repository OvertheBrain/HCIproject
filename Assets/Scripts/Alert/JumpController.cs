using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float time;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();

        if(currentTime >= time)
        {
            End();
        }
    }

    void TimeUpdate()
    {
        currentTime += Time.deltaTime;
    }

    void End()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.isJumping = false;
        Destroy(this.gameObject, 3.5f);
    }
}
