using System;
using UnityEngine;


    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Displacement/Vortex")]
    public class VortexEdited : ImgEffectBase
{
        public Vector2 radius = new Vector2(0.8F,0.8F);
        public float angle = 50;
        public Vector2 center = new Vector2(0.5F, 0.5F);


    private GameWorld gameWorld;
    // Called by camera to apply image effect
    private void Start()
    {
        gameWorld = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameWorld>();

    }


    void OnRenderImage (RenderTexture source, RenderTexture destination)
        {

        if (gameWorld.splash == true)
            ImageEffects.RenderDistortion(material, source, destination, angle, center, radius);
        else
        {
            Graphics.Blit(source, destination);
            radius = new Vector2(0.8F, 0.8F);
        }
    }
}

