using UnityEngine;
using UnityEngine.UI;

public class RedScreenEffect : MonoBehaviour
{
    public Image redScreenImage;
    public float fadeSpeed = 1.5f;

    private float currentAlpha = 0f;
    private bool shouldFadeIn = false;

    private void Start()
    {
        redScreenImage = GetComponent<Image>();
    }

    void Update()
    {
        //Using interpolation to fade the red screen in
        currentAlpha = Mathf.Lerp(currentAlpha, shouldFadeIn ? 1f : 0f, Time.deltaTime * fadeSpeed);
        Color c = redScreenImage.color;
        c.a = currentAlpha;
        redScreenImage.color = c;
    }

    public void RedScreenOn()
    {
        shouldFadeIn = true;
    }

    public void RedScreenOff()
    {
        shouldFadeIn = false;
    }
}
