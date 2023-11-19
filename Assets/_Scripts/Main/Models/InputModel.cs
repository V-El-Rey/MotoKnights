using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModel : BaseModel
{
    public float acceletarion;
    public float brake;
    public Vector2 steer;
    public override void ClearModel()
    {
        acceletarion = 0;
        brake = 0;
        steer = Vector2.zero;
    }
}
