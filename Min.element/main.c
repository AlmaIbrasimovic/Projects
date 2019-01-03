#include <stdio.h>
#include <stdlib.h>
#define VEL 10

int main()
{
    int i,j,mat[VEL][VEL];
    printf("Unesite elemente matrice: ");
    for (i=0;i<VEL;i++)
    {
        for (j=0;j<VEL;j++)
        {
            scanf("%d",&mat[i][j]);
        }
    }
    printf("Unijeli ste matricu:\n");
    for (i=0;i<VEL;i++)
    {
        for (j=0;j<VEL;j++)
        {
            printf("%5d",mat[i][j]);
        }
        printf("\n");
    }
    int min=mat[0][0],max=mat[0][0];
    for(i=0;i<VEL;i++)
    {
        for (j=0;j<VEL;j++)
        {
            if (i==j)
            {
                if (mat[i][j]<min)
                    min=mat[i][j];
                else if (mat[i][j]>max)
                    max=mat[i][j];
            }
        }
    }
    printf("Najmanji element na glavnoj dijagonali je %d",min);
    return 0;
}
