using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "NewHapticFeedback", menuName = "ScriptableObjects/Haptic Feedback")]
public class HapticFeedbackData : ScriptableObject
{
    [Range(0f, 1f)] public float lowFrequency = 0.5f;  // Động cơ tần số thấp
    [Range(0f, 1f)] public float highFrequency = 0.5f; // Động cơ tần số cao
    public float duration = 0.2f; // Thời gian rung

}
