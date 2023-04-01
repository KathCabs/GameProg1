using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player Defaults", menuName = "Game Prog 1/ Player Default", order = 0)]
public class PlayerDefaults : ScriptableObject
{
    public float speed;
    public float jumpForce;
    public float LazerBeamRange;


}
