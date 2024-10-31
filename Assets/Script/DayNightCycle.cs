using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [Header("References")]
    public Light2D globalLight; // The 2D global light
    public Camera mainCamera;   // Reference to the main camera

    [Header("Day/Night Settings")]
    public float dayDuration = 120f; // Duration of a full day in seconds
    public Color dayColor = new Color(1f, 0.95f, 0.8f); // Light color during the day
    public Color nightColor = new Color(0.05f, 0.05f, 0.2f); // Light color during the night
    public AnimationCurve lightIntensityCurve; // Curve to control light intensity over time

    private float currentTime = 0f; // Current time in the day cycle

    void Start()
    {
        // Initialize the animation curve if not set
        if (lightIntensityCurve == null || lightIntensityCurve.length == 0)
        {
            lightIntensityCurve = new AnimationCurve(
                new Keyframe(0f, 0f),
                new Keyframe(0.25f, 0.5f),
                new Keyframe(0.5f, 1f),
                new Keyframe(0.75f, 0.5f),
                new Keyframe(1f, 0f)
            );
        }

        // Safety checks
        if (globalLight == null)
        {
            Debug.LogError("Global Light 2D is not assigned!");
        }

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned!");
        }
    }

    void Update()
    {
        if (globalLight == null || mainCamera == null)
            return;

        // Update the time based on the duration of the day
        currentTime += Time.deltaTime / dayDuration;
        if (currentTime >= 1f)
            currentTime = 0f;

        // Calculate the current intensity using a curve
        float intensity = lightIntensityCurve.Evaluate(currentTime);

        // Lerp the camera background color between day and night colors
        mainCamera.backgroundColor = Color.Lerp(nightColor, dayColor, intensity);

        // Lerp between day and night colors based on time
        globalLight.color = Color.Lerp(nightColor, dayColor, intensity);
        globalLight.intensity = intensity;
    }
}
