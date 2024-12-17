using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;

public class PenguinArea : Area
{
    public PenguinAgent penguinAgent;
    public GameObject penguinBaby;
    public Fish fishPrefab; //TODO сделать префабом
    public TextMeshPro cumulativeRewardText;

    [HideInInspector] public float fishSpeed = 0f;
    [HideInInspector] public float feedRadius = 1f; //радиус кормления
}
