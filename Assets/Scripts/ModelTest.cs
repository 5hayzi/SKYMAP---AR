using System;
using UnityEngine;

public class CelestialObjectPositioner : MonoBehaviour
{
    void Start()
    {
     CelestialObj();   
    }

    void MakeSphere(float raHours, float raMinutes, float raSeconds,float decDegrees,float decMinutes,float decSeconds, float altitudeDegrees,float azimuthDegrees, float size, float distanceAU, string SphereName){

        Vector3 celestialPosition = CelestialObjectPosition(raHours, raMinutes, raSeconds, decDegrees, decMinutes, decSeconds, altitudeDegrees, azimuthDegrees, distanceAU);

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.name = SphereName;
        
        // Set the position of the sphere
        sphere.transform.localPosition = celestialPosition;

        // Scale the celestial object based on its size
        ScaleCelestialObject(sphere.transform, size);
    }

    Vector3 CelestialObjectPosition(float raHours, float raMinutes, float raSeconds, float decDegrees, float decMinutes, float decSeconds, float altitudeDegrees, float azimuthDegrees, float distanceAU)
    {
        // Convert RA and Dec to radians
        float raRadians = Mathf.Deg2Rad * ((raHours + raMinutes / 60.0f + raSeconds / 3600.0f) * 15); // Convert hours to degrees
        float decRadians = Mathf.Deg2Rad * (decDegrees + decMinutes / 60.0f + decSeconds / 3600.0f);

        // Convert altitude and azimuth to radians
        float altitudeRadians = Mathf.Deg2Rad * altitudeDegrees;
        float azimuthRadians = Mathf.Deg2Rad * azimuthDegrees;

        // Calculate Cartesian coordinates
        float x = (distanceAU * Mathf.Cos(decRadians) * Mathf.Cos(raRadians) * Mathf.Cos(altitudeRadians) * Mathf.Cos(azimuthRadians)) / 30;
        float y = (distanceAU * Mathf.Cos(decRadians) * Mathf.Sin(raRadians) * Mathf.Cos(altitudeRadians) * Mathf.Cos(azimuthRadians)) / 30;
        float z = (distanceAU * Mathf.Sin(decRadians) * Mathf.Cos(altitudeRadians) * Mathf.Cos(azimuthRadians)) / 30;

        return new Vector3(x, y, z);
    }

    void ScaleCelestialObject(Transform transform, float Actualsize)
    {
        // Calculate the scale factor based on size (adjust as needed)
        float size = Actualsize / 20;
        transform.localScale = new Vector3(size, size, size);
    }
    void CelestialObj(){
        
        MakeSphere(21,3,19,-22,6,47,265 ,115,2159,238855, "Moon");
        MakeSphere(21, 28, 48,-14, 52, 49, 39, 218,8648938,93000000, "Sun");
        
}
}

