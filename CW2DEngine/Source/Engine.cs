using CW2DEngine.Source.Classes;
using nkast.Aether.Physics2D.Dynamics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time = CW2DEngine.Source.Classes.Time;

namespace CW2DEngine.Source
{
    abstract class Engine
    {
        //Height and width
        public uint height = 500;
        public uint width = 500;

        //window title
        public string title = "CW 2D  Engine 0.0.1";

        //Window color
        public Color windowColor = Color.Black;

        //Window Renderer
        public static RenderWindow app;

        //Camera
        public static View camera;
        public static List<Camera> AllCameras = new List<Camera>();

        //Gameobjects
        public static List<GameObject> GameObjects = new List<GameObject>();
        public static List<GameObject> GameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> GameObjectsToRemove = new List<GameObject>();

        public static World world = new World();

        public Engine(uint WIDTH, uint HEIGHT, string TITLE, Color WINDOWCOLOR)
        {
            width = WIDTH;
            height = HEIGHT;
            title = TITLE;
            windowColor = WINDOWCOLOR;

            app = new RenderWindow(new VideoMode(width, height), title, style: Styles.Resize | Styles.Close);
            app.KeyPressed += App_KeyPressed;
            app.KeyReleased += App_KeyReleased;
            app.Closed += App_Closed;
            app.Resized += App_Resized;
            app.SetFramerateLimit(144);
            camera = app.GetView();
            app.SetView(camera);

            GameLoop();
        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            window.SetView(new View(visibleArea));
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }

        public static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Add(gameObject);
        }

        void GameLoop()
        {
            LoadObjects();
            OnLoad();
            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);

                UpdateObjects();
                OnUpdate();

                app.Display();
            }
        }

        public void LoadObjects()
        {
            foreach(GameObject gameObject in GameObjects) 
            {
                gameObject.OnLoad();
            }
        }

        public void UpdateObjects()
        {
            Time.UpdateTime();
            world.Step(Time.deltaTime);

            if(GameObjects == null)
            {
                return;
            }

            for(int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }

            if(world.IsLocked) { return; }


            if(GameObjectsToAdd.Count > 0)
            {
                for(int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }
                GameObjectsToAdd.Clear();
            }

            if(GameObjectsToRemove.Count > 0)
            {
                for(int i = 0; GameObjectsToRemove.Count > i; i++)
                {
                    GameObjectsToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }
                GameObjectsToRemove.Clear();
            }


        }

        public abstract void OnLoad();

        public virtual void OnUpdate()
        {
          LevelManager.UpdateLevel();

        }

    }
}
