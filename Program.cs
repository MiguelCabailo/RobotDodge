using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Game", 800, 600);
        Robotdodge robotDodge = new Robotdodge(gameWindow);
   

        do
        {

            SplashKit.ProcessEvents();
            robotDodge.HandleInput();
            robotDodge.Draw();
            robotDodge.Update();
      
     


        } while (!gameWindow.CloseRequested);

        gameWindow.Close();

    }
}



// Too many Collissions
// is off screen is being checked at the start
//all the objects at the start are off screen so it returns true initially





