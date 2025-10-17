using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2018
{
    enum IntersectionsActions
    {
        TurnLeft = -1,
        Straight = 0,
        TurnRight = 1
    }

    class Cart(Directions4Way dir)
    {
        public Directions4Way Facing { get; set; } = dir;
        public IntersectionsActions NextIntersectionAction { get; set; } = IntersectionsActions.TurnLeft;
    }

    class MinecartTrackSystem
    {
        public char[,] TrackLayer { get; set; } = new char[0, 0];
        public Cart?[,] CartLayer { get; set; } = new Cart[0, 0];
        Coordinate? CrashLocation { get; set; }

        private bool MoveCart(Cart?[,] updateCarts, Cart? c, int x, int y)
        {
            if (updateCarts[x, y] == null && CartLayer[x, y] == null && c != null)
            {
                updateCarts[x, y] = c;
                IntersectionsActions action;
                switch (TrackLayer[x, y])
                {
                    case '+':
                        action = c.NextIntersectionAction;
                        c.Facing = (Directions4Way)(((int)c.Facing + (int)action + 4) % 4);
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
                        if (c.Facing == Directions4Way.Up || c.Facing == Directions4Way.Down)
                        {
                            action = IntersectionsActions.TurnRight;
                        }
                        else
                        {
                            action = IntersectionsActions.TurnLeft;
                        }
                        c.Facing = (Directions4Way)(((int)c.Facing + (int)action + 4) % 4);
                        break;
                    case '\\':
                        if (c.Facing == Directions4Way.Up || c.Facing == Directions4Way.Down)
                        {
                            action = IntersectionsActions.TurnLeft;
                        }
                        else
                        {
                            action = IntersectionsActions.TurnRight;
                        }
                        c.Facing = (Directions4Way)(((int)c.Facing + (int)action + 4) % 4);
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
                            case Directions4Way.Up:
                                MoveCart(updateCarts, CartLayer[x, y], x, y - 1);
                                break;
                            case Directions4Way.Down:
                                MoveCart(updateCarts, CartLayer[x, y], x, y + 1);
                                break;
                            case Directions4Way.Left:
                                MoveCart(updateCarts, CartLayer[x, y], x - 1, y);
                                break;
                            case Directions4Way.Right:
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

    public class Challenge13 : Challenge
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
                            tracks.CartLayer[x, y] = new Cart(Directions4Way.Up);
                            break;
                        case 'v':
                            tracks.TrackLayer[x, y] = '|';
                            tracks.CartLayer[x, y] = new Cart(Directions4Way.Down);
                            break;
                        case '<':
                            tracks.TrackLayer[x, y] = '-';
                            tracks.CartLayer[x, y] = new Cart(Directions4Way.Left);
                            break;
                        case '>':
                            tracks.TrackLayer[x, y] = '-';
                            tracks.CartLayer[x, y] = new Cart(Directions4Way.Right);
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
