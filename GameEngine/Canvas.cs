﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine
{
    public class Pixel
    {
        public int X;
        public int Y;
        public Color color;
        public string namePixel;

        public Pixel(int x_, int y_, Color color_, string name_)
        {
            X = x_;
            Y = y_;
            color = color_;
            namePixel = name_;
        }
    }

    public enum RenderType
    {
        Vulkan, DirectX, OpenGL, Software
    }

    public class Canvas
    {
        //Draw a rectangle or a screen
        public static List<Pixel> ScreenRender = new List<Pixel>();
        public RenderType currentRender;

        public Canvas()
        {
            if(currentRender != RenderType.Software)
            {
                Console.WriteLine("Other rendering engines are not supported at this time...");
            }
        }

        public static void DrawPixel(int x, int y, Color color, string name)
        {
            ScreenRender.Add(new Pixel(x, y, color, name));
        }

        public static void DrawRect(Rectangle rect, Color color, string name)
        {
            ClearPixels(name);
            for(int x = rect.posx; x < rect.posx + rect.sizex; x++)
            {
                for(int y = rect.posy; y < rect.posy + rect.sizey; y++)
                {
                    DrawPixel(x, y, color, name);
                }
            }
        }

        public static void DrawImage(Rectangle size, ParEngineImage image, string name)
        {
            ClearPixels(name);
            Bitmap ima = image.map_;
            ima = ImageDrawer.ResizeImage(ima, size.sizex, size.sizey);
            for(int x = size.posx; x < size.posx + ima.Width; x++)
            {
                for(int y = size.posy; y < size.posy + ima.Height; y++)
                {
                    System.Drawing.Color imaColor = ima.GetPixel(x, y);
                    Color color = new Color(imaColor.R, imaColor.G, imaColor.B);
                    DrawPixel(x, y, color, name);
                }
            }
            ima.Dispose();
        }

        public static void MoveAllPixels(Vector2 direction, string blackList)
        {
            foreach(Pixel m in ScreenRender)
            {
                if (m.namePixel != blackList)
                {
                    m.X = m.X + (int)direction.x;
                    m.Y = m.Y + (int)direction.y; 
                }
            }
        }

        public static void ClearPixels(string name)
        {
            foreach(Pixel m in ScreenRender.ToArray())
            {
                if(m.namePixel == name)
                {
                    ScreenRender.Remove(m);
                }
            }
        }

        public static void DrawRect(int x, int y, int sizex, int sizey, Color color, string name)
        {
            DrawRect(new Rectangle(sizex, sizey, x, y), color, name);
        }

        public static void DrawRect(int x, int y, int sizex, int sizey, int r, int g, int b, string name)
        {
            DrawRect(new Rectangle(sizex, sizey, x, y), new Color(r, g, b), name);
        }
    }
}
