using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public BaseView PlayerView;
    public float maxMovementSpeed = 2.0f;
    public float accelerationRate = 0.04f;
    public float inertiaRate = 0.01f;

    public float speedThreshold = 0.02f;

    public float rotationSpeed = 1.0f;
}
