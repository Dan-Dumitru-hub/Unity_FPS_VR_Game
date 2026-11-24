using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public int depth=20;
    public int width=256;
    public int height=256;
    public float scale=20f;
    public float offsetx;
    public float offsety;


    void Start()
    {

        offsetx = Random.Range(0, 10.0f);
        offsety = Random.Range(0, 10.0f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = Generate(terrain.terrainData);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    TerrainData Generate(TerrainData terraindata){
        terraindata.size=new Vector3(width,depth,height);


        terraindata.heightmapResolution=width+1;
        terraindata.SetHeights(0,0,Generatestart());
        terraindata.SetHeights(0,0,Generatehe());
        return terraindata;

    }

    float [,] Generatehe(){
        float [,]heights = new float[width,height];

        int start=0;
      
       while(start<width-40){
       

        if(Random.Range(0, 10.0f)>5f)
            for(int x=0;x<width;x++){
                
                for(int y=0;y<height;y++){
                /// heights[x,y]=Calculate(x,y);
                heights[x,y]=Random.Range(0f, 0.03f);
                }
                

            }
        start+=40;
    
        }
        return heights;

    }

    float [,] Generatestart(){
        float [,]heights = new float[width,height];
        for(int x=0;x<width;x++){
            for(int y=0;y<height;y++){
                heights[x,y]=0;
            }

        }
        return heights;

    }

    float Calculate(int x,int y){
        float xco=(float)x/width*scale;
        //float yco=(float)y/width*scale;
        //+offsety;
        float yco=(float)y/width*scale;;

        return Mathf.PerlinNoise(xco,yco);

    }
}
