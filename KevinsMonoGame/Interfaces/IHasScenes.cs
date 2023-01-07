using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal interface IHasScenes
    {
        public SceneManager SceneManager { get; set; }
        public List<Scene> Scenes { get; set; }
        public void Exit();
    }
}
