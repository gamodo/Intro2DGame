using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SFML.Window;
using SFML.Graphics;

namespace Intro_2D_Project{
    class Map{
        Tile[,] tiles;
        public float TileSize { get { return 50; } }
        string white = System.Drawing.Color.FromArgb(255, 255, 255).Name;
        string black = System.Drawing.Color.FromArgb(0, 0, 0).Name;

        public Map(Bitmap mask){
            tiles = new Tile[mask.Width, mask.Height];
            int a = tiles.GetLength(0), b = tiles.GetLength(1);
            for (int i = 0; i < a; ++i){
                for (int j = 0; j < b; ++j){
                    if (i==0||i==a-1||j==0||j==b-1)
                        tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, new Vector2f(TileSize, TileSize));

                    else
                        tiles[i, j] = new Tile(SFML.Graphics.Color.White, new Vector2f(i, j) * TileSize, true, new Vector2f(TileSize, TileSize));
                }
            }
        }
        public bool IsWalkable(GameObject gObj){
            int x = (int)(gObj.Position.X / TileSize + gObj.MovingDirection.X / TileSize);
            int y = (int)(gObj.Position.Y / TileSize + gObj.MovingDirection.Y / TileSize);

            int sx = (int)(gObj.Position.X / TileSize + gObj.Size.X / TileSize + gObj.MovingDirection.X / TileSize);
            int sy = (int)(gObj.Position.Y / TileSize + gObj.Size.Y / TileSize + gObj.MovingDirection.Y / TileSize);
            try{
                return tiles[x, y].Walkable && tiles[sx, y].Walkable && tiles[x, sy].Walkable && tiles[sx, sy].Walkable;
            }
            catch (IndexOutOfRangeException){
                return false;
            }
        }
        public void Draw(RenderWindow win){
            foreach (Tile t in tiles){
                t.Draw(win);
            }
        }
    }
}