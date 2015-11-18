
using SFML.Graphics;
using SFML.Window;
using System.Drawing;
using System;

namespace Intro_2D_Project{
    class Game{
        static Monster01 mons01;
        static Monster01 mons02;
        static Tools tool;
        //tatic Vulkan vulkan;
       // static Gras gras;
        public static Player Player { get; private set; }
        public static Map map { get; private set; }
        static GameTime gTime;
        static View view;

            static void Main(string[] args){
                RenderWindow win = new RenderWindow(new VideoMode(900,900), "Intro-2D-Project",Styles.Default);
                win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };
                Initialize();

                while (win.IsOpen()){
                    Update();
                    Draw(win);
                    win.DispatchEvents();
                }
            }

       public static void Initialize(){
            gTime = new GameTime();
            map = new Map(new System.Drawing.Bitmap("Bilder/Map.bmp"));
            Player = new Player(new Vector2f(map.TileSize + 30, map.TileSize + 30));
            mons01 = new Monster01("Bilder/Monster.png", new Vector2f(800, 100));
            mons02 = new Monster01("Bilder/Monster.png", new Vector2f(100, 600));
            tool = new Tools("Bilder/Tool1.png", new Vector2f (800, 800));
           // vulkan = new Vulkan("Bilder/Vulkan.png", new Vector2f(500, 500);
            view = new View();
            view.Center = Player.Position;
       }

        static void Draw(RenderWindow window){
            window.Clear(new SFML.Graphics.Color(50, 120, 190));
            map.Draw(window);
            mons01.Draw(window);
            mons02.Draw(window);
          //  vulkan.Draw(window);
            if(tool.isOnMap)tool.Draw(window);
            Player.Draw(window);
            window.Display();
            window.SetView(view);
        }

        static void Update(){
            gTime.Update();
            mons01.Update(gTime);
            mons02.Update(gTime);
            Player.Update(gTime);
            if (tool.isOnMap) tool.Update(gTime, Player.Position);
            view.Center = Player.Position;
        }
    }
}
