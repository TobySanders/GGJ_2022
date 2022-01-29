using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacableBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject Placeholder;
    public Image background;
    public Color HoverColour;
    public Transform World;

    Color startColour;
    TooltipManager ttm;


    // Start is called before the first frame update
    void Start()
    {
        startColour = background.color;
        World = GameObject.Find("World").transform;
        ttm = TooltipManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ttm.HideIntroToolTip();
        Instantiate(Placeholder, World);
        background.color = startColour;
        ttm.ShowPlacementToolTip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = HoverColour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = startColour;
    }
}
