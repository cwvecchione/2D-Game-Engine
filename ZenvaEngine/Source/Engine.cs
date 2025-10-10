using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaEngine.Source
{
    abstract class Engine
    {
        // Height and width
        public uint height = 500;
        public uint width = 500;
        // Window title
        public string title = "Zenva Engine 0.0.1";
        // Window color
        public Color windowColor = Color.Black;
        // Window Renderer
        public static RenderWindow app;

        public Engine(uint WIDTH, uint HEIGHT, string TITLE, Color WINDOWCOLOR)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = WINDOWCOLOR;
            app = new RenderWindow(new VideoMode(width, height), title, style: Styles.Resize | Styles.Close);
            app.KeyPressed += App_KeyPressed;
            app.KeyReleased += App_KeyReleased;
            app.Closed += App_Closed;
            app.Resized += App_Resized;
            app.SetFramerateLimit(144);
            GameLoop();
        }

        RenderWindow window = (RenderWindow)sender;
        window.Close();

        RenderWindow window = (RenderWindow)sender;
        FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
        window.SetView(new View(visibleArea));

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }
        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
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

        public abstract void OnLoad();
        public virtual void OnUpdate()
        {
            if (Input.ActionJustPressed("Down"))
            {
                Console.WriteLine("Key just pressed");
            }
            if (Input.ActionPressed("Up"))
            {
                Console.WriteLine("Key pressed");
            }
        }

        public static List<GameObject> GameObjects = new List<GameObject>();
        public static List<GameObject> GameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> GameObjectsToRemove = new List<GameObject>();

        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }
        public static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Add(gameObject);
        }

        public void LoadObjects()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.OnLoad();
            }
        }

        public void UpdateObjects()
        {
            if (GameObjects == null)
            {
                return;
            }
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }
            if (GameObjectsToAdd.Count > 0)
            {
                for (int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }
                GameObjectsToAdd.Clear();
            }
            if (GameObjectsToRemove.Count > 0)
            {
                for (int i = 0; GameObjectsToRemove.Count > i; i++)
                {
                    GameObjectsToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }
                GameObjectsToRemove.Clear();
            }
        }
}
