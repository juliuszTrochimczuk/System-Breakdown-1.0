using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveStruct
{
    [Header("Tutorial Done")]
    public bool tutorialDone;

    [Header("Score")]
    public int bestScore;

    [Header("Money")]
    public int money;

    [Header("Player experience")]
    public int skillPoints;
    public float experiencePoint;
    public float xP;
    public int level;

    [Header("Player Passive")]
    public List<int> passiveTiers;

    [Header("Player abilities")]
    public List<int> activeTiers;
    public int indexAbility1;
    public int indexAbility2;

    [Header("Story Terminals")]
    public List<bool> terminalsIndex;
}
