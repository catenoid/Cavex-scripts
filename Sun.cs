using UnityEngine;
using System;

public class Sun : MonoBehaviour {
    public Camera_flip cf; // need the rotation speed
    
    int day_of_year = 100;        // = 1 on January 1st
    double latitude = 51 * (Math.PI/180);        // The cafe next door is called 51 Degrees North
    double hour_at_start = 10;   // Start the game at 10am
    double idle_rotation_speed = 0.5;
    
    double rotation_speed;
    bool clockwise = true;
    
    double hour_angle;           // Rotates by 15 degrees every hour. Zero at noon, positive in the afternoon
    double declination_angle;
    double hour_angle_at_sunset;
    double camera_rotation_duration;
    
    // Sun position
    double altitude;
    double azimuth;
    
    // azimuth = 0, altitude = 0
    Vector3 north = new Vector3(1,0,0);
    
    void Start() {
        declination_angle = 23.45 * (Math.PI/180) * Math.Sin(2*Math.PI*(284 + day_of_year)/36.25);
        hour_angle_at_sunset = Math.Acos( -Math.Tan(declination_angle) * Math.Tan(latitude) );
        camera_rotation_duration = 180 / cf.rotationSpeed;
        hour_angle = (Math.PI/12)*(hour_at_start - 12);
        transform.rotation = Sun_rotation(hour_angle);
        rotation_speed = idle_rotation_speed;
    }

    void Update() {
        if (clockwise) {
            hour_angle += Time.deltaTime * rotation_speed;
        } else {
            hour_angle -= Time.deltaTime * rotation_speed;
        }
        hour_angle = hour_angle % (2*Math.PI);
        transform.rotation = Sun_rotation(hour_angle);
    }
    
    Quaternion Sun_rotation(double hour_angle) {
        altitude = Math.Sin(declination_angle)*Math.Sin(latitude) + Math.Cos(declination_angle)*Math.Cos(hour_angle)*Math.Cos(latitude);
        azimuth = ( Math.Sin(hour_angle)*Math.Cos(declination_angle) ) / Math.Cos(altitude);
        Vector3 sun_position = north + Sun_offset_from_north(azimuth, altitude);
        return Quaternion.LookRotation(sun_position);
    }
    
    Vector3 Sun_offset_from_north(double azimuth, double altitude) {
        float x = (float) (Math.Cos(altitude) * Math.Cos(azimuth));
        float y = (float) (-Math.Sin(altitude));
        float z = (float) (-Math.Cos(altitude) * Math.Sin(azimuth));
        return new Vector3(x,y,z);
    }
    
    public void ForceSunset() {
        bool is_night_time = Math.Abs(hour_angle - Math.PI) < (Math.PI - hour_angle_at_sunset);
        if (is_night_time) {
            rotation_speed = 0;
        } else {
            double hustle_factor = 2*(hour_angle_at_sunset - hour_angle) / (rotation_speed * camera_rotation_duration);
            rotation_speed = hustle_factor * idle_rotation_speed;
        }
    }
    
    public void Reverse() {
        clockwise = !clockwise;
    }

    public void NewDay() {
        // change the north direction
        hour_angle = Math.PI;
        rotation_speed = idle_rotation_speed;
    }
    
    public void AbortedInversion() {
        clockwise = true;
        rotation_speed = idle_rotation_speed;
    }
}