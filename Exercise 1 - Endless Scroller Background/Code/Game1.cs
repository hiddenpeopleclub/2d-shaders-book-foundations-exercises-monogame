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
		
		Texture2D background;
		Effect effect;




		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.GraphicsProfile = GraphicsProfile.HiDef;
			graphics.PreferredBackBufferWidth = 1000;
			graphics.PreferredBackBufferHeight = 450;
			Content.RootDirectory = "Content";
		}


		protected override void Initialize()
		{
			base.Initialize();
		}


		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			background = Content.Load<Texture2D>("city_background_night");
			effect = Content.Load<Effect>("TestShader");
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

			// pass parameters to shader
			effect.Parameters["totalSeconds"].SetValue((float)gameTime.TotalGameTime.TotalSeconds);
			effect.Parameters["speed"].SetValue(0.05f);

			// define SamplerState
			SamplerState samplerState = SamplerState.LinearWrap;

			spriteBatch.Begin(SpriteSortMode.Immediate, null, samplerState, null, null, effect);
			spriteBatch.Draw(background, new Vector2(50, 50), Color.White);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
