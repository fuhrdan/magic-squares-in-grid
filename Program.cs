//*****************************************************************************
//** 840. Magic Squares in Grid  leetcode                                    **
//** Very slow solution, moves a 3x3 grid to see if one works.  Many         **
//** can be made to speed it up.                                    -Dan     **
//*****************************************************************************

int numMagicSquaresInside(int** grid, int gridSize, int* gridColSize) {
    int count = 0;
    int numberHash[16] = {0};
    int sum = 15;
    for(int i = 0; i < gridSize-2; i++)
    {
        for(int j = 0; j < gridColSize[0]-2; j++)
        {
            int good = 0;
            sum = grid[i][j] + grid[i][j+1] + grid[i][j+2];
//            printf("grid[%d][%d] = %d\n",i,j,grid[i][j]);
            if((grid[i][j]+grid[i][j+1]+grid[i][j+2])==sum) good++;      // First Column
            if((grid[i+1][j]+grid[i+1][j+1]+grid[i+1][j+2])==sum) good++;// Second Column
            if((grid[i+2][j]+grid[i+2][j+1]+grid[i+2][j+2])==sum) good++;// Third Column
            if((grid[i][j]+grid[i+1][j+1]+grid[i+2][j+2])==sum) good++; //  Diagonal
            if((grid[i][j]+grid[i+1][j]+grid[i+2][j])==sum) good++; // First Row
            if((grid[i+1][j]+grid[i+1][j+1]+grid[i+1][j+2])==sum) good++; // Second Row
            if((grid[i+2][j]+grid[i+2][j+1]+grid[i+2][j+2])==sum) good++; // Third Row
            if((grid[i+2][j]+grid[i+1][j+1]+grid[i][j+2])==sum) good++; // Diagonal
            numberHash[grid[i][j]]++;
            numberHash[grid[i][j+1]]++;
            numberHash[grid[i][j+2]]++;
            numberHash[grid[i+1][j]]++;
            numberHash[grid[i+1][j+1]]++;
            numberHash[grid[i+1][j+2]]++;
            numberHash[grid[i+2][j]]++;
            numberHash[grid[i+2][j+1]]++;
            numberHash[grid[i+2][j+2]]++;
            for(int k = 1; k < 10; k++)
            {
//                printf("good = %d\n",good);
//                printf("numberHash[%d] = %d\n",k,numberHash[j]);
                if((numberHash[k] > 1)||(numberHash[k]==0))  good = 0;
                numberHash[k] = 0;
            }
            if(good == 8) count++;
        }    
    }
    return count;
}