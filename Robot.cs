using SplashKitSDK;

public abstract class Robot
{
    /// <summary>
    /// direction and speed
    /// length of the arrow
    /// </summary>
    /// <returns></returns>
    protected Vector2D Velocity { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public Color MainColor { get; set; }
    public bool OffScreen
    {
        get; set;
    }

    public int Width
    {
        get { return 50; }
    }
    public int Height
    {
        get { return 50; }
    }

    public Circle CollissionCircle
    {
        get { return SplashKit.CircleAt(X + Width / 2, Y + Height / 2, 20); }
    }


    public abstract void Draw();
    public void Update()
    {

        X += Velocity.X;
        Y += Velocity.Y;
    }

    public void isOffScreen(Window screen)
    {
        if (X < -Width || X > screen.Width || Y < -Height || Y > screen.Height)
        {

            OffScreen = true;
        }
    }

}

public class Boxy : Robot
{
    public Boxy(Window gameWindow, Player player)
    {
        SplashKit.Rnd();
        //if the random that we got was less than .5 do this
        if (SplashKit.Rnd() < 0.5)
        {
            //if the random is lower than 0.5 make the X and Y exactly at the border of the screen
            //X is now a random with the integer of the width of gamewindow
            X = SplashKit.Rnd(gameWindow.Width);


            if (SplashKit.Rnd() < 0.5)

                Y = -Height;

            else

                Y = gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);

            if (SplashKit.Rnd() < 0.5)

                X = -Width;

            else

                Y = gameWindow.Width;

        }
        /*
        X = SplashKit.Rnd(gameWindow.Width - Width) / 2;
        Y = SplashKit.Rnd(gameWindow.Height - Height) / 2;
         */
        MainColor = Color.RandomRGB(200);

        //all caps for constant? Convention?
        int speed = 4;
        if (SplashKit.KeyDown(KeyCode.SpaceKey))
        {
            speed += 7;
        }


        //get a point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        //point for the player so robot can move towards the player one time
        //will not always update so robot will just move straight
        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        // Calculate the direction to head
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, speed);


    }
    public override void Draw()
    {
        double leftX;
        double rightX;

        double eyeY;
        double mouthY;

        leftX = X + 12;
        rightX = X + 27;

        eyeY = Y + 10;
        mouthY = Y + 30;

        SplashKit.FillRectangle(Color.Random(), X, Y, Width, Height);

        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);

    }

}

public class Roundy : Robot
{
    public Roundy(Window gameWindow, Player player)
    {
        SplashKit.Rnd();
        //if the random that we got was less than .5 do this
        if (SplashKit.Rnd() < 0.5)
        {
            //if the random is lower than 0.5 make the X and Y exactly at the border of the screen
            //X is now a random with the integer of the width of gamewindow
            X = SplashKit.Rnd(gameWindow.Width);


            if (SplashKit.Rnd() < 0.5)

                Y = -Height;

            else

                Y = gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);

            if (SplashKit.Rnd() < 0.5)

                X = -Width;

            else

                Y = gameWindow.Width;

        }
        /*
        X = SplashKit.Rnd(gameWindow.Width - Width) / 2;
        Y = SplashKit.Rnd(gameWindow.Height - Height) / 2;
         */
        MainColor = Color.RandomRGB(200);

        //all caps for constant? Convention?
        int speed = 4;
        if (SplashKit.KeyDown(KeyCode.SpaceKey))
        {
            speed += 7;
        }


        //get a point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        //point for the player so robot can move towards the player one time
        //will not always update so robot will just move straight
        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        // Calculate the direction to head
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, speed);


    }

    public override void Draw()
    {
        double leftX, midX, rightX;
        double midY, eyeY, mouthY;
        leftX = X + 17;
        midX = X + 25;
        rightX = X + 33;
        midY = Y + 25;
        eyeY = Y + 20;
        mouthY = Y + 35;
        SplashKit.FillCircle(Color.White, midX, midY, 25);
        SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
        SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
        SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
        SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
        SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
    }

}

public class BoxyBlack : Robot
{
    public BoxyBlack(Window gameWindow, Player player)
    {
        SplashKit.Rnd();
        //if the random that we got was less than .5 do this
        if (SplashKit.Rnd() < 0.5)
        {
            //if the random is lower than 0.5 make the X and Y exactly at the border of the screen
            //X is now a random with the integer of the width of gamewindow
            X = SplashKit.Rnd(gameWindow.Width);


            if (SplashKit.Rnd() < 0.5)

                Y = -Height;

            else

                Y = gameWindow.Height;
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);

            if (SplashKit.Rnd() < 0.5)

                X = -Width;

            else

                Y = gameWindow.Width;

        }
        /*
        X = SplashKit.Rnd(gameWindow.Width - Width) / 2;
        Y = SplashKit.Rnd(gameWindow.Height - Height) / 2;
         */
        MainColor = Color.RandomRGB(200);

        //all caps for constant? Convention?
        int speed = 4;
        if (SplashKit.KeyDown(KeyCode.SpaceKey))
        {
            speed += 7;
            System.Console.WriteLine("increasing speed!!!!!!!!!!!!!!!!!!!!!!!");
        }


        //get a point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        //point for the player so robot can move towards the player one time
        //will not always update so robot will just move straight
        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        // Calculate the direction to head
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, speed);
    }
    public override void Draw()
    {
        double leftX;
        double rightX;

        double eyeY;
        double mouthY;

        leftX = X + 12;
        rightX = X + 27;

        eyeY = Y + 10;
        mouthY = Y + 30;

        SplashKit.FillRectangle(Color.Black, X, Y, Width, Height);

        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
    }
}