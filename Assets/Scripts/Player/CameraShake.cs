using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;  // Durata dell'effetto di vibrazione
    public float shakeMagnitude = 0.0001f; // Intensità della vibrazione
    public float dampingSpeed = 1.0f;   // Velocità con cui si ferma la vibrazione
    public Transform cameraTransform;   // Il Transform della camera da far vibrare

    private Vector3 initialPosition;    // Posizione iniziale della camera
    private float currentShakeDuration = 0f; // Timer interno per la durata della vibrazione

    private void Start()
    {
        // Se il Transform della camera non è assegnato, usa quello della GameObject corrente
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
        initialPosition = cameraTransform.localPosition; // Salva la posizione iniziale
    }

    private void Update()
    {
        // Se c'è vibrazione attiva, applica lo shake
        if (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            // Diminuisce il timer e lo ferma gradualmente
            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            // Quando lo shake è finito, riporta la camera alla posizione originale
            currentShakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }

    // Metodo per avviare l'effetto di vibrazione
    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
    }
}
