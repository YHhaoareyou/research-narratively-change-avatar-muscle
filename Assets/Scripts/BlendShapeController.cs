using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeController : MonoBehaviour
{
    private static readonly int _maleMeshesCount = 6;
    private static readonly int _femaleMeshesCount = 10;
    //private static readonly int _femaleMeshesCount = 1;
    private static readonly float _minMuscleWeight = 0;
    private static readonly float _maxMuscleWeight = 150;
    private static readonly float _baseGrabWeight = 100;
    private static readonly float _minGrabWeight = 0;
    private static readonly float _maxGrabWeight = 100;
    private static readonly string[] _maleMeshNames = { "Body", "Jeans", "Eye", "EyeOcclusion", "TearLine", "Hair" };
    private static readonly string[] _femaleMeshNames = { "Body", "Top", "Shorts", "Eye", "EyeOcclusion", "TearLine", "Real_Hair", "Hair_Base", "Bun", "Bang" };
    //private static readonly string[] _femaleMeshNames = { "Body" };

    [SerializeField][Range(0f, 100f)] private float MuscleWeight = _minMuscleWeight;
    [SerializeField][Range(0f, 200f)] private float GrabWeight = _baseGrabWeight;
    [SerializeField] private bool IsMuscleFixed = false;
    [SerializeField] private bool isDebug = false;
    [SerializeField] private bool isMale = true;
    [SerializeField] private GameObject avatar;

    private static bool isMuscleFixed = false;
    private static int meshesCount;
    private static int[] armatureIndexes;
    private static int handGrabIndex;
    private static float muscleWeight = _minMuscleWeight;
    private static float grabWeight = _baseGrabWeight;
    private static SkinnedMeshRenderer[] meshes;
    private static SkinnedMeshRenderer bodyMesh = new SkinnedMeshRenderer();

    private string[] meshNames;
    private bool isStarted = false;

    // Start is called before the first frame update
    void Awake()
    {
        meshNames = isMale ? _maleMeshNames : _femaleMeshNames;
        meshesCount = isMale ? _maleMeshesCount : _femaleMeshesCount;

        armatureIndexes = new int[meshesCount];
        meshes = new SkinnedMeshRenderer[meshesCount];

        for (int i = 0; i < meshesCount; i++)
        {
            meshes[i] = avatar.transform.Find(meshNames[i]).GetComponent<SkinnedMeshRenderer>();
            armatureIndexes[i] = meshes[i].sharedMesh.GetBlendShapeIndex("Muscle");
            //armatureIndexes[i] = meshes[i].sharedMesh.GetBlendShapeIndex("TEST");
        }

        bodyMesh = meshes[0];
        handGrabIndex = bodyMesh.sharedMesh.GetBlendShapeIndex("Grab");

        isStarted = true;
    }

    void Start()
    {
        isMuscleFixed = IsMuscleFixed;
        muscleWeight = MuscleWeight;
        grabWeight = GrabWeight;

        SetWeightFromEditor();
    }

    void Update()
    {

    }

    void OnValidate()
    {
        isMuscleFixed = IsMuscleFixed;
        if ((isDebug || isMuscleFixed) && isStarted)
        {
            muscleWeight = MuscleWeight;
            grabWeight = GrabWeight;
            SetWeightFromEditor();
        }
        
    }

    void SetWeightFromEditor()
    {
        for (int i = 0; i < meshesCount; i++)
        {
            meshes[i].SetBlendShapeWeight(armatureIndexes[i], muscleWeight);
        }

        bodyMesh.SetBlendShapeWeight(handGrabIndex, grabWeight);
    }

    public static void GrowMuscle(float addedWeight)
    {
        if (isMuscleFixed) return;
        if ((muscleWeight < _maxMuscleWeight) || (addedWeight < 0))
        {
            muscleWeight += addedWeight;
            for (int i = 0; i < meshesCount; i++)
            {
                meshes[i].SetBlendShapeWeight(armatureIndexes[i], muscleWeight);
            }

            SetGrab(true);
        }
    }

    public static void SetGrab(bool isActive)
    {
        grabWeight = isActive ? _baseGrabWeight + muscleWeight / 2 : _minGrabWeight;
        bodyMesh.SetBlendShapeWeight(handGrabIndex, grabWeight);
    }
}
