using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheFirstPerson;

public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina Variables")]
    public float maxStamina;
    [Tooltip("Amount of time after using stamina, regen will start")]
    public float regenCooldown = 1;
    [Tooltip("How much stamina is used every tick")]
    public float staminaCostPerTick = 1f;
    [Tooltip("How much stamina is regenerated every tick")]
    public float regenPerTick = 0.1f;
    [Tooltip("Time it takes to fade in and out the slider")]
    public float fadeInOutTime = 0.5f;


    public float CurrentStamina
    {
        get { return currentStamina; }
    }

    [SerializeField]
    private Slider slider;

    private float currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);
    private Coroutine regen;
    private CanvasGroup canvasGroup;
    private float regenTickRate = 0.01f;


    private void Awake()
    {
        regenTick = new WaitForSeconds(regenTickRate);
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
        currentStamina = maxStamina;
        canvasGroup = slider.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        FadeOutStaminaBar();
    }

    /// <summary>
    /// Returns true if there is enough stamina left
    /// </summary>
    /// <returns></returns>
    private bool CheckStamina(float amt)
    {
        return currentStamina <= amt;
    }

    private void UpdateUI()
    {
        slider.value = currentStamina;
    }

    /// <summary>
    /// Checks if there is enough stamina, and uses it if true
    /// </summary>
    /// <param name="amt">Amount to be use</param>
    /// <returns></returns>
    public bool UseStamina(float amt=1f)
    {
        FadeInStaminaBar();

        if (CheckStamina(amt))
            return false;
        currentStamina -= amt;

        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(RegenStamina());
        UpdateUI();
        return true;
    }

    public void FadeInStaminaBar()
    {
        if(canvasGroup.alpha != 1)
            canvasGroup.LeanAlpha(1, fadeInOutTime);
    }

    public void FadeOutStaminaBar()
    {
        if(canvasGroup.alpha == 1)
            canvasGroup.LeanAlpha(0, fadeInOutTime);
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(regenCooldown);
        while (currentStamina < maxStamina)
        {
            currentStamina += regenPerTick;
            UpdateUI();
            yield return regenTick;
        }
        FadeOutStaminaBar();
    }
}