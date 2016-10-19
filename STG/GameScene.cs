using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{	
	class GameScene : asd.Scene
	{		
		bool isSceneChanging = false;
        private int id_bgm2;
        private int id_laser;

        protected override void OnRegistered()
		{
			
			asd.Layer2D layer = new asd.Layer2D();
			AddLayer(layer);
            asd.TextureObject2D background2 = new asd.TextureObject2D();
            background2.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/game.png");           
            layer.AddObject(background2);

            // BGMをループ再生
            asd.SoundSource bgm2 = asd.Engine.Sound.CreateSoundSource("Resources/Battle.wav", false);            
            bgm2.IsLoopingMode = true;            
            bgm2.LoopStartingPoint = 30.7f;
            bgm2.LoopEndPoint = 55.3f;
            id_bgm2 = asd.Engine.Sound.Play(bgm2);
        }

		protected override void OnUpdated()
		{              
            // ダミー音声の再生

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Push)
            {  
                asd.SoundSource laser = asd.Engine.Sound.CreateSoundSource("Resources/Lazer.wav", true);
                laser.IsLoopingMode = true;
                laser.LoopEndPoint = 0.1f;               
                id_laser = asd.Engine.Sound.Play(laser);
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Release)
            {
                asd.Engine.Sound.Stop(id_laser);
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.D) == asd.KeyState.Push)
            {
                asd.SoundSource banned = asd.Engine.Sound.CreateSoundSource("Resources/banned.wav", true);
                int id_banned = asd.Engine.Sound.Play(banned);
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.F) == asd.KeyState.Push)
            {
                asd.SoundSource broken = asd.Engine.Sound.CreateSoundSource("Resources/broken.wav", true);
                int id_break = asd.Engine.Sound.Play(broken);
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.S) == asd.KeyState.Push)
            {
                asd.SoundSource bomb = asd.Engine.Sound.CreateSoundSource("Resources/bomb.wav", true);
                int id_bomb = asd.Engine.Sound.Play(bomb);
            }




            // Zキーでゲームオーバー
            if (!isSceneChanging && asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
			{				
				asd.Engine.ChangeSceneWithTransition(new GameOverScene(), new asd.TransitionFade(2.0f, 3.0f));
                asd.Engine.Sound.FadeOut(id_bgm2, 2.0f);

                asd.SoundSource death = asd.Engine.Sound.CreateSoundSource("Resources/death.wav", true);
                int id_beath = asd.Engine.Sound.Play(death);

                isSceneChanging = true;
			}
		}
	}
}
