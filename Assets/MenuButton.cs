using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler {
    private Button m_button;
    private Text m_text;
    private Image m_icon;
    private Image m_cursor;

    [SerializeField]
    private Color SelectedColor;
    [SerializeField]
    private Color NormalColor;

    Sequence m_sequence;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_text = transform.FindChild("Text").GetComponent<Text>();
        m_icon = transform.FindChild("Icon").GetComponent<Image>();
        m_cursor = transform.FindChild("Cursor").GetComponent<Image>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        m_sequence.Kill();

        m_sequence = DOTween.Sequence();
        m_sequence
            .Append(m_cursor.DOFade(1f, .4f))
            .Insert(0f, m_text.DOColor(SelectedColor, .4f))
            .Insert(0f, m_icon.DOFade(1f, .4f))
            .Insert(0f, m_text.GetComponent<RectTransform>().DOAnchorPosX(62f, .4f));
        m_sequence.Play();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        m_sequence.Kill();

        m_sequence.Kill();

        m_sequence = DOTween.Sequence();
        m_sequence
            .Append(m_cursor.DOFade(0f, .4f))
            .Insert(0f, m_text.DOColor(NormalColor, .4f))
            .Insert(0f, m_icon.DOFade(0f, .4f))
            .Insert(0f, m_text.GetComponent<RectTransform>().DOAnchorPosX(20f, .4f));
        m_sequence.Play();
    }
}
