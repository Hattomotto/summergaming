using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
	class TitleScene : asd.Scene
	{
        bool isSceneChanging = false;
        private int id_bgm1;


        protected override void OnRegistered()
		{
			
			asd.Layer2D layer = new asd.Layer2D();
          	AddLayer(layer);
            			
			asd.TextureObject2D background = new asd.TextureObject2D();
			background.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Title.png");

			layer.AddObject(background);

            // BGMをループ再生
            asd.SoundSource bgm1 = asd.Engine.Sound.CreateSoundSource("Resources/opening.wav", false);
            bgm1.IsLoopingMode = true;
            bgm1.LoopStartingPoint = 29.1f;
            id_bgm1 = asd.Engine.Sound.Play(bgm1);
            asd.Engine.Sound.FadeIn(id_bgm1, 1.0f);
            
        }

		protected override void OnUpdated()
		{   
            //ダミー効果音の再生

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push || asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
            {                
                asd.SoundSource select = asd.Engine.Sound.CreateSoundSource("Resources/select.wav", true);
                int id_select = asd.Engine.Sound.Play(select);                
            }


            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Enter) == asd.KeyState.Push )
            {
                asd.SoundSource enter = asd.Engine.Sound.CreateSoundSource("Resources/enter.wav", true);
                int id_enter = asd.Engine.Sound.Play(enter);                
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.B) == asd.KeyState.Push)
            {
                asd.SoundSource banned = asd.Engine.Sound.CreateSoundSource("Resources/banned.wav", true);
                int id_banned = asd.Engine.Sound.Play(banned);
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Backspace) == asd.KeyState.Push)
            {
                asd.SoundSource cancel = asd.Engine.Sound.CreateSoundSource("Resources/cancel.wav", true);
                int id_cancel = asd.Engine.Sound.Play(cancel);
            }

            // Zキーでゲーム開始
            if (!isSceneChanging && asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
			{
                asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(2.0f, 2.0f));
                asd.Engine.Sound.FadeOut(id_bgm1, 1.0f);

                asd.SoundSource woop = asd.Engine.Sound.CreateSoundSource("Resources/woop.wav", true);
                int id_woop = asd.Engine.Sound.Play(woop);

                isSceneChanging = true;

            }
		}
	}
}
