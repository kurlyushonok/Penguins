using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;
using Unity.VisualScripting;

public class PenguinArea : Area
{
    public PenguinAgent penguinAgent;
    public GameObject penguinBaby;
    public Fish fishPrefab; //TODO сделать префабом
    public TextMeshPro cumulativeRewardText;

    [HideInInspector] public float fishSpeed = 0f;
    [HideInInspector] public float feedRadius = 1f; //радиус кормления

    private List<GameObject> fishList;

    public override void ResetArea()
    {
        RemoveAllFish();
        PlacePenguin();
        PlaceBaby();
        SpawnFish(4, fishSpeed);
    }

    public void RemoveSpecificFish(GameObject fishObject)
    {
        fishList.Remove(fishObject);
        Destroy(fishObject);
    }

    public static Vector3 ChooseRandomPosition(Vector3 center, float minAngle, float maxAngle, 
        float minRadius, float maxRadius)
    {
        var radius = minRadius;

        if (maxRadius > minRadius)
        {
            radius = UnityEngine.Random.Range(minRadius, maxRadius);
        }

        return center + Quaternion.Euler(0f, UnityEngine.Random.Range(minAngle, maxAngle), 0f) * Vector3.forward *
            radius;
    }

    private void SpawnFish(int count, float speed)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject fishObject = Instantiate<GameObject>(fishPrefab.gameObject);
            fishObject.transform.position = ChooseRandomPosition(transform.position, 100f, 
                260f, 2f, 13f) + Vector3.up * 0.5f;
            fishObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            fishObject.transform.parent = transform;
            fishList.Add(fishObject);
            fishObject.GetComponent<Fish>().fishSpeed = fishSpeed;
        }
    }

    private void PlaceBaby()
    {
        penguinBaby.transform.position =
            ChooseRandomPosition(transform.position, -45f, 345f, 4f, 9f) + Vector3.up * 0.5f;
        penguinBaby.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    private void PlacePenguin()
    {
        penguinAgent.transform.position =
            ChooseRandomPosition(transform.position, 0f, 360f, 0f, 9f) + Vector3.up * 0.5f;
        penguinAgent.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    private void RemoveAllFish()
    {
        if (fishList != null)
        {
            for (int i = 0; i < fishList.Count; i++)
            {
                if (fishList[i] != null)
                {
                    Destroy(fishList[i]);
                }
            }
        }

        fishList = new List<GameObject>();
    }

    private void Update()
    {
        cumulativeRewardText.text = penguinAgent.GetCumulativeReward().toString();
    }
}
