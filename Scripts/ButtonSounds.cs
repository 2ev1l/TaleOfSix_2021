using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
      DDONLOAD.soundData4.Play();
    }

    public void OnSelect(BaseEventData eventData)
    {
      DDONLOAD.soundData3.Play();
    }
}
