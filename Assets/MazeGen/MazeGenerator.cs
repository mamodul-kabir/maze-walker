using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    //Add the prefab of a single maze cell
    [SerializeField]
    private MazeCell mazeCellPrefab;
    //set length and width of the maze
    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    //[SerializeField]
    //private float depthBias = 0.01f;

    private int cur = 0;

    private MazeCell[,] mazeGrid;

    void Start()
    {
        //create a grid in the terrain of maze cells, placing them next to one another
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];

        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeDepth; j++)
            {
                mazeGrid[i, j] = Instantiate(mazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
        //run a dfs in the maze cells, by visiting each cell and connecting it to the previous visited cell
        GenerateMaze(null, mazeGrid[0, 0]);
        int entrance = mazeDepth / 2;
        //clear the front and back wall of the entrance and exit of the maze
        mazeGrid[entrance, 0].ClearBackWall();
        mazeGrid[entrance, mazeDepth - 1].ClearFrontWall();
    }
    //dfs-algorithm to visit and create maze cells
    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        //mark the current cell as visited and remove the connecting 
        //walls between previous cell and current cell
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);
        MazeCell nextCell;
        //randomly select a next cell from the adjacent unvisited cells. 
        do
        {
            nextCell = NextUnvisitedCell(currentCell);
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    //randomly select the next unvisited adjacent cells
    private MazeCell NextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCell(currentCell);
        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();

    }

    //Coroutine below checks the current cell in the grid and identifies its adjacent cells and returns them. 

    private IEnumerable<MazeCell> GetUnvisitedCell(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;
        if (x + 1 < mazeWidth)
        {
            var celltoRight = mazeGrid[x + 1, z];
            if (celltoRight.IsVisited == false)
            {
                yield return celltoRight;
            }
        }
        if (x - 1 >= 0)
        {
            var celltoLeft = mazeGrid[x - 1, z];
            if (celltoLeft.IsVisited == false)
            {
                yield return celltoLeft;
            }
        }
        if (z + 1 < mazeDepth)
        {
            var celltoFront = mazeGrid[x, z + 1];
            if (celltoFront.IsVisited == false)
            {
                yield return celltoFront;
            }
        }
        if (z - 1 >= 0)
        {
            var celltoBack = mazeGrid[x, z - 1];
            if (celltoBack.IsVisited == false)
            {
                yield return celltoBack;
            }
        }
    }

    //clear the walls based on the position of the current cell and last cell
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }
        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }
        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }
}
