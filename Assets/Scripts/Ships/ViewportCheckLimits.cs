using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportCheckLimits : ICheckLimits
{
    private Camera _camera;
    private Transform _transform;
    
    public ViewportCheckLimits(Camera camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }
    
    public void ClampPosition()
    {
        Vector3 viewportPoint = _camera.WorldToViewportPoint(_transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
        _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }
}
