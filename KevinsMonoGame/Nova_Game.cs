using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal class GameNova : Game, IHasScenes
    {
        public SceneManager SceneManager { get; set; } = new SceneManager();
        public List<Scene> Scenes { get; set; } = new List<Scene>();

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;

        private Terrain terrain1;
        private Terrain terrain2;

        private Entity dummy;
        private Entity smoke;
        private Entity gameOverText;
        private Entity startButton;
        private Entity exitButton;
        private Entity backToMenuButton;

        public GameNova()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = General.ScreenWidth;
            graphics.PreferredBackBufferHeight = General.ScreenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();

            //player
            player = new Player(new KeyboardReader());
            Camera.Initialize(player, General.ScreenWidth / 5, General.ScreenHeight / 5);

            //terrains
            terrain1 = new Terrain(General.TerrainMap1);
            terrain2 = new Terrain(General.TerrainMap2);

            //items
            gameOverText = new ItemStatic(General.TextTexture_gameOver);
            dummy = new ItemDynamic(General.PlayerTexture_idle, General.ScreenWidth / (float)General.MenuWidth, 5, 8);
            smoke = new ItemDynamic(General.ItemTexture_smoke, General.ScreenWidth / (float)General.MenuWidth, 2, 4);
            backToMenuButton = new Button("NEXT", General.ButtonTexture_backToMenu, this);
            startButton = new Button("NEXT", General.ButtonTexture_start, this);
            exitButton = new Button("EXIT", General.ButtonTexture_exit, this);

            //gameover (add positionables externally as many as desired)
            Scenes.Add(new Menu(General.Endscreen_bg, General.TheFinalOfTheFantasy));
            Scenes[0].AddPositionable(gameOverText, new Vector2(General.ScreenWidth / 2 - gameOverText.TextureIdle.Width * General.Scale / 2, General.ScreenHeight / 2 - gameOverText.TextureIdle.Height * General.Scale));
            Scenes[0].AddPositionable(backToMenuButton, new Vector2(General.ScreenWidth / 2 - backToMenuButton.TextureIdle.Width * General.Scale / 2, General.ScreenHeight / 2 + backToMenuButton.TextureIdle.Height * General.Scale));
            //titlescreen
            Scenes.Add(new Menu(General.Titlescreen_bg, General.TitleTheme));
            Scenes[1].AddPositionable(startButton, new Vector2(General.ScreenWidth * 3 / 4, General.ScreenHeight * 13 / 16));
            Scenes[1].AddPositionable(exitButton, new Vector2(General.ScreenWidth * 3 / 4, General.ScreenHeight * 14 / 16));
            Scenes[1].AddPositionable(dummy, new Vector2(General.ScreenWidth * 3 / 16 - (General.ScreenWidth / 2), General.ScreenHeight * 28 / 64 - (General.ScreenHeight / 2)));
            Scenes[1].AddPositionable(smoke, new Vector2(General.ScreenWidth * 1025 / 1280 - (General.ScreenWidth / 2), General.ScreenHeight * 438 / 720 - (General.ScreenHeight / 2)));
            //first level
            Scenes.Add(new LevelRegular(terrain1, player, new Vector2(18 * General.BlockSize * General.Scale, 23 * General.BlockSize * General.Scale), new Vector2(130 * General.BlockSize * General.Scale, 28 * General.BlockSize * General.Scale), General.Forest_bg, General.AndTheJourneyBegins));
            //boss level
            Scenes.Add(new LevelBoss(terrain2, player, new Vector2(13 * General.BlockSize * General.Scale, 21 * General.BlockSize * General.Scale), new Vector2(19 * General.BlockSize * General.Scale, 0), new Vector2(44 * General.BlockSize * General.Scale, 0), General.Cave_bg, General.MysteriousDungeon));
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            General.Titlescreen_bg = Content.Load<Texture2D>("sprites/Titlescreen");
            General.MenuWidth = General.Titlescreen_bg.Width;
            General.MenuHeight = General.Titlescreen_bg.Height;

            General.Endscreen_bg = Content.Load<Texture2D>("sprites/Endscreen");
            General.Forest_bg = Content.Load<Texture2D>("sprites/ForestBG");
            General.Cave_bg = Content.Load<Texture2D>("sprites/CaveBG");

            General.ButtonTexture_start = Content.Load<Texture2D>("sprites/Startbutton");
            General.ButtonTexture_exit = Content.Load<Texture2D>("sprites/Exitbutton");
            General.ButtonTexture_backToMenu = Content.Load<Texture2D>("sprites/BackToMenubutton");
            General.TextTexture_gameOver = Content.Load<Texture2D>("sprites/GameOver");
            General.ItemTexture_smoke = Content.Load<Texture2D>("sprites/Smoke");

            General.PlayerTexture_idle = Content.Load<Texture2D>("sprites/Chloe_idle");
            General.PlayerTexture_idle_sneaky = Content.Load<Texture2D>("sprites/Chloe_idle_sneaky");
            General.PlayerTexture_run = Content.Load<Texture2D>("sprites/Chloe_run");
            General.PlayerTexture_run_sneaky = Content.Load<Texture2D>("sprites/Chloe_run_sneaky");
            General.PlayerTexture_attack = Content.Load<Texture2D>("sprites/Chloe_attack");
            General.PlayerTexture_jump = Content.Load<Texture2D>("sprites/Chloe_jump");

            General.PebbleTexture_idle = Content.Load<Texture2D>("sprites/Pebble_idle");
            General.LevirockTexture_idle = Content.Load<Texture2D>("sprites/Levirock_idle");
            General.NovadonTexture_idle = Content.Load<Texture2D>("sprites/Novadon_idle");
            General.NovadonTexture_run = Content.Load<Texture2D>("sprites/Novadon_run");
            General.NovadonTexture_attack = Content.Load<Texture2D>("sprites/Novadon_attack");

            General.TerrainTexture = Content.Load<Texture2D>("sprites/block");
            General.Texture = Content.Load<Texture2D>("sprites/blackpixel");

            General.TitleTheme = Content.Load<Song>("music/Title Theme");
            General.AndTheJourneyBegins = Content.Load<Song>("music/And The Journey Begins");
            General.MysteriousDungeon = Content.Load<Song>("music/Mysterious Dungeon");
            General.PrepareForBattle = Content.Load<Song>("music/Prepare For Battle");
            General.TheFinalOfTheFantasy = Content.Load<Song>("music/The Final Of The Fantasy");
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(General.TitleTheme);
        }
        protected override void Update(GameTime gameTime)
        {
            AllColliders.Clear();
            SceneManager.Update(this,gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, transformMatrix: Camera.Transform);
            SceneManager.Draw(this, spriteBatch);
            #region TestingArea
            //Camera.Draw(spriteBatch);
            //ColliderCollection.Draw(spriteBatch);
            #endregion
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}