using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

[ExecuteInEditMode] // 편집 모드에서 테스트하기 위해 편집 모드에서 실행 추가
public class ChaseAgent : MonoBehaviour
{
    public float distance = 10f;
    public float angle = 30f;
    public float height = 1.0f;
    public Color meshColor = Color.red;
    public int scanFrequency = 30; // 스캔 주기
    public LayerMask layers;
    public LayerMask occulusionLayers;
    public List<GameObject> Objects = new List<GameObject>();

    private Collider[] _colliders = new Collider[50];
    private Mesh _mesh;
    private int _count;
    public float _scanInterval = 1f;
    public float _scanTimer = 0.5f;

    private DOTweenPath _doTweenPath;
    void Start()
    {
        _doTweenPath = GetComponent<DOTweenPath>();
        _scanInterval = 1.0f / scanFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        _scanTimer -= Time.deltaTime;
        if (_scanTimer < 0)
        {
            _scanTimer += _scanInterval;
            Scan();
        }
    }

    private void Scan()
    {
        _count = Physics.OverlapSphereNonAlloc(transform.position, distance, _colliders, layers,
            QueryTriggerInteraction.Collide);
        Objects.Clear();
        transform.DOPause();
        for (int i = 0; i < _count; i++)
        {
            GameObject obj = _colliders[i].gameObject;
            if (IsInSight(obj))
            {
                Objects.Add(obj);
                ChasePlayer(obj);
            }
        }
    }

    private void ChasePlayer(GameObject playerObj)
    {
        _doTweenPath.DOPause();
        transform.DOMove(playerObj.transform.position, 5f);
    }
    public bool IsInSight(GameObject obj)
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;
        if (direction.y < -0.3 ||direction.y > height/2)
        {
            return false;
        }

        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if (deltaAngle > angle)
        {
            return false;
        }

        origin.y += height / 2;
        dest.y = origin.y;
        if (Physics.Linecast(origin,dest, occulusionLayers))
        {
            return false;
        }
        return true;
    }
    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        // 삼각형 정점의 수 3개
        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero +Vector3.down * height/2;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance +Vector3.down * height/2;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance +Vector3.down * height/2;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;

        int vert = 0;

        // left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        // right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;
        for (int i = 0; i < segments; i++)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance +Vector3.down * height/2;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance +Vector3.down * height/2;

            topLeft = bottomLeft + Vector3.up * height;
            topRight = bottomRight + Vector3.up * height;

            // far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            // top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            // bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }


        for (int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        _mesh = CreateWedgeMesh();
    }

    private void OnDrawGizmos()
    {
        if (_mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(_mesh, transform.position, transform.rotation);
        }
        
        Gizmos.DrawWireSphere(transform.position, distance);
        for (int i = 0; i < _count; i++)
        {
            Gizmos.DrawSphere(_colliders[i].transform.position + Vector3.up, 0.2f);
        }

        Gizmos.color = Color.green;
        foreach (var obj in Objects)
        {
            Gizmos.DrawSphere(obj.transform.position+ Vector3.up, 0.2f);
        }
    }
}