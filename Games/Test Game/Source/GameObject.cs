using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Game.Source.Classes;

namespace Test_Game.Source
{
    internal abstract class GameObject
    {
        abstract public Vector2 Position { get; set; }
        abstract public Vector2 Origin { get; set; }
        abstract public Vector2 Scale { get; set; }
        abstract public string Tag { get; set; }
        abstract public List<GameObject> Children { get; set; }

        public GameObject()
        {
            Children = new List<GameObject>();
            Position = new Vector2();
            Origin = Position;
            Scale = new Vector2();
            Tag = "EmptyGameObject";
            Engine.RegisterGameObject(this);
        }

        public virtual void AddChild(GameObject child)
        {
            Children.Add(child);
        }

        public virtual void DestroyChild(GameObject child)
        {
            if (Children.Contains(child)) Children.Remove(child);
            child.DestorySelf();
        }

        public virtual GameObject GetChild(string childTag)
        {
            foreach (GameObject child in Children)
            {
                if (childTag.Equals(child.Tag))
                {
                    return child;
                }
            }
            Log.Error($"GameObject {childTag} Does not exist!");
            return null;
        }

        public virtual void DestorySelf()
        {
            Engine.UnRegisterGameObject(this);

            if (Children == null) { return; }
            foreach (GameObject child in Children)
            {
                child.DestorySelf();
            }
        }

        public virtual void UpdateChildren()
        {
            foreach (GameObject child in Children)
            {
                child.Position = Position + child.Origin;
            }
        }

        abstract public void OnLoad();
        abstract public void OnUpdate();
        abstract public void OnDestroy();



    }
}
