using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoseJson
{
    public PosJson Head,Spine,RightUpperArm,RightLowerArm,LeftUpperArm,LeftLowerArm;
    public MouthJson MouthShape;

}

[System.Serializable]
public class PosJson
{
    public float x,y,z;

}

[System.Serializable]
public class MouthJson
{
    public float A,E,I,O,U;

}