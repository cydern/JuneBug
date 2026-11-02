using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JuneBug;

public class Node : IDisposable
{
    /// <summary>
    /// The custom name of this particular Node.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The Parent Node of this Node
    /// 
    /// Returns null when it's the top node.
    /// </summary>
    public Node ParentNode 
    { 
        get { return ParentNode; }
        set { SetParent(value); }
    }

    /// <summary>
    /// A Collection of all children of this Node. Does not include Children of Children.
    /// </summary>
    public Collection<Node> ChildNodes { get; private set; }

    public bool HasChildren => ChildNodes.Count > 0;

    public bool IsTopNode => ParentNode == null;

    public bool IsDisposed { get; private set; } = false;
    
    public Node()
    {
        ChildNodes = new Collection<Node>();
        Name = "Node";
    } 

    public Node(String name)
    {
        ChildNodes = new Collection<Node>();
        Name = name;
    }

    ~Node() => Dispose(false);

    public virtual void Initialize()
    {
        LoadContent();
    }

    public virtual void LoadContent()
    {
        
    }

    public virtual void Update(GameTime gameTime)
    {
        for (int i = 0; i < ChildNodes.Count; i++) { ChildNodes[i].Update(gameTime); }
    }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        for (int i = 0; i < ChildNodes.Count; i++) { ChildNodes[i].Draw(spriteBatch, gameTime); }
    }

    /// <summary>
    /// Adds a Child Node to this Node.
    /// </summary>
    /// <param name="node"></param>
    public void AddChild(Node node)
    {
        
    }

    public void RemoveChild(Node node)
    {
        
    }

    public void SetParent(Node node)
    {
        
    }

    public void RemoveParent()
    {
        
    }

    private Boolean DoesNodeExistInChildren(Node node)
    {
        return false;
    }

    private void SearchChildrenForNode(Node node)
    {
        
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed) { return; }
        if (disposing)
        {
            foreach (Node node in ChildNodes)
            {
                node.Dispose();
            }
        }

        IsDisposed = true;
    }

}