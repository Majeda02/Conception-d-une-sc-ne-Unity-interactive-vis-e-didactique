using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MiniCircuitManager : MonoBehaviour
{
    [Header("UI")]
    public Slider voltageSlider;
    public TMP_Text voltageText;         // ou UnityEngine.UI.Text si pas TMP
    public Button powerButton;
    public TMP_Text consignesText;
    public TMP_Text feedbackText;

    [Header("Bulb")]
    public Renderer bulbRenderer;
    public Material bulbOffMat;
    public Material bulbOnMat;

    [Header("Effects")]
    public ParticleSystem onParticles;  // SparkleOn
    public AudioSource audioSource;     // attaché au GameManager ou Bulb

    [Header("Game settings")]
    public float thresholdVoltage = 5f; // tension minimale pour allumer

    void Start()
    {
        if (voltageSlider != null) voltageSlider.onValueChanged.AddListener(UpdateVoltage);
        if (powerButton != null) powerButton.onClick.AddListener(ToggleCircuit);
        if (consignesText != null) consignesText.text = "Consignes : Allume la lampe avec la bonne tension.";
        if (feedbackText != null) feedbackText.text = "";
        UpdateVoltage(voltageSlider != null ? voltageSlider.value : 0f);
    }

    void UpdateVoltage(float v)
    {
        if (voltageText != null) voltageText.text = $"Tension : {v:F1} V";
    }

    public void ToggleCircuit()
    {
        float tension = voltageSlider != null ? voltageSlider.value : 0f;
        bool on = tension >= thresholdVoltage;

        // change material
        if (bulbRenderer != null)
            bulbRenderer.material = on ? bulbOnMat : bulbOffMat;

        // play particles & sound when turning ON
        if (on)
        {
            if (onParticles != null)
            {
                onParticles.transform.position = bulbRenderer != null ? bulbRenderer.transform.position + Vector3.up * 0.12f : onParticles.transform.position;
                onParticles.Play();
            }
            if (audioSource != null) audioSource.Play();
            ShowFeedback("Bravo ! Le circuit est fermé.", true);
        }
        else
        {
            ShowFeedback("Tension insuffisante. Essaie >= 5 V.", false);
        }
    }

    void ShowFeedback(string message, bool positive)
    {
        if (feedbackText == null) return;
        feedbackText.text = message;
        feedbackText.color = positive ? new Color(0.15f,0.7f,0.2f) : new Color(0.9f,0.25f,0.25f);
        // start auto-hide coroutine
        StopAllCoroutines();
        StartCoroutine(HideFeedbackAfter(2.0f));
    }

    IEnumerator HideFeedbackAfter(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (feedbackText != null) feedbackText.text = "";
    }
}
