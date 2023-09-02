using System;
using UnityEngine;

/// <summary>
/// Represents a single hittable entity
/// </summary>
public interface IHittable
{
    void ReceiveHit(float damage, Vector3 force);
}

public interface IShootable
{
    /// <summary>
    /// Origin, Direction
    /// </summary>
    event Action<Vector3, Vector3> OnShoot;
    /// <summary>
    /// Origin, Target Position
    /// </summary>
    event Action<Vector3, Vector3> OnShootAtTarget;
} 