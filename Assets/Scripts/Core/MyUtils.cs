using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public static class MyUtils
{
    public static void CopyTransform(Transform source, Transform target)
    {
        target.transform.position = source.transform.position;
        target.transform.rotation = source.transform.rotation;
        target.transform.localScale = source.transform.localScale;

    }

    public static bool TryRaycast<T>(Transform from, float distance, out RaycastHit hitInfo, out T hitted)
    {
        Ray ray = new Ray(from.position, from.forward);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.TryGetComponent(out T other))
            {
                hitted = other;
                return true;
            }
        }
        hitted = default;
        return false;
    }

    public static bool TryRaycast<T>(Vector3 position, Vector3 direction, float distance, out RaycastHit hitInfo, out T hitted)
    {
        Ray ray = new Ray(position, direction);

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.TryGetComponent(out T other))
            {
                hitted = other;
                return true;
            }
        }
        hitted = default;
        return false;
    }
}