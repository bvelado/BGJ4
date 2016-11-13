using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HealthBarUI : MonoBehaviour {
    
    [SerializeField]
    private RectTransform m_fill;
    private float m_fillWidth;

    Sequence seq;

    private float fill;
    protected float Fill
    {
        get
        {
            return Fill;
        }
        set
        {
            fill = Mathf.Clamp(value, 0f, 1f);
            UpdateHealthBarView(fill);
        }
    }

	void Start () {
        m_fillWidth = m_fill.sizeDelta.x;
	}

    void HealthChanged(float value)
    {
        if (seq.IsPlaying())
            seq.Kill();

        seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => fill, x => Fill = x, value, 1f));
        seq.Play();
    }

    void UpdateHealthBarView(float value)
    {
        m_fill.anchoredPosition = new Vector3(value * (m_fillWidth) * -1f, 0f);
    }
}
