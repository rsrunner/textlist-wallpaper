using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopupAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro whoAmI;
    public Color32 colorFrom;
    public Color32 colorTo;
    public float slowness;
    float timeStarted;
    void Start()
    {
        whoAmI = whoAmI.GetComponent<TextMeshPro>();
        whoAmI.color = colorFrom;
        timeStarted = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        whoAmI.color = Color32.Lerp(colorFrom, colorTo, Mathf.Clamp((Time.time-timeStarted)/slowness, 0, 1));
    }
}
