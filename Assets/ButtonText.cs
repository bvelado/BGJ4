using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class ButtonText : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Button m_button;
    private Text m_text;
    private Image m_icon;

    [SerializeField]
    private Color SelectedColor;
    [SerializeField]
    private Color NormalColor;

    Sequence m_sequence;

    void Start()
    {
        m_button = GetComponent<Button>();
        m_text = GetComponentInChildren<Text>();
        m_icon = transform.FindChild("Icon").GetComponent<Image>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        m_sequence.Kill();

        m_sequence = DOTween.Sequence();
        m_sequence.Insert(0f, m_text.DOColor(SelectedColor, .4f))
            .Insert(0f, m_icon.DOFade(1f, .4f))
            .Append(this.GetComponent<RectTransform>().DOAnchorPosX(18f, .4f));
        m_sequence.Play();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        m_sequence.Kill();

        m_sequence.Kill();

        m_sequence = DOTween.Sequence();
        m_sequence.Insert(0f, m_text.DOColor(NormalColor, .4f))
            .Insert(0f, m_icon.DOFade(0f, .4f))
            .Append(this.GetComponent<RectTransform>().DOAnchorPosX(0f, .4f));
        m_sequence.Play();
    }
}
