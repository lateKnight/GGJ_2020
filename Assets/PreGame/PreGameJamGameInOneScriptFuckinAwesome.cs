using UnityEngine;
public class PreGameJamGameInOneScriptFuckinAwesome : MonoBehaviour
{
    [SerializeField] private GameObject player;
	[SerializeField] private GameObject platformPrefab;
    [SerializeField] private float movementSpeed = .25f;
    [SerializeField] private float platformCount = 100;
    [SerializeField] private float platformDistance = 5;
	[SerializeField] private UnityEngine.UI.Text scoreText;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
    }

    private void ControlPlayer()
    {
        float input = Input.GetAxis("Horizontal");
        float airModifier = IsGrounded() ? 1 : 0.5f;
        player.transform.Translate(Vector3.right * ((input * movementSpeed) * airModifier));
    }

    private bool IsGrounded(){
        if(Physics.Raycast(player.transform.position, Vector3.down, 1))
        {
            return true;
        }
        else{
            return false;
        }
    }

    private void ControlCamera()
    {
        Camera.main.transform.LookAt(player.transform);
    }

    private void SpawnPlatforms()
    {
        for(int i = 0; i < platformCount; i++)
        {
            Vector3 platformPosition = new Vector3(
                Random.Range(-platformDistance, platformDistance),
                (-5 * (i + 1)),
                0
            );  
            GameObject platform = UnityEngine.GameObject.Instantiate(platformPrefab, platformPosition, Quaternion.identity) as GameObject;
            platform.GetComponent<MeshRenderer>().material.color = GetRandomColor(Random.Range(0,1));
			platform.transform.localScale = new Vector3(
				Random.Range(2, 7),
				platform.transform.localScale.y,
				platform.transform.localScale.z
			);
			if (i == platformCount - 1)
            {
                platform.GetComponent<Platform>().isFinish = true;
				platform.transform.localScale = new Vector3(
					100,
					platform.transform.localScale.y,
					platform.transform.localScale.z
				);
            }

        }
    }

    private Color GetRandomColor(float t){
        return Random.ColorHSV();
    }

    public void IncreaseScore()
    {
        score++;
		scoreText.text = score.ToString();

    }
}
