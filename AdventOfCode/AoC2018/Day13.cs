using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2018
{
    enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }

    enum IntersectionsActions
    {
        TurnLeft = -1,
        Straight = 0,
        TurnRight = 1
    }

    class Cart(Directions dir)
    {
        public Directions Facing { get; set; } = dir;
        public IntersectionsActions NextIntersectionAction { get; set; } = IntersectionsActions.TurnLeft;
    }

    class MinecartTrackSystem
    {
        public char[,] TrackLayer { get; set; } = new char[0, 0];
        public Cart?[,] CartLayer { get; set; } = new Cart[0, 0];
        Coordinate? CrashLocation { get; set; }

        private bool MoveCart(Cart?[,] updateCarts, Cart? c, int x, int y)
        {
            if ((updateCarts[x, y] == null) && (CartLayer[x, y] == null) && (c != null))
            {
                updateCarts[x, y] = c;
                IntersectionsActions action;
                switch (TrackLayer[x, y])
                {
                    case '+':
                        action = c.NextIntersectionAction;
                        c.Facing = (Directions)(((int)c.Facing + (int)action + 4) % 4);
                        switch (c.NextIntersectionAction)
                        {
                            case IntersectionsActions.Straight:
                                c.NextIntersectionAction = IntersectionsActions.TurnRight;
                                break;
                            case IntersectionsActions.TurnLeft:
                                c.NextIntersectionAction = IntersectionsActions.Straight;
                                break;
                            case IntersectionsActions.TurnRight:
                                c.NextIntersectionAction = IntersectionsActions.TurnLeft;
                                break;
                        }
                        break;
                    case '/':
                        if ((c.Facing == Directions.Up) || (c.Facing == Directions.Down))
                        {
                            action = IntersectionsActions.TurnRight;
                        }
                        else
                        {
                            action = IntersectionsActions.TurnLeft;
                        }
                        c.Facing = (Directions)(((int)c.Facing + (int)action + 4) % 4);
                        break;
                    case '\\':
                        if ((c.Facing == Directions.Up) || (c.Facing == Directions.Down))
                        {
                            action = IntersectionsActions.TurnLeft;
                        }
                        else
                        {
                            action = IntersectionsActions.TurnRight;
                        }
                        c.Facing = (Directions)(((int)c.Facing + (int)action + 4) % 4);
                        break;
                }
                return false;
            }
            else
            {
                updateCarts[x, y] = null;
                CartLayer[x, y] = null;
                CrashLocation ??= new Coordinate(x, y);
                return true;
            }
        }

        public int Tick()
        {
            Cart[,] updateCarts = new Cart[CartLayer.GetLength(0), CartLayer.GetLength(1)];
            for (int y = 0; y < TrackLayer.GetLength(1); y++)
            {
                for (int x = 0; x < TrackLayer.GetLength(0); x++)
                {
                    Cart? currentCart = CartLayer[x, y];
                    if (currentCart != null)
                    {
                        switch (currentCart.Facing)
                        {
                            case Directions.Up:
                                MoveCart(updateCarts, CartLayer[x, y], x, y - 1);
                                break;
                            case Directions.Down:
                                MoveCart(updateCarts, CartLayer[x, y], x, y + 1);
                                break;
                            case Directions.Left:
                                MoveCart(updateCarts, CartLayer[x, y], x - 1, y);
                                break;
                            case Directions.Right:
                                MoveCart(updateCarts, CartLayer[x, y], x + 1, y);
                                break;
                        }
                    }
                }
            }
            CartLayer = updateCarts;
            int remainingCarts = 0;
            foreach (Cart? c in CartLayer)
            {
                if (c != null)
                {
                    remainingCarts++;
                }
            }
            return remainingCarts;
        }

        public string GetCrashLocation()
        {
            return string.Format("{0},{1}", CrashLocation?.X, CrashLocation?.Y);
        }

        public string GetLonelyCartLocation()
        {
            for (int y = 0; y < CartLayer.GetLength(1); y++)
            {
                for (int x = 0; x < CartLayer.GetLength(0); x++)
                {
                    if (CartLayer[x, y] != null)
                    {
                        return string.Format("{0},{1}", x, y);
                    }
                }
            }
            return "No cart left";
        }
    }

    public class Day13 : AoCDay
    {
        static MinecartTrackSystem GetInitialTrackState(List<string> input)
        {
            MinecartTrackSystem tracks = new()
            {
                TrackLayer = new char[input[0].Length, input.Count],
                CartLayer = new Cart[input[0].Length, input.Count]
            };

            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    switch (input[y][x])
                    {
                        case '^':
                            tracks.TrackLayer[x, y] = '|';
                            tracks.CartLayer[x, y] = new Cart(Directions.Up);
                            break;
                        case 'v':
                            tracks.TrackLayer[x, y] = '|';
                            tracks.CartLayer[x, y] = new Cart(Directions.Down);
                            break;
                        case '<':
                            tracks.TrackLayer[x, y] = '-';
                            tracks.CartLayer[x, y] = new Cart(Directions.Left);
                            break;
                        case '>':
                            tracks.TrackLayer[x, y] = '-';
                            tracks.CartLayer[x, y] = new Cart(Directions.Right);
                            break;
                        default:
                            tracks.TrackLayer[x, y] = input[y][x];
                            break;
                    }
                }
            }

            return tracks;
        }

        public override void Solve()
        {
            MinecartTrackSystem tracks = GetInitialTrackState(Input);

            int ticks = 0;
            while (tracks.Tick() > 1)
            {
                ticks++;
            }
            Part1Solution = tracks.GetCrashLocation();
            Part2Solution = tracks.GetLonelyCartLocation();
        }
    }
}
