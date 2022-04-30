using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class RobotController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject RightUpperArm,RightLowerArm,LeftUpperArm,LeftLowerArm;

    public Quaternion ru,rl,lu,ll;
    public void init(){
        ru=RightUpperArm.transform.localRotation;
        rl=RightLowerArm.transform.localRotation;
        lu=LeftUpperArm.transform.localRotation;
        ll=LeftLowerArm.transform.localRotation;
    }
    
    public Quaternion change(PosJson j,Quaternion k){
        Quaternion q=new Quaternion(0,0,0,0);
        q.x=j.x+k.x;
        q.y=j.y+k.y;
        q.z=j.z+k.z;
        return q;

    }

    public void UpdatePose(PoseJson pose){
        
        pose.RightUpperArm.z+=1.25f;
        pose.LeftUpperArm.z-=1.25f;
        pose.RightLowerArm.y+=1.25f;
        RightUpperArm.transform.localRotation=change(pose.RightUpperArm,ru);
        RightLowerArm.transform.localRotation=change(pose.RightLowerArm,rl);
        
        LeftUpperArm.transform.localRotation=change(pose.LeftUpperArm,lu);
        LeftLowerArm.transform.localRotation=change(pose.LeftLowerArm,ll);
        


    }

}
