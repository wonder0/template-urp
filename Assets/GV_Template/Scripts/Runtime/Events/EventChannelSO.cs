using UnityEngine;
using System;


/// <summary>
/// A generic ScriptableObject-based event channel for broadcasting events with a payload of type <typeparamref name="T"/>.
/// 
/// This event system enables decoupled communication between game systems by allowing event "listeners" 
/// to subscribe to and respond to events raised by "senders", without needing direct references between them.
/// 
/// This class is abstract and must be subclassed (e.g., IntEventChannelSO, StringEventChannelSO) to be 
/// usable in the Unity Editor, due to Unity's lack of support for generic ScriptableObject instantiation.
///
/// Example usage:
/// 
/// 1. Create a concrete subclass:
///     [CreateAssetMenu(menuName = "Events/Int Event Channel")]
///     public class IntEventChannelSO : EventChannelSO<int> { }
/// 
/// 2. Create a ScriptableObject asset in the Project window (e.g., "OnScoreChanged").
/// 
/// 3. In a script that raises the event:
///     [SerializeField] private IntEventChannelSO onScoreChanged;
///     onScoreChanged.RaiseEvent(10);
/// 
/// 4. In a script that listens to the event:
///     [SerializeField] private IntEventChannelSO onScoreChanged;
///     void OnEnable() => onScoreChanged.RegisterListener(HandleScore);
///     void OnDisable() => onScoreChanged.UnregisterListener(HandleScore);
///     void HandleScore(int newScore) => Debug.Log("Score updated: " + newScore);
/// </summary>


public abstract class EventChannelSO<T> : ScriptableObject
{
    public event Action<T> OnEventRaised;

    public void RaiseEvent(T value)
    {
        OnEventRaised?.Invoke(value);
    }

    public void RegisterListener(Action<T> listener)
    {
        OnEventRaised += listener;
    }

    public void UnregisterListener(Action<T> listener)
    {
        OnEventRaised -= listener;
    }
}
