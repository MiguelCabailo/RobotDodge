using SplashKitSDK;
using System.Collections.Generic;
using System;

public class Robotdodge
{
    private Player _player;
    private Window _gameWindow;
    private bool _success = false;
    public bool Success
    {
        get { return _success; }
        set { _success = value; }
    }
    private List<Robot> _robots = new List<Robot>();
    private List<Robot> _checkCollisions = new List<Robot>();
    private List<DisplayLife> _livesRemaining = new List<DisplayLife>();
    public bool Quit
    {
        get { return _player.Quit; }
    }

    public Robotdodge(Window gameWindow)
    {
        _gameWindow = gameWindow;

        SplashKit.DrawBitmap("rainbowbkgrd.png", 0, 0);
        BackGroundMusic backGroundMusic = new BackGroundMusic(_gameWindow);
        backGroundMusic.Play();

        RandomBot(gameWindow);

        //moved out of main
        Player Player = new Player(gameWindow);
        _player = Player;
        //SplashKit.Delay(4000);

    }
    public void HandleInput()
    {
        _player.HandleInput();
        _player.StayOnWindow();
    }
    public void Draw()
    {

        DrawBackground();
        // DrawLife();

        DisplayScore timing = new DisplayScore(_gameWindow);
        timing.Draw();


        foreach (Robot a in _robots)
        {
            a.Draw();
        }
        _player.Draw();
        DisplayLife life = new DisplayLife(_gameWindow);
        life.Draw();
        DrawLife();
        _gameWindow.Refresh(60);
    }

    public void RandomBot(Window gameWindow)
    {
        _gameWindow = gameWindow;
        Player player1 = new Player(gameWindow);
    }
    public void Update()
    {
        int count = _robots.Count;

        for (int i = 10; i > _robots.Count; i--)
        {
            Boxy testBoxy = new Boxy(_gameWindow, _player);
            _robots.Add(testBoxy);
            System.Console.WriteLine("BOXY");

            for (int j = 0; j == _robots.Count % 2; j += 2)
            {
                Roundy testRoundy = new Roundy(_gameWindow, _player);
                _robots.Add(testRoundy);
                System.Console.WriteLine("ROUNDY");
            }

            BoxyBlack testBlacky = new BoxyBlack(_gameWindow, _player);
            _robots.Add(testBlacky);
            System.Console.WriteLine("BOXYBLACK");
        }

        foreach (Robot a in _robots)
        {
            a.Update();
            a.isOffScreen(_gameWindow);
        }

        CheckCollisions();
    }

    public void CheckCollisions()
    {
        foreach (Robot a in _robots)
        {
            if (_player.CollidedWith(a) || (a.OffScreen == true))
            {
                _checkCollisions.Add(a);
                System.Console.WriteLine("Collided");
            }

            if (_player.CollidedWith(a))
            {
                _gameWindow.DrawText("Ouch!", Color.Red, "StencilStd.otf", 100, 400, 300);
                _gameWindow.Refresh(60);
                SplashKit.Delay(150);

                //following if and else if is to stop the list from being negative and causing an error
                //stops life from going below 1
                if (_livesRemaining.Count > 1)
                {
                    _livesRemaining.RemoveAt(0);
                }
                //when it is one after the first if remove only one more life etc..
                else if (_livesRemaining.Count == 1)
                {
                    _livesRemaining.RemoveAt(0);
                    _gameWindow.Clear(Color.Black);
                    _gameWindow.DrawText("GAME OVER", Color.Red, "StencilStd.otf", 97, 100, _gameWindow.Height / 2);
                    _gameWindow.Refresh(60);
                    SplashKit.Delay(4000);
                    _gameWindow.Close();
                    //_gameWindow = null;
                }

                // for (int i = 0; i < _livesRemaining.Count; i++)
                // {
                //     _livesRemaining.RemoveRange(1, 1);
                // }

            }
        }

        foreach (Robot a in _checkCollisions)
        {
            _robots.Remove(a);
        }



    }

    public void DrawBackground()
    {
        SplashKit.LoadBitmap("background", "rainbowbkgrd.png");
        //Bitmap background = new Bitmap("background",0,0);
        Bitmap background;
        background = SplashKit.BitmapNamed("background");

        SplashKit.DrawBitmap("background", 0, 0);
        SplashKit.DrawBitmap("background", _gameWindow.Width - background.Width, 0);
        SplashKit.DrawBitmap("background", 0, _gameWindow.Height - background.Height);
        SplashKit.DrawBitmap("background", _gameWindow.Width - background.Width, _gameWindow.Height - background.Height);
        SplashKit.DrawBitmap("background", (_gameWindow.Width - background.Width) / 2, (_gameWindow.Height - background.Height) / 2);

    }
    //moving out the code... apply in next iteration
    // public void LivesRemaining(DisplayLife d)
    // {
    // DisplayLife remaining = new DisplayLife(_gameWindow);

    // _livesRemaining.Add(remaining);

    // System.Console.WriteLine(_livesRemaining.Count);
    // }
    public void DrawLife()
    {
        //makes sure that this is only run once since it is part of a while loop
        //go through for loop if Success is false
        //after execution Success is not true to it will never do this agian


        for (int k = 0; k < 5 && Success == false; k++)
        {
            DisplayLife remaining = new DisplayLife(_gameWindow);

            _livesRemaining.Add(remaining);

            System.Console.WriteLine(_livesRemaining.Count);



            if (_livesRemaining.Count > 5)
            {
                _livesRemaining.Remove(remaining);
                Success = true;
            }
        }

        string livesCount = Convert.ToString(_livesRemaining.Count);


        SplashKit.LoadBitmap("heart", "heart.png");

        Bitmap heart = SplashKit.BitmapNamed("heart");




        _gameWindow.DrawBitmap(heart, 0, 0, SplashKit.OptionScaleBmp(.1, .1));


        _gameWindow.DrawText(livesCount, Color.MistyRose, "StencilStd.otf", 25, 700, 570);


    }

}