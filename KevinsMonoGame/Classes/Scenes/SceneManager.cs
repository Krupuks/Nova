using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
namespace KevinsMonoGame
{
    internal class SceneManager
    {
        //Start with 1 = menu (0 is gameOverScreen)
        private int currentLevelIndex = 1;
        public void GoToNextScene(IHasScenes hasScenes)
        {
            //reset current scene before going to the next
            hasScenes.Scenes[currentLevelIndex].completed = false;
            currentLevelIndex++;

            //loop back to first scene if needed and restore players hp
            if (currentLevelIndex >= hasScenes.Scenes.Count)
            {
                Level level = hasScenes.Scenes[currentLevelIndex - 1] as Level;
                level.Player.CurrentHealth = level.Player.MaxHealth;
                currentLevelIndex = 0;
            }

            MediaPlayer.Play(hasScenes.Scenes[currentLevelIndex].Song);

            //set up the next scene if it is a playable level
            if (hasScenes.Scenes[currentLevelIndex] is Level)
            {
                Level level = hasScenes.Scenes[currentLevelIndex] as Level;

                //restore player position
                level.Player.Position = level.StartPos;

                for (int i = 0; i < level.Terrain.Enemies.Count; i++)
                {
                    //revive enemies
                    level.Terrain.Enemies[i].IsAlive = true;
                    //restore enemies health
                    level.Terrain.Enemies[i].CurrentHealth = level.Terrain.Enemies[i].MaxHealth;
                    //position enemies
                    level.Terrain.Enemies[i].Position = level.Terrain.EnemyPos[i];
                }
                if (hasScenes.Scenes[currentLevelIndex] is LevelBoss)
                {
                    LevelBoss Bosslevel = hasScenes.Scenes[currentLevelIndex] as LevelBoss;
                    Bosslevel.IsTriggered = true;
                }
            }
        }
        public void Update(IHasScenes hasScenes, GameTime gameTime)
        {
            //When level is completed
            if (hasScenes.Scenes[currentLevelIndex].completed)
                GoToNextScene(hasScenes);

            //skip to GameOver scene if player dies
            if (hasScenes.Scenes[currentLevelIndex] is Level)
            {
                Level level = hasScenes.Scenes[currentLevelIndex] as Level;
                if (!level.Player.IsAlive)
                {
                    currentLevelIndex = 0;
                    //revive player
                    level.Player.IsAlive = true;
                    //restore players health
                    level.Player.CurrentHealth = level.Player.MaxHealth;
                }
            }
            //update current scene
            hasScenes.Scenes[currentLevelIndex].Update(gameTime);
        }
        public void Draw(IHasScenes hasLevels, SpriteBatch spriteBatch)
        {
            hasLevels.Scenes[currentLevelIndex].Draw(spriteBatch);
        }
    }
}
