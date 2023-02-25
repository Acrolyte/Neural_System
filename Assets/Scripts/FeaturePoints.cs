using System;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using TMPro;

public class FeaturePoints : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;
    public GameObject brain;
    public UnitValues unitValues;

    public GameObject panel;
    public TextMeshProUGUI heading_text, description_text;

    private bool panelIsVisible = false;
    public int PanelTime = 5;
    private float counter = 0;
        
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

        if (panelIsVisible)
        {
            panel.SetActive(true);
            Debug.Log($"Panel is visible for: {gameObject.name}");
            counter -= Time.smoothDeltaTime;
            Debug.Log(counter.ToString());
            if (counter < 0)
            {
                panel.SetActive(false);
                panelIsVisible = false;
            }
        }
        else panel.SetActive(false);
    }

    public void FocusPart()
    {
        Debug.Log(unitValues.partName);
        brain.transform.localRotation = Quaternion.Euler(unitValues.rotationValues);
        Debug.Log(unitValues.description);
        counter = PanelTime;
        panelIsVisible = true;

        panel.GetComponent<RectTransform>().position = new Vector3(rectTransform.position.x,rectTransform.position.y - 230, rectTransform.position.z);
        heading_text.text = unitValues.partName;
        description_text.text = unitValues.description;
    }
    
}