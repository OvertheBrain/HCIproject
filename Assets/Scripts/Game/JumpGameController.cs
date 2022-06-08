using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGameController : MonoBehaviour
{
    public GameObject left, right;
    public int score;
    public int PersonalScore = 0;

    public RobotController player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponentInParent<RobotController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (GameManager.instance.isJumping)
        {
            if (otherObj.gameObject == left)
            {
                GameManager.instance.perOfJumpig++;
                Debug.Log("left up");
            }
            if (otherObj.gameObject == right)
            {
                GameManager.instance.perOfJumpig++;
                Debug.Log("right up");
            }

            if(otherObj.gameObject == right || otherObj.gameObject == left)
            {
                player.Jump();
            }

            PersonalScore += 5;
        }

        PersonalScore++;
    }
}
