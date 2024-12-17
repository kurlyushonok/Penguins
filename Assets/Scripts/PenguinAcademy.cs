using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class NewBehaviourScript : Academy
{
    private PenguinArea[] penguinAreas;

    public override void AcademyReset()
    {
        if (penguinAreas == null)
        {
            penguinAreas = FindObjectsOfType<PenguinArea>();
        }

        foreach (var penguinArea in penguinAreas)
        {
            penguinArea.fishSpeed = resetParameters["fish_speed"];
            penguinArea.feedRadius = resetParameters["feed_radius"];
            penguinArea.ResetArea();
        }
    }
}
