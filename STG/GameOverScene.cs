using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{	
	class GameOverScene : asd.Scene
	{
        bool isSceneChanging = false;

        protected override void OnRegistered()
		{			
			asd.Layer2D layer = new asd.Layer2D();		
			AddLayer(layer);
            			
			asd.TextureObject2D background = new asd.TextureObject2D();
			background.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/gameover.png");            			
			layer.AddObject(background);

            //BGMの再生
            asd.SoundSource bgm3 = asd.Engine.Sound.CreateSoundSource("Resources/gameover.wav", false);      
            int id_bgm3 = asd.Engine.Sound.Play(bgm3);
        }

		protected override void OnUpdated()
		{
            //ダミー音声の再生

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push || asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
            {
                asd.SoundSource select = asd.Engine.Sound.CreateSoundSource("Resources/select.wav", true);
                int id_select = asd.Engine.Sound.Play(select);
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Enter) == asd.KeyState.Push)
            {
                asd.SoundSource enter = asd.Engine.Sound.CreateSoundSource("Resources/enter.wav", true);
                int id_enter = asd.Engine.Sound.Play(enter);
            }
         
                        
            // Zキーでタイトルに戻る
            if (!isSceneChanging && asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
			{
				asd.Engine.ChangeSceneWithTransition(new TitleScene(), new asd.TransitionFade(1.0f, 1.0f));

                isSceneChanging = true;
            }

            // Cキーでコンテニューする
            if (!isSceneChanging && asd.Engine.Keyboard.GetKeyState(asd.Keys.C) == asd.KeyState.Push)
            {
                asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(2.0f, 1.0f));
                asd.SoundSource woop = asd.Engine.Sound.CreateSoundSource("Resources/woop.wav", true);
                int id_woop = asd.Engine.Sound.Play(woop);

                isSceneChanging = true;
            }
        }
	}
}
