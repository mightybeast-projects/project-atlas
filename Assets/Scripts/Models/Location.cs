using System.Collections.Generic;
using Enums;
using Models.GameObjectModel;
using MonoBehaviours.GameObjects.Enemy;

namespace Models
{
    public class Location
    {
        public int tWidth { get; }
        public int tHeight { get; }
        public int width { get; }
        public int height { get; }
        public Tile[,] grid { get; }
        public WorldSide startSide { get; }
        public List<WorldSide> exitSides { get; }
        public Biome biome { get; }
        public List<EnemyBehaviour> enemies { get; }

        public Location(int tWidth, int tHeight, WorldSide startSide, List<WorldSide> exitSides, Biome biome)
        {
            this.tWidth = tWidth;
            this.tHeight = tHeight;

            width = tWidth * 32;
            height = tHeight * 32;
            grid = new Tile[tWidth, tHeight];

            this.startSide = startSide;
            this.exitSides = exitSides;
            this.biome = biome;

            enemies = new List<EnemyBehaviour>();
        }
        
        public Tile GetCenterTile()
        {
            var x = grid.GetLength(0) / 2;
            var y = grid.GetLength(1) / 2;
            var tile = grid[x, y];
            return tile;
        }
    }
}