using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour 
{
	public float speed = 3f;
	public Transform follow;
	Transform _transform;
    GameStateController battleController;

    [SerializeField] int mapX;
    [SerializeField] int mapY;
    public int offset = -3;

    //[SerializeField] float minX, minY, maxX, maxY;

    // Constrain camera location
    public Vector2 leftBottomMostPoint;
    public Vector2 rightTopMostPoint;
	
	void Awake () {
		_transform = transform;

        //float vertExtent = Camera.main.orthographicSize;
        //float horzExtent = vertExtent * Screen.width / Screen.height;

        //// Calculations assume map is position at the origin
        //minX = horzExtent - mapX / 2.0f;
        //maxX = mapX / 2.0f - horzExtent;
        //minY = vertExtent - mapY / 2.0f;
        //maxY = mapY / 2.0f - vertExtent;
    }

    public void Load(GameStateController b) {
        battleController = b;
        //leftBottomMostPoint = battleController.board.min;
        //rightTopMostPoint = battleController.board.max;

        _transform.position = new Vector3(leftBottomMostPoint.y - offset, leftBottomMostPoint.y - offset, -10);
    }
	
	void Update () {
		if (follow) {
            Vector3 newPos = follow.position;
            newPos.x = Mathf.Clamp(newPos.x, leftBottomMostPoint.x - offset, rightTopMostPoint.x + offset);
            newPos.y = Mathf.Clamp(newPos.y, leftBottomMostPoint.y - offset, rightTopMostPoint.y + offset);
            _transform.position = Vector3.Lerp(_transform.position, newPos, speed * Time.deltaTime);
        }
        _transform.position = new Vector3(_transform.position.x, _transform.position.y, -10);
	}

}