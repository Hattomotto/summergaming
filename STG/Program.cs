using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
	

	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			asd.Engine.Initialize("STG", 640, 480, new asd.EngineOption());

			
			TitleScene scene = new TitleScene();

            asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(0, 1.0f));

			
			while (asd.Engine.DoEvents())
			{
				
				if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
				{
					break;
				}

                asd.Engine.Update();
			}

			asd.Engine.Terminate();
		}
	}

    
}
