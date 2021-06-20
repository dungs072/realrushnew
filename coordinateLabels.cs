using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class coordinateLabels : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color (1f,0.5f,0f);
    GridManager gridManager;
    WayPoint wayPoint;
    // Start is called before the first frame update
    void Awake()
    {
        wayPoint = FindObjectOfType<WayPoint>();
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        DisPlayCoordinates();
        label.enabled = label.IsActive();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisPlayCoordinates();
            updateObjectName();
            label.enabled = true;
        }
        setLabelColor();
        toggleLabel();
    }
    void toggleLabel()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    void setLabelColor()
    {
        if(gridManager == null)
        {
            return;
        }
        Node node = gridManager.GetNode(coordinates);
        if(node == null)
        {
            return;
        }
        if(!node.isWalkable)
        {
            label.color = blockColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else 
        {
            label.color = defaultColor;
        }
    }
    void DisPlayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 5);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 5);
        label.text = coordinates.x + "," + coordinates.y;
    }
    void updateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
