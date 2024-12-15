using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelWorldGenerator : MonoBehaviour
{
    [Header("World Settings")]
    public int worldSize = 100;
    public int chunkSize = 10;
    public float noiseScale = 20f;
    public float heightMultiplier = 5f;
    public int seed = 1234;

    [Header("Player Settings")]
    public Transform player;
    public int loadRadius = 50;

    [Header("Environment Settings")]
    public GameObject[] environmentPrefabs;
    public float objectDensity = 0.1f;

    [Header("Biomes")]
    public Biome[] biomes;

    [System.Serializable]
    public class Biome
    {
        public string name;
        public GameObject[] prefabs;
        public float minHeight;
        public float maxHeight;
    }

    private Dictionary<Vector3Int, GameObject> voxelChunks = new Dictionary<Vector3Int, GameObject>();
    private HashSet<Vector3Int> generatingChunks = new HashSet<Vector3Int>();

    void Start()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not assigned and not found in the scene. Please assign a player.");
            }
        }

        if (player != null)
        {
            StartCoroutine(GenerateChunksAroundPlayer());
        }
    }

    void Update()
    {
        if (player != null)
        {
            StartCoroutine(GenerateChunksAroundPlayer());
        }
    }

    private IEnumerator GenerateChunksAroundPlayer()
    {
        Vector3Int playerChunk = GetChunkPosition(player.position);

        for (int x = -loadRadius; x <= loadRadius; x += chunkSize)
        {
            for (int z = -loadRadius; z <= loadRadius; z += chunkSize)
            {
                Vector3Int chunkPosition = playerChunk + new Vector3Int(x, 0, z);

                if (!voxelChunks.ContainsKey(chunkPosition) && !generatingChunks.Contains(chunkPosition))
                {
                    generatingChunks.Add(chunkPosition);
                    yield return StartCoroutine(GenerateVoxelChunkAsync(chunkPosition));
                }
            }
        }
    }

    private Vector3Int GetChunkPosition(Vector3 position)
    {
        return new Vector3Int(
            Mathf.FloorToInt(position.x / chunkSize) * chunkSize,
            0,
            Mathf.FloorToInt(position.z / chunkSize) * chunkSize
        );
    }

    private IEnumerator GenerateVoxelChunkAsync(Vector3Int chunkPosition)
    {
        GameObject chunk = new GameObject("Voxel Chunk");
        chunk.transform.position = chunkPosition;

        MeshFilter meshFilter = chunk.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = chunk.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        for (int x = 0; x < chunkSize; x++)
        {
            for (int z = 0; z < chunkSize; z++)
            {
                int worldX = chunkPosition.x + x;
                int worldZ = chunkPosition.z + z;
                float height = Mathf.PerlinNoise((worldX + seed) / noiseScale, (worldZ + seed) / noiseScale) * heightMultiplier;

                for (int y = 0; y < height; y++)
                {
                    Vector3 voxelPosition = new Vector3(x, y, z);
                    AddVoxelToChunk(vertices, triangles, voxelPosition);
                }
            }
            yield return null;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        MeshCollider meshCollider = chunk.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;

        voxelChunks.Add(chunkPosition, chunk);
        generatingChunks.Remove(chunkPosition);

        PlaceEnvironment(chunk, chunkPosition);
    }

    private void AddVoxelToChunk(List<Vector3> vertices, List<int> triangles, Vector3 position)
    {
        int startIndex = vertices.Count;

        vertices.Add(position + new Vector3(0, 0, 0));
        vertices.Add(position + new Vector3(1, 0, 0));
        vertices.Add(position + new Vector3(1, 1, 0));
        vertices.Add(position + new Vector3(0, 1, 0));
        vertices.Add(position + new Vector3(0, 0, 1));
        vertices.Add(position + new Vector3(1, 0, 1));
        vertices.Add(position + new Vector3(1, 1, 1));
        vertices.Add(position + new Vector3(0, 1, 1));

        triangles.AddRange(new int[] {
            startIndex + 0, startIndex + 2, startIndex + 1, startIndex + 0, startIndex + 3, startIndex + 2,
            startIndex + 4, startIndex + 5, startIndex + 6, startIndex + 4, startIndex + 6, startIndex + 7,
            startIndex + 0, startIndex + 1, startIndex + 5, startIndex + 0, startIndex + 5, startIndex + 4,
            startIndex + 2, startIndex + 3, startIndex + 7, startIndex + 2, startIndex + 7, startIndex + 6,
            startIndex + 1, startIndex + 2, startIndex + 6, startIndex + 1, startIndex + 6, startIndex + 5,
            startIndex + 3, startIndex + 0, startIndex + 4, startIndex + 3, startIndex + 4, startIndex + 7
        });
    }

    private void PlaceEnvironment(GameObject chunk, Vector3Int chunkPosition)
    {
        if (biomes == null || biomes.Length == 0) return;

        int numObjects = Mathf.FloorToInt(chunkSize * chunkSize * objectDensity);

        for (int i = 0; i < numObjects; i++)
        {
            float x = Random.Range(0, chunkSize);
            float z = Random.Range(0, chunkSize);
            int worldX = chunkPosition.x + Mathf.FloorToInt(x);
            int worldZ = chunkPosition.z + Mathf.FloorToInt(z);

            float height = Mathf.PerlinNoise((worldX + seed) / noiseScale, (worldZ + seed) / noiseScale) * heightMultiplier;

            Biome biome = GetBiome(height);
            if (biome == null || biome.prefabs.Length == 0) continue;

            GameObject prefab = biome.prefabs[Random.Range(0, biome.prefabs.Length)];
            Vector3 position = new Vector3(chunkPosition.x + x, height, chunkPosition.z + z);

            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            obj.transform.SetParent(chunk.transform);
        }
    }

    private Biome GetBiome(float height)
    {
        foreach (var biome in biomes)
        {
            if (height >= biome.minHeight && height <= biome.maxHeight)
                return biome;
        }
        return null;
    }
}
