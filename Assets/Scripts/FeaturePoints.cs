using System;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


public class FeaturePoints : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;
    public GameObject brain;
    public UnitValues unitValues;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        image.enabled = false;
    }

    private void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.zero);
        // Debug.Log($"{gameObject.name} is at {distanceFromCenter}");
        var show = distanceFromCenter > 0.2f;
        image.enabled = show;

    }

    public void FocusPart()
    {
        Debug.Log(unitValues.partName);
        brain.transform.SetPositionAndRotation(brain.transform.position,Quaternion.Euler(unitValues.rotationValues));
        Debug.Log(unitValues.description);
    }
}