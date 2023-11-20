public class InputModel : BaseModel
{
    public float torqueCoeff = 10000;
    public float brakeCoeff = 500;
    public float maxSteeringAngle = 35;
    public float maxSpeed = 140;

    public float acceleration;
    public float brake;
    public float steer;
    public override void ClearModel()
    {
        acceleration = 0;
        brake = 0;
        steer = 0;
    }
}
