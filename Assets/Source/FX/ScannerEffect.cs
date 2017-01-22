using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScannerEffect : MonoBehaviour
{
	[SerializeField] private float _checkRange = 5f;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private Material _effectMaterial;
    private float _scanDistance;
    private Camera _camera;
	private Transform _scannerOrigin;
	private float _halfRange;
    private bool _scanning;
    private Scannable[] _scannables;

    void Start()
    {
        _scannables = FindObjectsOfType<Scannable>();
		_halfRange = _checkRange / 2.0f;
		_scannerOrigin = transform;
    }

    void Update()
    {
        if (_scanning)
        {
            _scanDistance += Time.deltaTime * _speed;

            for (int i = 0; i < _scannables.Length; i++)
            {
				float t = Vector3.Distance(_scannerOrigin.position, _scannables[i].transform.position);

                if (t >= _scanDistance - _halfRange && t <= _scanDistance + _halfRange)
                {
					_scannables[i].Ping();
                }
            }
        }
    }

	public void InitiateScan(Transform origin)
	{
		_scanning = true;
		_scanDistance = 0;
		_scannerOrigin = origin;
	}

    void OnEnable()
    {
        _camera = GetComponent<Camera>();
    }

    [ImageEffectOpaque]
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
		if(!_scannerOrigin) _scannerOrigin = transform;
 
        _effectMaterial.SetVector("_WorldSpaceScannerPos", _scannerOrigin.position);
        _effectMaterial.SetFloat("_ScanDistance", _scanDistance);
        RaycastCornerBlit(src, dst, _effectMaterial);
    }

    void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat)
    {
        // Compute Frustum Corners
        float camFar = _camera.farClipPlane;
        float camFov = _camera.fieldOfView;
        float camAspect = _camera.aspect;

        float fovWHalf = camFov * 0.5f;

        Vector3 toRight = _camera.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
        Vector3 toTop = _camera.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

        Vector3 topLeft = (_camera.transform.forward - toRight + toTop);
        float camScale = topLeft.magnitude * camFar;

        topLeft.Normalize();
        topLeft *= camScale;

        Vector3 topRight = (_camera.transform.forward + toRight + toTop);
        topRight.Normalize();
        topRight *= camScale;

        Vector3 bottomRight = (_camera.transform.forward + toRight - toTop);
        bottomRight.Normalize();
        bottomRight *= camScale;

        Vector3 bottomLeft = (_camera.transform.forward - toRight - toTop);
        bottomLeft.Normalize();
        bottomLeft *= camScale;

        // Custom Blit, encoding Frustum Corners as additional Texture Coordinates
        RenderTexture.active = dest;

        mat.SetTexture("_MainTex", source);

        GL.PushMatrix();
        GL.LoadOrtho();

        mat.SetPass(0);

        GL.Begin(GL.QUADS);

        GL.MultiTexCoord2(0, 0.0f, 0.0f);
        GL.MultiTexCoord(1, bottomLeft);
        GL.Vertex3(0.0f, 0.0f, 0.0f);

        GL.MultiTexCoord2(0, 1.0f, 0.0f);
        GL.MultiTexCoord(1, bottomRight);
        GL.Vertex3(1.0f, 0.0f, 0.0f);

        GL.MultiTexCoord2(0, 1.0f, 1.0f);
        GL.MultiTexCoord(1, topRight);
        GL.Vertex3(1.0f, 1.0f, 0.0f);

        GL.MultiTexCoord2(0, 0.0f, 1.0f);
        GL.MultiTexCoord(1, topLeft);
        GL.Vertex3(0.0f, 1.0f, 0.0f);

        GL.End();
        GL.PopMatrix();
    }
}
