using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Enums;

//MonoBehaviors should be in Asset/Script folder?
namespace ImageLoader
{
    public class ImageTest : MonoBehaviour
    {
        public LoaderData ImageLoaderManager;
        public static LoaderData SpriteSheetLoaderManager;
        public static ImageData imageData;
        public SpriteSheetData spriteSheetData;
        private void Awake() 
        {
            ImageLoaderManager = new TileSpriteImageLoaderManager();
            SpriteSheetLoaderManager = new SpriteSheetImageLoader();
            SceneManager.Instance.Register(this, SceneObjectType.SceneObjectTypeUtilityScript);
        }
        private void Start() 
        {
            //SpritePixelGeneration();
            GetSpriteFromSpriteSheet();
        }   

        public void SpritePixelGeneration()
        {
            TileSpriteImageLoaderManager.Instance.GetImageID("rock1.png", imageData);
            int x = TileSpriteImageLoaderManager.Instance.PNGFile[0].xSize;
            int y = TileSpriteImageLoaderManager.Instance.PNGFile[0].ySize;
            Texture2D texture = new Texture2D(x,
                                              y,
                                              TextureFormat.RGBA32,false );
                                              Debug.Log($"{x} x size; {y} y size");
            int count = 0;
            byte R;
            byte G;  
            byte B;  
            byte A;     
            //we're setting up each pixel's rgba according to the png pixels rgba   
            for(int Y = 0; Y < 16; Y++)
            {
                for(int X = 0; X < 16; X++)
                {
                    R = TileSpriteImageLoaderManager.Instance.PNGFile[0].PixelsArray[count].PixelsRGBA[0]; //GETTING THE RED COLOR BYTE
                    G = TileSpriteImageLoaderManager.Instance.PNGFile[0].PixelsArray[count].PixelsRGBA[1]; //GETTING THE GREEN COLOR BYTE 
                    B = TileSpriteImageLoaderManager.Instance.PNGFile[0].PixelsArray[count].PixelsRGBA[2]; //GETTING THE BLUE COLOR BYTE  
                    A = TileSpriteImageLoaderManager.Instance.PNGFile[0].PixelsArray[count].PixelsRGBA[3]; //GETTING THE ALPHA COLOR BYTE  
                    texture.SetPixel(X,Y, new Color32(R,G,B,A));
                    count++;
                }
            }
            texture.Apply(true);
            Debug.Log($"{texture.GetPixels()} pixels count");
            GameObject.Find("/Canvas/Image").GetComponent<RawImage>().texture = texture;
        }
        public void GetSpriteFromSpriteSheet()
        {
            SpriteSheetImageLoader.Instance.GetSpriteSheetID("spiderDrill_spritesheet.png",spriteSheetData);

            Texture2D texture = new Texture2D(73,
                                              55,
                                              TextureFormat.RGBA32,false );
                                              Debug.Log($"{73} x size; {55} y size");
            int count = 0;
            byte R;
            byte G;  
            byte B;  
            byte A;     
            //we're setting up each pixel's rgba according to the png pixels rgba   
            for(int Y = 0; Y < 55; Y++)
            {
                for(int X = 0; X < 73; X++)
                {
                    R = SpriteSheetImageLoader.Instance.SpriteSheet[0].PixelData[count].PixelsRGBA[0]; //GETTING THE RED COLOR BYTE
                    G = SpriteSheetImageLoader.Instance.SpriteSheet[0].PixelData[count].PixelsRGBA[1]; //GETTING THE GREEN COLOR BYTE 
                    B = SpriteSheetImageLoader.Instance.SpriteSheet[0].PixelData[count].PixelsRGBA[2]; //GETTING THE BLUE COLOR BYTE  
                    A = SpriteSheetImageLoader.Instance.SpriteSheet[0].PixelData[count].PixelsRGBA[3]; //GETTING THE ALPHA COLOR BYTE  
                    texture.SetPixel(X,Y, new Color32(R,G,B,A));
                    count++;
                }
            }
            texture.Apply(true);     
            GameObject.Find("/Canvas/Image").GetComponent<RawImage>().texture = texture;   
        }
    }
}

