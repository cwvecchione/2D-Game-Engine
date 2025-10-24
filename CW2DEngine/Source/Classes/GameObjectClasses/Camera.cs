using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source.Classes.GameObjectClasses
{
    internal class Camera : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        View view = Engine.camera;
        bool Current = false;

        public Camera(string tag)
        {
            Position = new Vector2(Engine.camera.Center.X, Engine.camera.Center.Y);
            Scale = new Vector2(Engine.camera.Size.X, Engine.camera.Size.Y);
            Tag = tag;

            Engine.AllCameras.Add(this);
        }

        public Camera(bool current, string tag)
        {
            Position = new Vector2(Engine.camera.Center.X, Engine.camera.Center.Y);
            Scale = new Vector2(Engine.camera.Size.X, Engine.camera.Size.Y);
            Tag = tag;
            Current = current;

            if (Current)
            {
                foreach (Camera cam in Engine.AllCameras)
                {
                    if (cam.Current) { cam.Current = false; }
                }
            }

            Engine.AllCameras.Add(this);
        }

        public void MakeCurrent()
        {
            foreach (Camera cam in Engine.AllCameras)
            {
                if (cam.Current) { cam.Current = false; }

                Current = true;
            }
        }

        public override void OnDestroy()
        {
            Engine.AllCameras.Remove(this);
        }

        public override void OnLoad()
        {

        }

        public override void OnUpdate()
        {
            if (Current)
            {
                view.Center = Position;
                view.Size = Scale;
                Engine.app.SetView(view);
            }
        }
    }
}
