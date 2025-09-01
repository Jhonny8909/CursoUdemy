using System;
using UnityEngine;
public class PowerUpEventManager : MonoBehaviour
{
    // Evento para activar Triple Shot
    public static event Action OnTripleShotActivated;
    public static event Action OnTripleShotDesactivated;

    // Evento para activar Shield
    public static event Action OnShieldActivated;

    // ---- MÉTODOS PARA INVOCAR LOS EVENTOS ----
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
