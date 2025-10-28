using System;
using UnityEngine;
public class PowerUpEventManager : MonoBehaviour
{
    public static event Action OnTripleShotActivated;
    public static event Action OnTripleShotDesactivated;
    public static event Action OnShieldActivated;

    public static void TriggerTripleShotActivated()
    {
        OnTripleShotActivated?.Invoke();
    }
    public static void TriggerTripleShotDesactivated()
    {
        OnTripleShotDesactivated?.Invoke();
    }

    public static void TriggerShield()
    {
        OnShieldActivated?.Invoke();
    }
}
