using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField]
    Transform _gaugeBar = null;

    public float Ratio
    {
        get; set;
    }

    public void SetGaugeBar(float ratio)
	{
        ratio = Mathf.Clamp(ratio, 0, 1);
        Ratio = ratio;
        _gaugeBar.localScale = new Vector3(ratio, 1, 1);
	}

}
