using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetBarValue(float newValue)
    {
        image.fillAmount = newValue/100f;
    }       
    
}

