using System;
using UnityEngine;
using UnityEngine.UI;


public class FeaturePoints : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one);

        var show = distanceFromCenter < 0.85f;
        image.enabled = show;
    }
}