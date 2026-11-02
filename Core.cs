using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JuneBug;

public class Core : Game
{
    public Collection<Node> ChildNodes { get; private set; }

    public static new ContentManager Content;
    public static new GraphicsDevice GraphicsDevice;
    public static GraphicsDeviceManager Graphics;
    public static SpriteBatch SpriteBatch;

    public Core(string windowName, int windowWidth, int windowHeight, bool fullscreen)
    {
        Graphics = new GraphicsDeviceManager(this);

        Graphics.PreferredBackBufferWidth = windowWidth;
        Graphics.PreferredBackBufferHeight = windowHeight;
        Graphics.IsFullScreen = fullscreen;

        Graphics.ApplyChanges();

        Content = base.Content;
        Content.RootDirectory = "Content";

        ChildNodes = new Collection<Node>();

        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        GraphicsDevice = base.GraphicsDevice;
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        foreach(Node node in ChildNodes)
        {
            node.Initialize();
        }
    }

    protected override void Update(GameTime gameTime)
    {
        for (int i = 0; i < ChildNodes.Count; i++) { ChildNodes[i].Update(gameTime); }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        for (int i = 0; i < ChildNodes.Count; i++) { ChildNodes[i].Draw(SpriteBatch, gameTime); }
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}