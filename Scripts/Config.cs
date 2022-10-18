using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config", order = 1)]
public class Config : ScriptableObject
{
    public float boostSpeed;
    public int healPoints;
}
