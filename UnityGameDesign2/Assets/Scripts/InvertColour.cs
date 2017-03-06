using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Camera))]
[AddComponentMenu("Hidden/invertColour")]
public class InvertColour : MonoBehaviour {

    /// Provides a shader property that is set in the inspector
    /// and a material instantiated from the shader
    public Shader shader;

    private Material m_Material;

	private GameWorld gameWorld;
    protected virtual void Start()
    {
		gameWorld = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameWorld>();

		// Disable if we don't support image effects
		if (!SystemInfo.supportsImageEffects)
        {
            Debug.Log("Dont support Image effects");
            enabled = false;
            return;
        }

        // Disable the image effect if the shader can't
        // run on the users graphics card
        if (!shader || !shader.isSupported)
        {
            Debug.Log("Shader Cannot run on GPU");

            enabled = false;
        }
    }


    protected Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(shader);
                m_Material.hideFlags = HideFlags.HideAndDontSave;
            }
            return m_Material;
        }
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
       
		if(gameWorld.backwards == true)
		{
			Graphics.Blit(source, destination, material);

		}
		else {
			Graphics.Blit(source, destination);

		}
	}



    protected virtual void OnDisable()
    {
        if (m_Material)
        {
            DestroyImmediate(m_Material);
        }
    }
}
