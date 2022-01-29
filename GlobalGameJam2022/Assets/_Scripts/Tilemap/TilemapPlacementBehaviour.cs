using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPlacementBehaviour : MonoBehaviour
{
    public Tilemap PlacableTilemap;


    TooltipManager tooltipManager;
    Vector3 rotationVector = new Vector3(0, 0, -90);

    // Start is called before the first frame update
    void Start()
    {
        PlacableTilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        tooltipManager = TooltipManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        Vector3Int cellPosition = PlacableTilemap.LocalToCell(hit.point);
        transform.position = PlacableTilemap.GetCellCenterLocal(cellPosition);

        if (Input.GetMouseButtonDown(0))
        {
            tooltipManager.HidePlacementToolTip();
            tooltipManager.ShowIntroToolTip();
            //Place Object
            Destroy(this.gameObject);
        }
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(rotationVector);
        }
    }
}
