using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeSO", menuName = "Create New Cube SO")]
public class Cube_SO : ScriptableObject
{
    public int cubeClickAmountToDestroy;
    public float cubeDestroyAnimationTime;
}
