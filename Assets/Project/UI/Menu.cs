using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button playGame;
    public TextMeshProUGUI bestScore;
    public Transform leftWall;
    public Transform rightWall;
    public Transform radiusLeftLimit;
    public Transform radiusRightLimit;
    public float floatLimit;
    public float floatRadiusLimit;
    // Start is called before the first frame update
    private void Awake()
    {
        SetUpPositionLimitWallIngame();
    }
    private void OnEnable()
    {
        SetupButton();
        SetupScore();
    }
    public void SetupButton()
    {
        playGame.onClick.AddListener(() =>
        {
            //chueyenr towsi sate gameplay
            GameStateManager.Instance.GameStateChange(GameStateInstance.gamplayState);
        });

    }

    public void SetupScore()
    {
        bestScore.text = SaveManager.LoadPoint().ToString();

    }
    //hàm điều chỉnh lại kích thước của các object mép trái và phải
    public void SetUpPositionLimitWallIngame()
    {
        //camera
        Camera cam = Camera.main;
        //timf kiếm vị trí viewport và convert sang tạo đọ thế giới
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, cam.nearClipPlane));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, cam.nearClipPlane));
        //bây giờ vị trí của 2 bức tường trái phải sẽ dc resert lại thông qua 2 vector trên
        leftWall.transform.position = new Vector3(leftEdge.x + floatLimit, 0.5f, -1);
        rightWall.transform.position = new Vector3(rightEdge.x - floatLimit, 0.5f, -1);
        

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
