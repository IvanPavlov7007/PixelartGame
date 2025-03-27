using System.Collections;
using UnityEngine;

//https://www.desmos.com/calculator/pdk2zjjplu

public class SpeedController : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float fixedSlowdownRange = 1f;
    public float punishPercentage = 0.3f;
    public float punishTime = 2f;

    //Acceleration balancing
    //https://www.desmos.com/calculator/pdk2zjjplu
    [Space]
    public float a = 1f;
    public float b = 20f;
    public float p = 2f;
    public float maxSpeed = 10f;
    public float minSpeed = 0f;
    [Space]
    public float toKM = 0.008f;
    public float toH = 3600f;
    public float kmh_speed_debug;

    private float baseSpeed;

    private void Update()
    {
        SpeedPunishment.punishPercentage = punishPercentage;
        SpeedPunishment.maxTime = punishTime;
    }


    public float calculateCurrentSpeed(BikeControl bikeControl)
    {
        float deltaSpeed = 0f;
        if (bikeControl.accelerating)
            deltaSpeed = calculateAcceleration(currentSpeed) * Time.deltaTime;
        if (bikeControl.breaking)
            deltaSpeed = calculateDeceleration(currentSpeed) * Time.deltaTime;

        float slowdownRange = calculateBikeSlowdownRange(currentSpeed);

        // if punishment is existing, don't accelerate
        baseSpeed = SpeedPunishment.payPunishment(ref baseSpeed)? baseSpeed : baseSpeed + deltaSpeed;

        baseSpeed = Mathf.Clamp(baseSpeed, minSpeed + slowdownRange, maxSpeed);
        float result = baseSpeed - bikeControl.slowDown * slowdownRange;
        result = Mathf.Clamp(result, 0f, maxSpeed);

        kmh_speed_debug = result * toH * toKM;
        currentSpeed = result;
        return result;
    }

    private float calculateBikeSlowdownRange(float speed)
    {
        //todo make relative to speed
        return fixedSlowdownRange;
    }

    private float calculateAcceleration(float speed)
    {
        return a * Mathf.Pow((b - speed) / b, p);
    }

    private float calculateDeceleration(float speed)
    {
        return -10f;//a - a * Mathf.Pow((b + speed) / b, p);
    }

    public class SpeedPunishment
    {
        public static float maxTime;
        public static float punishPercentage;

        float elapsedTime;
        float highestSpeed;
        float lowestSpeed;
        bool valueFirstRead = false;

        static SpeedPunishment currentPunishment;

        private SpeedPunishment(){}

        public static void Punish()
        {
            if (currentPunishment == null)
                currentPunishment = new SpeedPunishment();
        }

        public static void ClearPunishment()
        {
            currentPunishment = null;
        }

        public static bool isBeingPunished => (currentPunishment != null);

        public static bool payPunishment(ref float baseSpeed)
        {
            if (!isBeingPunished)
                return false;
            currentPunishment._payPunishment(ref baseSpeed);
            return true;
        }

        private bool _payPunishment(ref float baseSpeed)
        {
            if(!valueFirstRead) // first call
            {
                highestSpeed = baseSpeed;
                lowestSpeed = baseSpeed * (1f - punishPercentage);

                valueFirstRead = true;
            }

            baseSpeed = Mathf.Lerp(highestSpeed, lowestSpeed, elapsedTime / maxTime);

            if(elapsedTime >= maxTime)
            {
                currentPunishment = null;
            }
            elapsedTime += Time.deltaTime;
            return true;
        }
    }
}