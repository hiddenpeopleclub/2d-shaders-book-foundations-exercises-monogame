using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShaderDev01
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		
		Texture2D background, hpc, nubarron;




		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.GraphicsProfile = GraphicsProfile.HiDef;
			graphics.PreferredBackBufferWidth = 1280;
			graphics.PreferredBackBufferHeight = 720;
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			base.Initialize();
		}


		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			background = Content.Load<Texture2D>("3");
			hpc = Content.Load<Texture2D>("hpc");
			nubarron = Content.Load<Texture2D>("Nubarron Icon");
		}


		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);

			// background
			spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null);
			spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
			spriteBatch.End();

			// additive (top-left)
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
			spriteBatch.Draw(hpc, new Rectangle(50, 50, 200, 200), Color.White);
			spriteBatch.End();

			// alpha blend (top-right)
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			spriteBatch.Draw(nubarron, new Rectangle(300, 50, 200, 200), Color.White);
			spriteBatch.End();

			// multiply (bottom-left)
			BlendState multiplyBlendState = new BlendState();
			multiplyBlendState.ColorSourceBlend = Blend.DestinationColor;
			multiplyBlendState.ColorDestinationBlend = Blend.Zero;
			multiplyBlendState.ColorBlendFunction = BlendFunction.Add;

			spriteBatch.Begin(SpriteSortMode.Immediate, multiplyBlendState);
			spriteBatch.Draw(hpc, new Rectangle(50, 300, 200, 200), Color.White);
			spriteBatch.End();

			// subtractive (bottom-right)
			BlendState subtractiveBlendState = new BlendState();
			subtractiveBlendState.ColorSourceBlend = Blend.One;
			subtractiveBlendState.ColorDestinationBlend = Blend.One;
			subtractiveBlendState.ColorBlendFunction = BlendFunction.Subtract;

			spriteBatch.Begin(SpriteSortMode.Immediate, subtractiveBlendState);
			spriteBatch.Draw(hpc, new Rectangle(300, 300, 200, 200), Color.White);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
