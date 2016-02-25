using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour {

    public GameObject player;
    public GameObject TextBubbleGo;
    public GameObject TextMeshGo;
    public GameObject LineRendererGo;

    Text textMesh;
    LineRenderer LineRenderer;

    Vector3 triangleOffset;

	// Use this for initialization
	void Start () {
        textMesh = TextMeshGo.GetComponent<Text>();
        /*
        LineRenderer = LineRendererGo.GetComponent<LineRenderer>();

        Image ChatBubbleImage = TextBubbleGo.GetComponent<Image>();
        RectTransform chatRect = ChatBubbleImage.rectTransform;
        triangleOffset = new Vector3(chatRect.rect.width , chatRect.rect.height, 0);
        GameObject chatTail = new GameObject();
        chatTail.transform.parent = player.transform;
        chatTail.transform.localPosition = Vector3.zero;

        chatTail.AddComponent<MeshFilter>();
        chatTail.AddComponent<MeshRenderer>();
        Mesh mesh = chatTail.GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = new Vector3[] {
            new Vector3(-4 + TextBubbleGo.transform.position.x + triangleOffset.x, TextBubbleGo.transform.position.y - triangleOffset.y, TextBubbleGo.transform.position.z),
            new Vector3(TextBubbleGo.transform.position.x + triangleOffset.x, TextBubbleGo.transform.position.y - triangleOffset.y, TextBubbleGo.transform.position.z),
           player.transform.position };

        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.triangles = new int[] { 0,1,2};
        */
        /*
        Vector3[] positions = new Vector3[3];

        positions[0] = TextBubbleGo.transform.position;
        positions[1] = TextBubbleGo.transform.position;
        positions[2] = player.transform.position;

        LineRenderer.SetPositions(positions);
        */
    }
	
	// Update is called once per frame
	void Update () {
        /*
        Vector3[] positions = new Vector3[3];

        positions[0] = TextBubbleGo.transform.position;
        positions[1] = TextBubbleGo.transform.position;
        positions[2] = player.transform.position;

        LineRenderer.SetPositions(positions);
        */
    }
}
